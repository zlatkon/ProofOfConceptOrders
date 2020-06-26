using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.Interfaces;
using ProofOfConceptOrders.InvoicingDbContext;
using System;
using System.Linq;

namespace ProofOfConceptOrders.Providers
{
    public class GetStockLinesProvider : IGetStockLinesProvider
    {
        private readonly InvoicingContext _invoicingContext;

        public GetStockLinesProvider(InvoicingContext invoicingContext)
        {
            _invoicingContext = invoicingContext;
        }

        public IQueryable<StockLineDTO> GetStockLines(Guid invoiceOrderID)
        {
            string sqlComm = @"SELECT *
                FROM OPENJSON
                    (
                        (
                            Select stocklines
                            from InvoiceOrders
                            where id = ({0})
                        )
                    )
                WITH
                (
                Id uniqueidentifier '$.Id',
                Product Nvarchar(100) '$.Product',
                Pallets int '$.Pallets'
                )";

            var stockLines = _invoicingContext.StockLines
                .FromSqlRaw(sqlComm, invoiceOrderID);

            var result = stockLines.AsQueryable();

            return result;
        }

        public IQueryable<StockLineWithAllDTO> GetStockLinesIncludingEverything(Guid invoiceOrderID)
        {
            string sqlComm = @"SELECT *
                FROM OPENJSON
                    (
                        (
                            Select stocklines
                            from InvoiceOrders
                            where id = ({0})
                        )
                    )
                WITH
                (
                Id uniqueidentifier '$.Id',
                Product Nvarchar(100) '$.Product',
                Pallets int '$.Pallets',
                Properties  nvarchar(MAX) '$.Properties' AS JSON ,
				Actions  nvarchar(MAX) '$.StockLineActions' AS JSON
                )";

            var stockLines = _invoicingContext.StockLinesWithEveryuthing
                .FromSqlRaw(sqlComm, invoiceOrderID);

            var result = stockLines.AsQueryable();

            return result;
        }

        public IQueryable<StockLineWithPropertiesDTO> GetStockLinesIncludingProperties(Guid invoiceOrderID)
        {
            string sqlComm = @"SELECT *
                FROM OPENJSON
                    (
                        (
                            Select stocklines
                            from InvoiceOrders
                            where id = ({0})
                        )
                    )
                WITH
                (
                Properties  nvarchar(MAX)  AS JSON
                )
                OUTER APPLY OPENJSON(Properties)
				WITH
				(
				Property NVARCHAR(50) '$.Name',
				[Value] NVARCHAR(50) '$.Value'
				)";

            var stockLines = _invoicingContext.StockLinesWithProperties
                .FromSqlRaw(sqlComm, invoiceOrderID);

            var result = stockLines.AsQueryable();

            return result;
        }
    }
}