using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProofOfConceptOrders.Controllers.Models;
using System.Collections.Generic;

namespace ProofOfConceptOrders.InvoicingDbContext.Config
{
    public class StockLineWithAllDTOConfig : IEntityTypeConfiguration<StockLineWithAllDTO>
    {
        public void Configure(EntityTypeBuilder<StockLineWithAllDTO> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.Properties).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<List<PropertyModel>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            builder.Property(e => e.Actions).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<List<StockLineActionModel>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}