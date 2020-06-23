using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action = ProofOfConceptOrders.Model.Action;

namespace ProofOfConceptOrders.InvoicingContext
{
    public class ActionConfig : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey("Id");
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasIndex(x => x.WmsActionId);

            var propertiesNavigation = builder.Metadata.FindNavigation(nameof(Action.Properties));
            propertiesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Properties)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
