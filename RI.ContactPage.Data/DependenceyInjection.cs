using ContactPage.Data.Contracts;
using ContactPage.Data.Entities;
using ContactPage.frameworks;
using ContactPage.frameworks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RI.ContactPage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Data
{
    public static partial class DependenceyInjection
    {
        public static IServiceCollection AddEntities(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ContactPageContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            _ = services.AddTransient<IContactPage, ContactHeader>();
            _ = services.AddTransient<IContactPageDetails, ContactDetails>();

            return services;
        }

    }
}
