using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Controllers.Models;
using ProofOfConceptOrders.InvoicingDbContext.Config;
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
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<StockLineDTO> StockLines { get; set; }
        public DbSet<StockLineWithAllDTO> StockLinesWithEveryuthing { get; set; }
        public DbSet<StockLineWithPropertiesDTO> StockLinesWithProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=Invoicing;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceOrderConfig());
            modelBuilder.Entity<StockLineDTO>().HasNoKey();
            modelBuilder.ApplyConfiguration(new StockLineWithAllDTOConfig());
            modelBuilder.Entity<StockLineWithPropertiesDTO>().HasNoKey();
        }

        async Task IInvoicingContext.SaveChangesAsync()
        {
            await this.SaveChangesAsync();
        }
    }
}