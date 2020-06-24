using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;

namespace ProofOfConceptOrders.InvoicingDbContext.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b._Orders).HasColumnName("Orders");
        }
    }
}