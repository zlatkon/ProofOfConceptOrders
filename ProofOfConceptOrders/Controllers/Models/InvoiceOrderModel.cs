using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.Controllers.Models
{
    public class InvoiceOrderModel
    {
        public Guid Id { get; set; }
        public string Application { get; set; }
        public string OrderType { get; set; }
        public string Customer { get; set; }
        public string OrderNumber { get; set; }
        public string TransportNumber { get; set; }
        public DateTime? Date { get; set; }
        public bool Invoiced { get; set; }
        public bool IsAutomaticInvoicingAllowed { get; set; }
        public bool Cancel { get; set; }
        public string Site { get; set; }
        public IEnumerable<StockLineWithAllDTO> StockLines { get; set; }
        public IEnumerable<ActionProperty> Actions { get; set; }
        public IEnumerable<Property> Properties { get; set; }

        public static Expression<Func<InvoiceOrder, InvoiceOrderModel>> Projection
        {
            get
            {
                return x => new InvoiceOrderModel
                {
                    Id = x.Id,
                    Application = x.Application,
                    OrderType = x.OrderType,
                    OrderNumber = x.OrderNumber,
                    TransportNumber = x.TransportNumber,
                    Date = x.Date,
                    Customer = x.Customer,
                    Invoiced = x.IsInvoiced,
                    IsAutomaticInvoicingAllowed = x.IsAutomaticInvoicingAllowed,
                    Cancel = x.IsCancelled,
                    Site = x.Site
                };
            }
        }
    }
}