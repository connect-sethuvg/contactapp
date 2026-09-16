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
    public class CreateHeaderMapper : APIDataMapper<IContactPage, CreateContactPageDTO>
    {
        public CreateHeaderMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContactPage ToEntity(CreateContactPageDTO value)
        {
            IContactPage entity = this.createEntity();
            entity.Id = value.id;
            entity.Name = value.Name;
            entity.Email = value.Email;
            entity.ActiveStatus = value.ActiveStatus;
            entity.CreatedUserId = value.CreatedUserId;
            return entity;
        }

        public override CreateContactPageDTO ToObject(IContactPage entity)
        {
            CreateContactPageDTO value = new();
            value.id = entity.Id;
            value.Name = entity.Name;
            value.Email = entity.Email;
            value.ActiveStatus = entity.ActiveStatus;
            value.CreatedUserId = entity.CreatedUserId;
            return value;
        }
    }
}
