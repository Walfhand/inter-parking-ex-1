using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;
using Infrastructure.Geocoding;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<InterParkingDbContext>(options =>
                options.UseInMemoryDatabase("InterParkingDb"));
            }
            else
            {
                services.AddDbContext<InterParkingDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("InterParkingDb"),
                    b => b.MigrationsAssembly(typeof(InterParkingDbContext).Assembly.FullName)
                    ));
            }

            services.AddScoped<IInterparkingDbContext>(provider => provider.GetService<InterParkingDbContext>());
            services.AddScoped<IGeocodingService, GeocodingService>();

            services.BuildServiceProvider().GetService<InterParkingDbContext>().Database.EnsureCreated();

            return services;
        }
    }
}
