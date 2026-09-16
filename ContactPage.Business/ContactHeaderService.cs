using ContactPage.Business.Contracts;
using ContactPage.Data.Contracts;
using ContactPage.DataService.Contracts;
using ContactPage.DTOs.ContactHeader;
using ContactPage.frameworks.Extension;
using ContactPage.frameworks.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.Business
{
    public class ContactHeaderService : IContactHeaderService
    {
        private readonly APIDataMapper<IContactPage, ContactPageDTO> _contactHeadermapper;
        private readonly APIDataMapper<IContactPage, CreateContactPageDTO> _createcontactHeadermapper;
        private readonly APIDataMapper<IContactPage, EditContactPageDTO> _editcontactHeaderMapper;
        private readonly IContactHeaderDataService _contactHeaderDataService;

        public ContactHeaderService(
            APIDataMapper<IContactPage, ContactPageDTO> contactHeadermapper,
            APIDataMapper<IContactPage, CreateContactPageDTO> createcontactHeadermapper,
            APIDataMapper<IContactPage, EditContactPageDTO> editcontactHeaderMapper,
            IContactHeaderDataService contactHeaderDataService
            )
        {
            _contactHeadermapper = contactHeadermapper;
            _contactHeaderDataService = contactHeaderDataService;
            _createcontactHeadermapper = createcontactHeadermapper;
            _editcontactHeaderMapper = editcontactHeaderMapper;
        }

        public async Task<ActionStatus<ContactPageDTO>> CreateContactHeaderService(CreateContactPageDTO entities)
        {
            try
            {
                IContactPage result = _createcontactHeadermapper.ToEntity(entities);
                ActionStatus<IContactPage> data = await _contactHeaderDataService.CreateContactHeader(result);
                if (data)
                {
                    ContactPageDTO response = _contactHeadermapper.ToObject(data.Result);
                    return new ActionStatus<ContactPageDTO>(true, response, 1);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at CreateContactHeader"));
                }
                return new ActionStatus<ContactPageDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at CreateContactHeader"));
            }
        }

        public async Task<ActionStatus<ContactPageDTO>> EditContactHeaderService(EditContactPageDTO data)
        {
            try
            {
                IContactPage result = _editcontactHeaderMapper.ToEntity(data);
                ActionStatus<IContactPage> Res = await _contactHeaderDataService.EditContactHeaderDataService(result);
                if (Res)
                {
                    ContactPageDTO response = _contactHeadermapper.ToObject(Res.Result);
                    return new ActionStatus<ContactPageDTO>(true, response, 1);
                }
                else if (Res.HasException)
                {
                    return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at EditContactHeaderService"));
                }
                return new ActionStatus<ContactPageDTO>(Res.Response);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at EditContactHeaderService"));
            }

        }
        
    }
}
