using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProofOfConceptOrders.Model
{
    public class PropertyType
    {
        private PropertyType()
        {
            PossibleValues = new List<string>();
        }

        public static PropertyType Create(string application, PropertyLevel propertyLevel, string propertyName, DataType dataType, string[] possibleValues)
        {
            var propertyType = new PropertyType()
            {
                Id = Guid.NewGuid(),
                Application = application,
                PropertyLevel = propertyLevel,
                PropertyName = propertyName,
                DataType = dataType
            };
            propertyType.UpdatePossibleValues(possibleValues);

            return propertyType;
        }

        public static PropertyType Create(string application, PropertyLevel propertyLevel, string propertyName, DataType dataType)
        {
            return Create(application, propertyLevel, propertyName, dataType, Array.Empty<string>());
        }

        public Guid Id { get; private set; }
        public string Application { get; private set; }
        public PropertyLevel PropertyLevel { get; private set; }
        public string PropertyName { get; private set; }
        public DataType DataType { get; private set; }

        [NotMapped]
        public ICollection<string> PossibleValues { get; private set; }

        public void UpdatePossibleValues(IEnumerable<string> possibleValues)
        {
            PossibleValues = new List<string>();

            if (possibleValues == null)
                return;

            foreach (var possibleValue in possibleValues)
                AddPossibleValue(possibleValue);
        }

        private void AddPossibleValue(string possibleValue)
        {
            var value = (possibleValue ?? "").Trim();

            if (string.IsNullOrEmpty(value))
                return;

            var valueAlreadyIncluded = PossibleValues.Any(x => x.Equals(value, StringComparison.CurrentCultureIgnoreCase));
            if (valueAlreadyIncluded)
                return;

            PossibleValues.Add(value);
        }
    }
}