using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Model;
using System.Threading.Tasks;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public interface IInvoicingContext
    {
        DbSet<InvoiceOrder> InvoiceOrders { get; }
        DbSet<StockLine> StockLines { get; }
        DbSet<Property> Property { get; }
        DbSet<Action> Actions { get; }
        DbSet<OrderJson> OrdersJson { get; }
        DbSet<Order> Orders { get; }

        Task SaveChangesAsync();
    }
}