using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Model
{
    public class OrderJson
    {
        public Guid Id { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
