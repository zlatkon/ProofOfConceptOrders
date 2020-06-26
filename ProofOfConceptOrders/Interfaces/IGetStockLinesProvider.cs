using ProofOfConceptOrders.Controllers.Models;
using System;
using System.Linq;

namespace ProofOfConceptOrders.Interfaces
{
    public interface IGetStockLinesProvider
    {
        IQueryable<StockLineDTO> GetStockLines(Guid invoiceOrderID);

        IQueryable<StockLineWithAllDTO> GetStockLinesIncludingEverything(Guid invoiceOrderID);

        IQueryable<StockLineWithPropertiesDTO> GetStockLinesIncludingProperties(Guid invoiceOrderID);
    }
}