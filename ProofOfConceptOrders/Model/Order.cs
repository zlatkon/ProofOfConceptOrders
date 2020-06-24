using System;
using System.Collections.Generic;

namespace ProofOfConceptOrders.Model
{
    public class Order
    {
        public Guid Id { get; set; }

        public IList<JsonOrder> JsonOrders { get; set; }
    }

    public class JsonOrder
    {
        public string Order { get; set; }
    }
}