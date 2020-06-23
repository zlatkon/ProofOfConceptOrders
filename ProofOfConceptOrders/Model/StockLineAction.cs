using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Model
{
    public class StockLineAction
    {
        private readonly List<StockLineActionProperty> _properties;

        private StockLineAction()
        {
            _properties = new List<StockLineActionProperty>();
        }

        public static StockLineAction Create(string actionName)
        {
            return new StockLineAction
            {
                Id = Guid.NewGuid(),
                ActionName = actionName
            };
        }

        public static StockLineAction Create(Guid wmsActionId)
        {
            return new StockLineAction
            {
                Id = Guid.NewGuid(),
                WmsActionId = wmsActionId
            };
        }

        public Guid Id { get; private set; }
        public Guid WmsActionId { get; set; }
        public string ActionName { get; private set; }
        public IReadOnlyCollection<StockLineActionProperty> Properties => _properties;

        public void AddProperty(Guid propertyTypeId, string dataType, string name, string value)
        {
            var property = GetProperty(name);
            if (property != null)
                _properties.Remove(property);

            property = StockLineActionProperty.Create(name, value);
            _properties.Add(property);
        }

        public StockLineActionProperty GetProperty(string name)
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
