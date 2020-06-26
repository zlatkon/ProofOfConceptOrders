using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.Model;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public interface IInvoicingContext
    {
        DbSet<InvoiceOrder> InvoiceOrders { get; }
        DbSet<PropertyType> PropertyTypes { get; set; }
        DbSet<StockLineDTO> StockLines { get; set; }
        DbSet<StockLineWithAllDTO> StockLinesWithEveryuthing { get; set; }
        DbSet<StockLineWithPropertiesDTO> StockLinesWithProperties { get; set; }

        Task SaveChangesAsync();
    }
}