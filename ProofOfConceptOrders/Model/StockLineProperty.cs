using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Model
{
    public class StockLineProperty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        private StockLineProperty()
        {
        }

        public static StockLineProperty Create(string name, string value)
        {
            var property = new StockLineProperty()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Value = value,
            };
            return property;

        }
        internal void UpdateProperty(StockLineProperty property)
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
