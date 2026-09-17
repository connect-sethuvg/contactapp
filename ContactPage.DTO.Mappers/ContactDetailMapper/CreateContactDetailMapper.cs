using ContactPage.Data.Contracts;
using ContactPage.DTOs.ContactHeaderDetail;
using ContactPage.frameworks.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DTO.Mappers.ContactDetailMapper
{
    public class CreateContactDetailMapper : APIDataMapper<IContactPageDetails, CreateContactDetailDTO>
    {
        public CreateContactDetailMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContactPageDetails ToEntity(CreateContactDetailDTO value)
        {
            throw new NotImplementedException();
        }

        public override CreateContactDetailDTO ToObject(IContactPageDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
