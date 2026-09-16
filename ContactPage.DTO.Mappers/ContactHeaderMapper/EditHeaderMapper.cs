using ContactPage.Data.Contracts;
using ContactPage.DTOs.ContactHeader;
using ContactPage.frameworks.Mappers;

namespace ContactPage.DTO.Mappers.ContactHeaderMapper
{
    internal class EditHeaderMapper : APIDataMapper<IContactPage, EditContactPageDTO>
    {
        public EditHeaderMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContactPage ToEntity(EditContactPageDTO value)
        {
            IContactPage entity = this.createEntity();
            entity.Id = value.id;
            entity.Name = value.Name;
            entity.Email = value.Email;
            entity.ActiveStatus = value.ActiveStatus;
            entity.EditedUserId = value.EditedUserId;
            return entity;
        }

        public override EditContactPageDTO ToObject(IContactPage entity)
        {
            EditContactPageDTO value = new();
            value.id = entity.Id;
            value.Name = entity.Name;
            value.Email = entity.Name;
            value.ActiveStatus = entity.ActiveStatus;
            value.EditedUserId = entity.EditedUserId;
            return value;
        }
    }
}