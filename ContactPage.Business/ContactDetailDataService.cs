using ContactPage.Business.Contracts;
using ContactPage.Data.Contracts;
using ContactPage.DataService.Contracts;
using ContactPage.DTOs;
using ContactPage.DTOs.ContactDetail;
using ContactPage.DTOs.ContactHeader;
using ContactPage.DTOs.ContactHeaderDetail;
using ContactPage.frameworks.Extension;
using ContactPage.frameworks.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactPage.Business
{
    public class ContactDetailDataService : IContactHeaderDetailService
    {
        public readonly APIDataMapper<IContactPageDetails, ContactDetailDTO> _contactDetailMapper;
        public readonly APIDataMapper<IContactPageDetails, CreateContactDetailDTO> _createDetailMapper;
        public readonly APIDataMapper<IContactPageDetails, EditContactDetailDTO> _editDetailMapper;
        public readonly IContactDetailsDataService _contactDetailsDataService;

        public ContactDetailDataService(
            APIDataMapper<IContactPageDetails, ContactDetailDTO> contactDetailMapper,
            APIDataMapper<IContactPageDetails, CreateContactDetailDTO> createDetailMapper,
            APIDataMapper<IContactPageDetails, EditContactDetailDTO> editDetailMapper,
        IContactDetailsDataService contactDetailsDataService

            )
        {
            _contactDetailMapper = contactDetailMapper;
            _createDetailMapper = createDetailMapper;
            _contactDetailsDataService = contactDetailsDataService;
            _editDetailMapper = editDetailMapper;

        }

        public async Task<ActionStatus<ContactDetailDTO>> CreateContactDetail(CreateContactDetailDTO dto)
        {
            try
            {
                IContactPageDetails details = _createDetailMapper.ToEntity(dto);
                ActionStatus<IContactPageDetails> result = await _contactDetailsDataService.CreateContactDetail(details);
                if (result)
                {
                    ContactDetailDTO response = _contactDetailMapper.ToObject(result.Result);
                    return new ActionStatus<ContactDetailDTO>(true, response, 1);
                }
                else if (result.HasException)
                {
                    return new ActionStatus<ContactDetailDTO>(new ResponseVM(" Business layer Exception at CreateContactHeader: "+ result.HasException));
                }
                return new ActionStatus<ContactDetailDTO>(result);
            }
            catch (Exception ex) 
            {
                return new ActionStatus<ContactDetailDTO>(new ResponseVM(" Data Exception occurred at CreateContactHeader"));
            }
        }

        public async Task<ActionStatus<ContactDetailDTO>> DeleteContactDetail(long id)
        {
            try
            {
                ActionStatus<IContactPageDetails> data = await _contactDetailsDataService.DeactivateContactHeaderofId(id);
                if (data)
                {
                    ContactDetailDTO response = _contactDetailMapper.ToObject(data.Result);
                    return new ActionStatus<ContactDetailDTO>(true, response, 1);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDetailDTO>(new ResponseVM("Data Exception occurred at DeleteContactDetail"));
                }
                return new ActionStatus<ContactDetailDTO>(data);

            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDetailDTO>(new ResponseVM("Exception occurred at DeleteContactDetail"));

            }
            ;
        }

        public async Task<ActionStatus<ContactDetailDTO>> EditContactDetail(EditContactDetailDTO dto)
        {
            try
            {
                IContactPageDetails details = _editDetailMapper.ToEntity(dto);
                ActionStatus<IContactPageDetails> result = await _contactDetailsDataService.EditContactDetail(details);
                if (result)
                {
                    ContactDetailDTO response = _contactDetailMapper.ToObject(result.Result);
                    return new ActionStatus<ContactDetailDTO>(true, response, 1);
                }
                else if (result.HasException)
                {
                    return new ActionStatus<ContactDetailDTO>(new ResponseVM(" Business layer Exception at EditContactDetail: " + result.HasException));
                }
                return new ActionStatus<ContactDetailDTO>(result);

            }
            catch(Exception ex)
            {
                return new ActionStatus<ContactDetailDTO>(new ResponseVM(" Data Exception occurred at EditContactDetail"));

            }
        }

        public async Task<ActionStatus<List<ContactDetailDTO>>> GetContactDetailPagePagination(PaginationParams paginationParams)
        {
            try
            {

                ActionStatus<List<IContactPageDetails>> result = await _contactDetailsDataService.GetContactDetailPagePagination(paginationParams);
                if (result)
                {
                    List<ContactDetailDTO> response = _contactDetailMapper.ToObjects(result.Result).ToList();
                    return new ActionStatus<List<ContactDetailDTO>>(true, response, response.Count);
                }
                else if (result.HasException)
                {
                    return new ActionStatus<List<ContactDetailDTO>>(new ResponseVM("Data Exception occurred at GetContactDetailPagePagination"));
                }
                return new ActionStatus<List<ContactDetailDTO>>(result.Response);


            }
            catch(Exception ex)
            {
                return new ActionStatus<List<ContactDetailDTO>>(new ResponseVM(" Data Exception occurred at GetContactDetailPagePagination"));

            }
        }
    }
}
