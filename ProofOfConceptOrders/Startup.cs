using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProofOfConceptOrders.Interfaces;
using ProofOfConceptOrders.InvoicingDbContext;
using ProofOfConceptOrders.Providers;

namespace ProofOfConceptOrders
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private const string _connection = @"Server=localhost;Initial Catalog=Invoicing;Integrated Security=true;MultipleActiveResultSets=true;";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOData();
            services.AddScoped<IInvoicingContext, InvoicingContext>();
            services.AddScoped<IGetStockLinesProvider, GetStockLinesProvider>();
            services.AddControllers();
            services.AddDbContext<InvoicingContext>(o => o.UseSqlServer(_connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().Expand().OrderBy().Count().MaxTop(10);
            });
        }
    }
}