using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Model;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class InvoicingContext : DbContext, IInvoicingContext
    {
        public InvoicingContext(DbContextOptions<InvoicingContext> options) : base(options)
        {
        }

        public DbSet<InvoiceOrder> InvoiceOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=Invoicing;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceOrderConfig());
        }

        async Task IInvoicingContext.SaveChangesAsync()
        {
            await this.SaveChangesAsync();
        }
    }
}