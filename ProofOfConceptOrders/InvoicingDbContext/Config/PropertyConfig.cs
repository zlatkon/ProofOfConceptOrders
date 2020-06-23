using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;
using System;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey("Id"); 
            builder.HasIndex(x => x.Name);
        }
    }
}