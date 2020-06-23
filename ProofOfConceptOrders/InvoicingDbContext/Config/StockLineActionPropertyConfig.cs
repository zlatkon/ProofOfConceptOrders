using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.InvoicingDbContext
{
    public class StockLineActionPropertyConfig : IEntityTypeConfiguration<StockLineActionProperty>
    {
        public void Configure(EntityTypeBuilder<StockLineActionProperty> builder)
        {
            builder.HasKey("Id");
            builder.HasIndex(x => x.Name);
        }
    }
}
