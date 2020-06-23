using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Model
{
    public class StockLineActionProperty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        private StockLineActionProperty()
        {
        }

        public static StockLineActionProperty Create(string name, string value)
        {
            var property = new StockLineActionProperty()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Value = value,
            };
            return property;

        }
        internal void UpdateProperty(StockLineActionProperty property)
        {
            Name = property.Name;
            Value = property.Value;
        }
        internal void UpdateProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
