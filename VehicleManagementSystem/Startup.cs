using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VehiceManagementSystem.Application.Services;
using VehicleManagementSystem.DataAccess;
using VehicleManagementSystem.Domain.Core.Model.Vehicles;

namespace VehicleManagementSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            this._environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_environment.IsDevelopment())
                services.AddDbContext<VehicleContext>(options =>
                    options
                    .UseInMemoryDatabase(databaseName: "VehicleInMemoryDb")
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging());

            //if (_environment.IsProduction()) // demo purpose
            //{
            //    services.AddDbContext<VehicleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Vehicle")));
            //}

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarService, CarService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehicleManagementSystem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleManagementSystem v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
