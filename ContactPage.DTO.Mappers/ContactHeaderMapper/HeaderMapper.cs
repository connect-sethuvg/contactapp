using ContactPage.Data.Contracts;
using ContactPage.DTOs.ContactHeader;
using ContactPage.frameworks.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DTO.Mappers.ContactHeaderMapper
{
    public class HeaderMapper : APIDataMapper<IContactPage, ContactPageDTO>
    {
        public HeaderMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContactPage ToEntity(ContactPageDTO value)
        {
            IContactPage entity = this.createEntity();
            entity.Id = value.id;
            entity.Name = value.Name;
            entity.Email = value.Email;
            entity.ActiveStatus = value.ActiveStatus;
            entity.CreatedUserId = value.CreatedUserId;
            entity.EditedUserId = value.EditedUserId;
            entity.CreatedDate = value.CreatedDate;
            entity.EditedDate = value.EditedDate;
            return entity;
        }

        public override ContactPageDTO ToObject(IContactPage entity)
        {
            ContactPageDTO value = new ContactPageDTO();
            value.id = entity.Id;
            value.Name = entity.Name;
            value.Email = entity.Email;
            value.ActiveStatus = entity.ActiveStatus;
            value.CreatedUserId = entity.CreatedUserId;
            value.EditedUserId = entity.EditedUserId;
            value.CreatedDate = entity.CreatedDate;
            value.EditedDate = entity.EditedDate;
            return value;
        }
    }
}
