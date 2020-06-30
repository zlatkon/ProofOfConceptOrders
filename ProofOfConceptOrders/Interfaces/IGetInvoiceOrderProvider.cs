using System;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Interfaces
{
    public interface IGetInvoiceOrderProvider
    {
        Task<long> GetInvoiceOrder(Guid invoiceOrderId);
    }
}