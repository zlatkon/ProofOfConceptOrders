using Newtonsoft.Json;
using ProofOfConceptOrders.Model.ValueObject;
using System;

namespace ProofOfConceptOrders.Model
{
    public class Property
    {
        [JsonProperty]
        public Guid Id { get; private set; }
        
        [JsonProperty]
        public string Name { get; private set; }
        
        [JsonProperty]
        public string Value { get; private set; }

        private Property()
        {
        }

        public static Property Create(string name, string value)
        {
            var property = new Property()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Value = value,
            };
            return property;

        }
        internal void UpdateProperty(Property property)
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