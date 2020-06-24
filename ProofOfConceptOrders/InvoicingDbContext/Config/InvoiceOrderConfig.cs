using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProofOfConceptOrders.Model;
using System.Collections.Generic;

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

            builder.Property(e => e.Properties).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<List<Property>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            builder.Property(e => e.StockLines).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<List<StockLine>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            builder.Property(e => e.Actions).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<List<Action>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}