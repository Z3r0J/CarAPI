using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarAPI.Core.Application.Interfaces.Services;
using CarAPI.Core.Application.Services;

namespace CarAPI.Core.Application
{
    public static class ServicesRegistration
    {
        public static void ApplicationServices(this IServiceCollection service){

            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddTransient(typeof(IGenericServices<,,>), typeof(GenericServices<,,>));
        
        }
    }
}
