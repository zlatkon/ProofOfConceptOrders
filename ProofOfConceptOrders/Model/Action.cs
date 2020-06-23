using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Model
{
    public class Action
    {
        private readonly List<Property> _properties;

        private Action()
        {
            _properties = new List<Property>();
        }

        public static Action Create(string actionName)
        {
            return new Action
            {
                Id = Guid.NewGuid(),
                ActionName = actionName
            };
        }

        public static Action Create(Guid wmsActionId)
        {
            return new Action
            {
                Id = Guid.NewGuid(),
                WmsActionId = wmsActionId
            };
        }

        public Guid Id { get; private set; }
        public Guid WmsActionId { get; set; }
        public string ActionName { get; private set; }
        public IReadOnlyCollection<Property> Properties => _properties;

        public void AddProperty(Guid propertyTypeId, string dataType, string name, string value)
        {
            var property = GetProperty(name);
            if (property != null)
                _properties.Remove(property);

            property = Property.Create(name, value);
            _properties.Add(property);
        }

        public Property GetProperty(string name)
        {
            var prop = _properties.SingleOrDefault(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            return prop;
        }

        public void UpdateActionName(string actionName)
        {
            ActionName = actionName;
        }
    }
}
