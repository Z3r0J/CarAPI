using CarAPI.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarAPI.Infrastructure.Persistance
{
    public static class ServicesRegistration
    {
        public static void ServicesPersistance(this IServiceCollection service, IConfiguration configuration)
        {
            #region Contexts

            if (configuration.GetValue<bool>("UseInMemoryDatabase")) {
                service.AddDbContext<ApplicationContext>(options => options
                .UseInMemoryDatabase("CarDatabase"));
            }

            else { 
                service.AddDbContext<ApplicationContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("CarConnection"), m => m
                .MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion
        }
    }
}
