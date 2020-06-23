﻿using Microsoft.EntityFrameworkCore;
using ProofOfConceptOrders.Model;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class InvoicingContext : DbContext, IInvoicingContext
    {
        public InvoicingContext(DbContextOptions<InvoicingContext> options) : base(options)
        {
        }

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
            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new StockLineConfig());
            modelBuilder.ApplyConfiguration(new ActionPropertyConfig());
            modelBuilder.ApplyConfiguration(new InvoiceOrderConfig());
            modelBuilder.ApplyConfiguration(new ActionConfig());
            modelBuilder.ApplyConfiguration(new StockLineActionConfig());
            modelBuilder.ApplyConfiguration(new StockLineActionPropertyConfig());
        }
    }
}