﻿using System;

namespace ProofOfConceptOrders.Model
{
    public class Property
    {
        private Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

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