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
    public class DetailMapper : APIDataMapper<IContactPageDetails, ContactDetailDTO>
    {
        public DetailMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContactPageDetails ToEntity(ContactDetailDTO value)
        {
            IContactPageDetails entity = this.createEntity();
            entity.Id = value.Id;
            entity.hdrId = value.hdrId;
            entity.Name = value.Name;
            entity.Description = value.Description;
            entity.ActiveStatus = value.ActiveStatus;
            entity.ContactNumber = value.ContactNumber;
            entity.CreatedUserId = value.CreatedUserId;
            entity.EditedUserId = value.EditedUserId;
            entity.CreatedDate = value.CreatedDate;
            entity.EditedDate = value.EditedDate;
            return entity;
        }

        public override ContactDetailDTO ToObject(IContactPageDetails entity)
        {
            ContactDetailDTO value = new();
            value.Id = entity.Id;
            value.hdrId = entity.hdrId;
            value.Name = entity.Name;
            value.Description = entity.Description;
            value.ActiveStatus = entity.ActiveStatus;
            value.ContactNumber = entity.ContactNumber;
            value.CreatedUserId = entity.CreatedUserId;
            value.EditedUserId = entity.EditedUserId;
            value.CreatedDate = entity.CreatedDate;
            value.EditedDate = entity.EditedDate;
            return value;

        }
    }
}
