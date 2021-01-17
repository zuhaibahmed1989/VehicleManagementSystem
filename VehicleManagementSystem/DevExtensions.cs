using Microsoft.Extensions.DependencyInjection;

namespace VehicleManagementSystem
{
    public static class DevExtensions
    {
        public static void SetDevCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder => builder
                .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
    }
}