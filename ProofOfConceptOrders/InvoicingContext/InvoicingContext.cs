using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.InvoicingContext
{
    public class InvoicingContext : DbContext
    {
        public DbSet<InvoiceOrder> InvoiceOrders { get; set; }
        public DbSet<Model.Action> Actions { get; set; }
        public DbSet<StockLine> StockLines { get; set; }
        public DbSet<Property> Propertys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=CA.Invoicing;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceOrderConfig());
            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new StockLineConfig());
            modelBuilder.ApplyConfiguration(new ActionConfig());

            #region InvoiceOrder

            var invoiceOrder = InvoiceOrder.Create("Platno", Guid.NewGuid(), "ON000001", "TN000001");
            invoiceOrder.AddStockLine
            modelBuilder.Entity<InvoiceOrder>().HasData(
                new InvoiceOrder() { BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1" });
            #endregion

        }
    }
}
