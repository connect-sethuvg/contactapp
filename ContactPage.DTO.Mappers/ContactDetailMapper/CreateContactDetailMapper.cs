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
            IContactPageDetails entity = this.createEntity();
            entity.hdrId = value.hdrId;
            entity.Id = value.Id;
            entity.Name = value.Name;
            entity.Description = value.Description;
            entity.ActiveStatus = value.ActiveStatus;
            entity.ContactNumber = value.ContactNumber;
            entity.CreatedUserId = value.CreatedUserId;
            return entity;
        }

        public override CreateContactDetailDTO ToObject(IContactPageDetails entity)
        {
            CreateContactDetailDTO value = new ();

            value.Id = entity.Id;
            value.hdrId = entity.hdrId;
            value.Name = entity.Name;
            value.Description = entity.Description;
            value.ActiveStatus = entity.ActiveStatus;
            value.ContactNumber = entity.ContactNumber;
            value.CreatedUserId = entity.CreatedUserId;
            return value;
        }
    }
}
