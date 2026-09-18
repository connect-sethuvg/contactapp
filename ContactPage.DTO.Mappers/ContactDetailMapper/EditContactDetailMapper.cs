using ContactPage.Data.Contracts;
using ContactPage.DTOs.ContactDetail;
using ContactPage.DTOs.ContactHeader;
using ContactPage.frameworks.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.DTO.Mappers.ContactDetailMapper
{
    public class EditContactDetailMapper : APIDataMapper<IContactPageDetails, EditContactDetailDTO>
    {
        public EditContactDetailMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContactPageDetails ToEntity(EditContactDetailDTO value)
        {
            IContactPageDetails entity = this.createEntity();
            entity.Id = value.id;
            entity.hdrId = value.hdrId;
            entity.ActiveStatus = value.ActiveStatus;
            entity.Name = value.Name;
            entity.ContactNumber = value.ContactNumber;
            entity.Description = value.Description;
            entity.EditedUserId = value.EditedUserId;
            return entity;
        }

        public override EditContactDetailDTO ToObject(IContactPageDetails entity)
        {
            EditContactDetailDTO value = new();
            value.id = entity.Id;
            value.hdrId = entity.hdrId;
            value.Name = entity.Name;
            value.ContactNumber = entity.ContactNumber;
            value.Description = entity.Description;
            value.EditedUserId = entity.EditedUserId;
            value.ContactNumber= entity.ContactNumber;
            value.ActiveStatus = entity.ActiveStatus;
            return value;
        }
    }
}
