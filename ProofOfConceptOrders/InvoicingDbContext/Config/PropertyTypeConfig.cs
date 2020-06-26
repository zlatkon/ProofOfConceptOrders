using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using ProofOfConceptOrders.Model;
using System.Collections.Generic;

namespace ProofOfConceptOrders.InvoicingDbContext.Config
{
    public class PropertyTypeConfig : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasIndex(x => x.PropertyName);

            builder.Property(x => x.PropertyLevel)
                .HasConversion(new EnumToStringConverter<PropertyLevel>());

            builder.Property(x => x.DataType)
                .HasConversion(new EnumToStringConverter<DataType>());

            var splitStringConverter = new ValueConverter<ICollection<string>, string>(
                          v => JsonConvert.SerializeObject(v),
                          v => !string.IsNullOrEmpty(v) ?
                          JsonConvert.DeserializeObject<ICollection<string>>(v) : new List<string>());

            builder.Property(x => x.PossibleValues)
                .HasConversion(splitStringConverter);
        }
    }
}