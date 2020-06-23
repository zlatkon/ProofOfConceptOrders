using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class ActionConfig : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey("Id");
            builder.Property(e => e.Id).ValueGeneratedNever();             

            var propertiesNavigation = builder.Metadata.FindNavigation(nameof(Action.Properties));
            propertiesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Properties)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}