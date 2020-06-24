using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProofOfConceptOrders.Model;
using System.Collections.Generic;

namespace ProofOfConceptOrders.InvoicingDbContext.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Property<string>("ExtendedData")
            //.HasField("_extendedData");

            //builder.Property<string>("ExtendedData")
            //.HasField("_extendedData");

            //builder
            //.Property(x => x.ExtendedData)
            //.HasJsonValueConversion();

            builder.Property(e => e.JsonOrders).HasConversion(
            v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
            v => JsonConvert.DeserializeObject<IList<JsonOrder>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

            //builder
            //.Property(x => x.JsonOrders)
            //.HasJsonValueConversion();
        }
    }
}