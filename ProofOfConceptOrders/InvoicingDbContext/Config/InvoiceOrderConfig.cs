﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
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

            //var stockLinesNavigation = builder.Metadata.FindNavigation(nameof(InvoiceOrder.StockLines));
            //stockLinesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            //builder.HasMany(x => x.StockLines)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            //var actionsNavigation = builder.Metadata.FindNavigation(nameof(InvoiceOrder.Actions));
            //actionsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            //builder.HasMany(x => x.Actions)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            //var propertyNavigation = builder.Metadata.FindNavigation(nameof(InvoiceOrder.Properties));
            //propertyNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            //builder.HasMany(x => x.Properties)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Cascade);

            var splitStringConverter = new ValueConverter<string, string>(
                          v => JsonConvert.SerializeObject(v),
                          v => JsonConvert.DeserializeObject<string>(v));
 
            //builder.Property(x => x.ActionsJson)
            //    .HasConversion(splitStringConverter);

            //builder.Property(x => x.PropertiesJson)
            //    .HasConversion(splitStringConverter);
            
            //builder.Property(x => x.StockLinesJson)
            //    .HasConversion(splitStringConverter);
            
            //builder.Property(x => x.Json)
            //    .HasConversion(splitStringConverter);
        }
    }
}