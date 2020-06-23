using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Model;
using ProofOfConceptOrders.Model.ValueObject;
using System;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class InvoicingContext : DbContext , IInvoicingContext
    {
        public DbSet<InvoiceOrder> InvoiceOrders { get; set; }

        public DbSet<StockLine> StockLines { get; set; }

        public DbSet<Property> Property { get; set; }

        public DbSet<Action> Actions { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=Invoicing;Integrated Security=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceOrderConfig());
            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new StockLineConfig());
            modelBuilder.ApplyConfiguration(new ActionConfig());

            #region InvoiceOrder

            var invoiceOrder = InvoiceOrder.Create("Platno", Guid.NewGuid(), "ON000001", "TN000001");
            invoiceOrder.AddProperties("prop1", "value1");
            invoiceOrder.AddProperties("prop2", "value2");
            invoiceOrder.AddProperties("prop3", "value3");
            invoiceOrder.SetInvoiced();
            invoiceOrder.SetSite("Site");

            modelBuilder.Entity<InvoiceOrder>().HasData(invoiceOrder);

            #endregion InvoiceOrder
        }
    }
}