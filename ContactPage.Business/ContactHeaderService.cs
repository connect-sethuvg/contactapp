using ContactPage.Business.Contracts;
using ContactPage.Data.Contracts;
using ContactPage.DataService.Contracts;
using ContactPage.DTOs;
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

        public async Task<ActionStatus<ContactPageDTO>> ActivateContactHeaderofId(long id)
        {
            try
            {
                ActionStatus<IContactPage> data = await _contactHeaderDataService.ActivateContactHeaderofId(id);
                if (data)
                {
                    ContactPageDTO response = _contactHeadermapper.ToObject(data.Result);
                    return new ActionStatus<ContactPageDTO>(true, response, 1);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactPageDTO>(new ResponseVM("Data Exception occurred at ActivateContactHeaderofId"));
                }
                return new ActionStatus<ContactPageDTO>(data);

            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at ActivateContactHeaderofId"));

            }
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
                    return new ActionStatus<ContactPageDTO>(new ResponseVM(" Data Exception occurred at CreateContactHeader"));
                }
                return new ActionStatus<ContactPageDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at CreateContactHeader"));
            }
        }

        public async Task<ActionStatus<ContactPageDTO>> DeactivateContactHeaderofId(long id)
        {
            try
            {
                ActionStatus<IContactPage> data = await _contactHeaderDataService.DeactivateContactHeaderofId(id);
                if (data)
                {
                    ContactPageDTO response = _contactHeadermapper.ToObject(data.Result);
                    return new ActionStatus<ContactPageDTO>(true, response, 1);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactPageDTO>(new ResponseVM("Data Exception occurred at DeactivateContactHeaderofId"));
                }
                return new ActionStatus<ContactPageDTO>(data);

            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at DeactivateContactHeaderofId"));

            }
        }

        public async Task<ActionStatus<ContactPageDTO>> DeleteContactHeaderofId(long id)
        {
            try
            {
                ActionStatus<IContactPage> data = await _contactHeaderDataService.DeleteContactHeaderofId(id);
                if (data)
                {
                    ContactPageDTO response = _contactHeadermapper.ToObject(data.Result);
                    return new ActionStatus<ContactPageDTO>(true, response, 1);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactPageDTO>(new ResponseVM("Data Exception occurred at DeleteContactHeaderofId"));
                }
                return new ActionStatus<ContactPageDTO>(data);

            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at DeleteContactHeaderofId"));

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
                    return new ActionStatus<ContactPageDTO>(new ResponseVM("Data Exception occurred at EditContactHeaderService"));
                }
                return new ActionStatus<ContactPageDTO>(Res.Response);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at EditContactHeaderService"));
            }
        }
        public async Task<ActionStatus<ContactPageDTO>> GetContactHeaderbyid(long id)
        {
            try
            {
                ActionStatus<IContactPage> IdResult = await _contactHeaderDataService.GetContactHeaderbyid(id);
                if (IdResult)
                {
                    ContactPageDTO response = _contactHeadermapper.ToObject(IdResult.Result);
                    return new ActionStatus<ContactPageDTO>(true, response, 1);

                }
                else if (IdResult.HasException)
                {
                    return new ActionStatus<ContactPageDTO>(new ResponseVM("Data Exception occurred at EditContactHeaderService"));
                }
                return new ActionStatus<ContactPageDTO>(IdResult.Response);

            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactPageDTO>(new ResponseVM("Exception occurred at GetContactHeaderbyid"));
            }
        }

        public async Task<ActionStatus<List<ContactPageDTO>>> GetContactPagePagination(PaginationParams paginationParams)
        {
            try
            {
                ActionStatus<List<IContactPage>> result = await _contactHeaderDataService.GetContactPagePagination(paginationParams);
                if (result)
                {
                    List<ContactPageDTO> response =  _contactHeadermapper.ToObjects(result.Result).ToList();
                    return new ActionStatus<List<ContactPageDTO>>(true, response, response.Count);
                }
                else if (result.HasException)
                {
                    return new ActionStatus<List<ContactPageDTO>>(new ResponseVM("Data Exception occurred at GetContactPagePagination"));
                }
                return new ActionStatus<List<ContactPageDTO>>(result.Response);
            }
            catch (Exception ex)
            {
                return new ActionStatus<List<ContactPageDTO>>(new ResponseVM("Exception occurred at GetContactPagePagination"));
            }
        }
    }
}
