using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;

namespace ProofOfConceptOrders.InvoicingContext
{
    public class StockLineConfig : IEntityTypeConfiguration<StockLine>
    {
        public void Configure(EntityTypeBuilder<StockLine> builder)
        {
            builder.HasKey("Id");
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasIndex(x => x.WmsStocklineId);


            var propertiesNavigation = builder.Metadata.FindNavigation(nameof(StockLine.Properties));
            propertiesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Properties)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull);

            var actionsNavigation = builder.Metadata.FindNavigation(nameof(StockLine.StockLineActions));
            actionsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.StockLineActions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.Pallets);
            builder.Ignore(x => x.HandlingUnits);

        }
    }
}
