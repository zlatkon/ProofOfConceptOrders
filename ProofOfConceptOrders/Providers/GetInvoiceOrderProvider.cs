using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Interfaces;
using ProofOfConceptOrders.InvoicingDbContext;
using System;
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

        public async Task<Result> GetInvoiceOrder(Guid invoiceOrderId)
        {
            var invoiceOrder = _invoicingContext.InvoiceOrders.AsNoTracking()
                .Where(x => x.Id == invoiceOrderId)
                .AsQueryable();

            return Result.Ok();
        }
    }
}