using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Interfaces;
using ProofOfConceptOrders.InvoicingDbContext;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Providers
{
    public class GetInvoiceOrderProvider : IGetInvoiceOrderProvider
    {
        private readonly InvoicingContext _invoicingContext;

        public GetInvoiceOrderProvider(InvoicingContext invoicingContext)
        {
            _invoicingContext = invoicingContext;
        }

        public async Task<long> GetInvoiceOrder(Guid invoiceOrderId)
        {
            var sw = Stopwatch.StartNew();
            var invoiceOrder = _invoicingContext.InvoiceOrders.AsNoTracking()
                .Where(x => x.Id == invoiceOrderId)
                .AsQueryable();
            sw.Stop();
            var timeSpent = sw.ElapsedMilliseconds;

            return timeSpent;
        }
    }
}