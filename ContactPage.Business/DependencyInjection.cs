using ContactPage.Business.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Business
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection Addservice(this IServiceCollection services)
        {
            _ = services.AddScoped<IContactHeaderService, ContactHeaderService>();
            
            return services;

        }
    }
}
