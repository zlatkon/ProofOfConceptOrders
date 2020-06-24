using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProofOfConceptOrders.Model
{
    public class Order
    {
        public static Order Create()
        {
            var invoiceOrder = new Order
            {
                Id = Guid.NewGuid()
            };

            return invoiceOrder;
        }

        internal string _Orders { get; set; }

        public Guid Id { get; set; }

        [NotMapped]
        public JsonOrder Orders
        {
            get { return _Orders == null ? null : JsonConvert.DeserializeObject<JsonOrder>(_Orders); }
            set { _Orders = JsonConvert.SerializeObject(value); }
        }

        public JsonOrder AddJson(string test)
        {
            var order = new JsonOrder
            {
                Customer = test
            };
            return order;
        }
    }

    public class JsonOrder
    {
        public string OrderNumber { get; set; }
        public string TransportNumber { get; set; }
        public string Customer { get; set; }
        public string Haulier { get; set; }
    }
}