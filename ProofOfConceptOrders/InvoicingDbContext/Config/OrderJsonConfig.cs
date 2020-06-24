using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofOfConceptOrders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.InvoicingDbContext.Config
{
    public class OrderJsonConfig : IEntityTypeConfiguration<OrderJson>
    {
        public void Configure(EntityTypeBuilder<OrderJson> builder)
        {
            builder.HasKey(x => x.Id); 
        }
    }
}
