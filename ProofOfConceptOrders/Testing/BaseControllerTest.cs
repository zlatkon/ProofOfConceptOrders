using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProofOfConceptOrders.InvoicingDbContext;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ProofOfConceptOrders.Testing
{
    public class BaseControllerTest : IDisposable
    {
        private bool _disposedValue = false;
        private readonly TestServer _server;
        protected HttpClient Client => _server.CreateClient();
        protected InvoicingContext InvoicingContext => _server.Host.Services.GetService<InvoicingContext>();
        protected DbContextOptions<InvoicingContext> Options;

        public BaseControllerTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            Options = new DbContextOptionsBuilder<InvoicingContext>()
                .UseSqlite(connection)
                .Options;

            _server = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((hostincontext, config) =>
                {
                    config.AddInMemoryCollection(Configuration);
                })
                .UseEnvironment("Test")
                .UseStartup<Startup>());

            InvoicingContext.Database.EnsureCreated();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    InvoicingContext?.Dispose();
                    Client?.Dispose();
                    _server?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private Dictionary<string, string> Configuration =>
            new Dictionary<string, string>
            {
                { "CORS:Origins", "http://localhost" },
                { "CORS:Methods", "OPTIONS,GET,POST,PUT,PATCH,DELETE" }
            };
    }
}