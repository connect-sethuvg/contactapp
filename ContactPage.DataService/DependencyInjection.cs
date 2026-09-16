using ContactPage.DataService.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DataService
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddDataService(this IServiceCollection services)
        {
            _ = services.AddScoped<IContactHeaderDataService, ContactHeaderDataService>();

            return services;
        }
    }
}
