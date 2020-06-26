using System;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class StockLineDTO
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public int Pallets { get; set; }
    }
}