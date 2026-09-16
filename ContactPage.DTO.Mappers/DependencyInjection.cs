using ContactPage.Data.Contracts;
using ContactPage.DTO.Mappers.ContactHeaderMapper;
using ContactPage.DTOs.ContactHeader;
using ContactPage.frameworks.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DTO.Mappers
{
    public static partial class DependencyInjection
    {

        public static IServiceCollection AddDTOMapper(this IServiceCollection services)
        {
            services.AddScoped<APIDataMapper<IContactPage, ContactPageDTO>, HeaderMapper>();
            services.AddScoped<APIDataMapper<IContactPage, CreateContactPageDTO>, CreateHeaderMapper>();
            services.AddScoped<APIDataMapper<IContactPage, EditContactPageDTO>, EditHeaderMapper>();


            return services;
        }

    }
}
