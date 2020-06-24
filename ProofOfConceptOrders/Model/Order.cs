using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProofOfConceptOrders.Model
{
    public class Order
    {
        internal string _Orders { get; set; }

        public Guid Id { get; set; }
        public string OrderNumber { get; private set; }
        public string TransportNumber { get; private set; }
        public string Customer { get; private set; }
        public string Haulier { get; private set; }

        [NotMapped]
        public JsonOrder Orders
        {
            get { return _Orders == null ? null : JsonConvert.DeserializeObject<JsonOrder>(_Orders); }
            set { _Orders = JsonConvert.SerializeObject(value); }
        }
    }

    public class JsonOrder
    {
        public string OrderNumber { get; private set; }
        public string TransportNumber { get; private set; }
        public string Customer { get; private set; }
        public string Haulier { get; private set; }
    }
}