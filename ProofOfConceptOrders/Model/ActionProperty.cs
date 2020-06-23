using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Model
{
    public class ActionProperty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        private ActionProperty()
        {
        }

        public static ActionProperty Create(string name, string value)
        {
            var property = new ActionProperty()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Value = value,
            };
            return property;

        }
        internal void UpdateProperty(ActionProperty property)
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
