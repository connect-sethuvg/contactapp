using ContactPage.Business;
using ContactPage.Business.Contracts;
using ContactPage.DTOs;
using ContactPage.DTOs.ContactDetail;
using ContactPage.DTOs.ContactHeader;
using ContactPage.DTOs.ContactHeaderDetail;
using ContactPage.frameworks.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPageDetailsController : ControllerBase
    {

        IContactHeaderDetailService _contactHeaderDetailService;

        public ContactPageDetailsController(IContactHeaderDetailService contactHeaderDetailService)
        {
            _contactHeaderDetailService = contactHeaderDetailService;
        }

        [HttpPost]
        [Route("CreateContactDetail")]
        public async Task<ActionResult> CreateContactDetail(CreateContactDetailDTO dto)
        {
            try
            {
                ActionStatus<ContactDetailDTO> result = await _contactHeaderDetailService.CreateContactDetail(dto);

                if (result != null)
                {
                    result.Response = new ResponseVM("Successfully Created Contact!");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("CreateContactHeaderDetail Exception: " + result.Exception)));

                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(100, new ActionStatus(new ResponseVM("Exception occurred at CreateContactHeaderDetail API")));

            }
        }

        [HttpPost]
        [Route("EditContactDetail")]
        public async Task<ActionResult> EditContactDetail(EditContactDetailDTO dto)
        {
            try
            {
                ActionStatus<ContactDetailDTO> result = await _contactHeaderDetailService.EditContactDetail(dto);

                if (result != null && result.IsSuccess == true)
                {
                    result.Response = new ResponseVM("Successfully Edited ContactDetail!");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("EditContactDetail Exception: " + result.Exception)));
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(100, new ActionStatus(new ResponseVM("Exception occurred at EditContactDetail API")));
            }
        }

        [HttpPost]
        [Route("GetContactDetailPagePagination")]
        public async Task<ActionResult> GetContactDetailPagePagination(PaginationParams paginationParams)
        {
            try
            {
                ActionStatus<List<ContactDetailDTO>> result = await _contactHeaderDetailService.GetContactDetailPagePagination(paginationParams);

                if (result != null && result.IsSuccess == true)
                {
                    result.Response = new ResponseVM("Successfully Edited GetContactDetailPagePagination!");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("GetContactDetailPagePagination Exception: " + result.Exception)));
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(100, new ActionStatus(new ResponseVM("Exception occurred at GetContactDetailPagePagination API")));
            }
        }
        [HttpGet]
        [Route("DeleteContactDetail")]
        public async Task<ActionResult> DeleteContactDetail(long id)
        {
            try
            {
                ActionStatus<ContactDetailDTO> result = await _contactHeaderDetailService.DeleteContactDetail(id);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully Deleted Contacts");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("Exception occurred at DeleteContactDetail")));
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("Error occurre at DeleteContactDetail")));

            }
        }




    }
}
