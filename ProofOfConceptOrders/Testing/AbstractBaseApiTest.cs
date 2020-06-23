using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProofOfConceptOrders.InvoicingDbContext;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProofOfConceptOrders.Testing
{
    public abstract class AbstractBaseApiTest : IDisposable
    {
        private bool _disposedValue = false;
        protected readonly TestServer _server;

        protected AbstractBaseApiTest()
        {
            var optionBuilder = CreateDbOptionsBuilder();

            SetupContext = new InvoicingContext(optionBuilder.Options);
            SetupContext.Database.EnsureDeleted();
            SetupContext.Database.EnsureCreated();
            AssertContext = new InvoicingContext(optionBuilder.Options);

            _server = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((hostincontext, config) =>
                {
                    config.AddInMemoryCollection();
                })
                .UseEnvironment("Test")
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }

        protected HttpClient Client { get; }
        protected InvoicingContext SetupContext { get; }
        protected InvoicingContext AssertContext { get; }

        public async Task InsertAsync(object entity)
        {
            SetupContext.Add(entity);
            await SetupContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    SetupContext?.Dispose();
                    AssertContext?.Dispose();
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

        protected abstract DbContextOptionsBuilder<InvoicingContext> CreateDbOptionsBuilder();

        protected abstract IServiceCollection AddDb(IServiceCollection services, bool enableLogging);

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information)
                    .AddConsole();
            });
    }
}