using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComparisonTech.API.Feature.MessageBoard;
using ComparisonTech.API.Infrastructure;
using ComparisonTech.Persistence.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ComparisonTech.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ComparisonTech.API", Version = "v1" });
            });

            services.AddTransient<GetMessageBoardHandler>();
            services.AddTransient<CreateMessageBoardHandler>();
            services.AddMvcCore(o => o.Conventions.Add(new AnonymousUserTrackingModelConvention()));
            services.AddSingleton(typeof(IFakeDbContext<>), typeof(FakeDbContext<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ComparisonTech.API");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
