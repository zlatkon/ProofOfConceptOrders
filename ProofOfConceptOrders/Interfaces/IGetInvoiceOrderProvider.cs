using CSharpFunctionalExtensions;
using System;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Interfaces
{
    public interface IGetInvoiceOrderProvider
    {
        Task<Result> GetInvoiceOrder(Guid invoiceOrderId);
    }
}