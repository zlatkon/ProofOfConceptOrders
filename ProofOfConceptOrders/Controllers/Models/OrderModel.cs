using ProofOfConceptOrders.Model;
using System;
using System.Linq.Expressions;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public string TransportNumber { get; set; }
        public string Customer { get; set; }
        public string Haulier { get; set; }

        public static Expression<Func<Order, OrderModel>> Projection
        {
            get
            {
                return x => new OrderModel
                {
                    Id = x.Id,

                    OrderNumber = x.Orders.OrderNumber,
                    TransportNumber = x.Orders.TransportNumber,
                    Haulier = x.Orders.Haulier,
                    Customer = x.Orders.Customer
                };
            }
        }
    }
}