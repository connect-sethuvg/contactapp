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
    public class ContactDetailMapper : APIDataMapper<IContactPageDetails, ContactDetailDTO>
    {
        public ContactDetailMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContactPageDetails ToEntity(ContactDetailDTO value)
        {
            throw new NotImplementedException();
        }

        public override ContactDetailDTO ToObject(IContactPageDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
