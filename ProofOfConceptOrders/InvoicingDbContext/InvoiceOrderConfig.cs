using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class InvoiceOrderConfig : IEntityTypeConfiguration<InvoiceOrder>
    {
        public void Configure(EntityTypeBuilder<InvoiceOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(x => x.Customer).IsRequired();
            builder.Property(x => x.OrderNumber).IsRequired();
            builder.Property(x => x.Date).IsRequired(false);

            builder.Ignore(x => x.OrderType);

            var stockLinesNavigation = builder.Metadata.FindNavigation(nameof(InvoiceOrder.StockLines));
            stockLinesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.StockLines)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            var actionsNavigation = builder.Metadata.FindNavigation(nameof(InvoiceOrder.Actions));
            actionsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Actions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.Properties);

            builder.HasMany<Property>("_properties")
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.TransportNumber)
                .HasMaxLength(50);

            builder.HasIndex(x => x.OrderNumber);
            builder.HasIndex(x => x.TransportNumber);
            builder.HasIndex(x => x.WmsOrderId);

            builder.Property<byte[]>("Timestamp")
                .IsRowVersion();

            //builder.Property<string>("ExtendedData")
            //.HasField("_extendedData");

            //builder
            //.Property(x => x.ExtendedData)
            //.HasJsonValueConversion();
        }
    }
}