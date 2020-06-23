using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class StockLineActionConfig : IEntityTypeConfiguration<StockLineAction>
    {
        public void Configure(EntityTypeBuilder<StockLineAction> builder)
        {
            builder.HasKey("Id");
            builder.Property(e => e.Id).ValueGeneratedNever();

            var propertiesNavigation = builder.Metadata.FindNavigation(nameof(StockLineAction.Properties));
            propertiesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Properties)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
