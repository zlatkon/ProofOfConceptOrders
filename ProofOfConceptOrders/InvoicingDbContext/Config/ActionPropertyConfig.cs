using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class ActionPropertyConfig : IEntityTypeConfiguration<ActionProperty>
    {
        public void Configure(EntityTypeBuilder<ActionProperty> builder)
        {
            builder.HasKey("Id");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasIndex(x => x.Name);
        }
    }
}
