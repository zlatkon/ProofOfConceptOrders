using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class StockLineQuantityDTO
    {
        public string Type { get;  set; }
      
        public decimal Quantity { get; set; }

        public string HandlingUnit { get; set; }

    }
}
