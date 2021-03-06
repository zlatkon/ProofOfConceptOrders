﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProofOfConceptOrders.InvoicingDbContext;

namespace ProofOfConceptOrdersTest.Testing
{
    public class SqlServerBaseApiTest : AbstractBaseApiTest
    {
        private const string _connection = @"Server=localhost;Initial Catalog=Invoicing;Integrated Security=true;MultipleActiveResultSets=true;";

        protected override IServiceCollection AddDb(IServiceCollection services, bool enableLogging)
        {
            services.AddDbContext<InvoicingContext>(o =>
            {
                o.UseSqlServer(_connection);
                if (enableLogging)
                {
                    o.UseLoggerFactory(ConsoleLoggerFactory);
                    o.EnableSensitiveDataLogging();
                }
            });

            return services;
        }

        protected override DbContextOptionsBuilder<InvoicingContext> CreateDbOptionsBuilder()
        {
            var options = new DbContextOptionsBuilder<InvoicingContext>()
                .UseSqlServer(_connection);
            return options;
        }
    }
}