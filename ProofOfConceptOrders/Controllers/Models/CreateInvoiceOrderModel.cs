using System;
using System.Collections.Generic;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class CreateInvoiceOrderModel
    {
        public CreateInvoiceOrderModel()
        {
            StockLines = new List<StockLineWithAllDTO>();
            Actions = new List<ActionModel>();
            Properties = new List<PropertyModel>();
        }

        public string Application { get; set; }
        public string OrderType { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string OrderNumber { get; set; }
        public string TransportNumber { get; set; }
        public DateTime? Date { get; set; }
        public string Site { get; set; }
        public IEnumerable<PropertyModel> Properties { get; set; }
        public IEnumerable<StockLineWithAllDTO> StockLines { get; set; }
        public IEnumerable<ActionModel> Actions { get; set; }
    }
}