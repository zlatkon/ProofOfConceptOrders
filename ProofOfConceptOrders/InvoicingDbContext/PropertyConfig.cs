using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model.ValueObject;
using System;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder
               .Property<Guid>("Id")
               .ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Name);
        }
    }
}