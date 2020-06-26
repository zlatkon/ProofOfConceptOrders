using System;
using System.Collections.Generic;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class StockLineWithAllDTO
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public int Pallets { get; set; }
        public IReadOnlyCollection<PropertyModel> Properties { get; set; }
        public IReadOnlyCollection<StockLineActionModel> Actions { get; set; }
    }
}