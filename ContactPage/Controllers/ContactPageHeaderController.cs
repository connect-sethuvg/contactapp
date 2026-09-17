using ContactPage.Business.Contracts;
using ContactPage.DTOs;
using ContactPage.DTOs.ContactHeader;
using ContactPage.frameworks.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPageHeaderController : ControllerBase
    {
        IContactHeaderService _contactHeaderService;

        public ContactPageHeaderController(IContactHeaderService contactHeader)
        {
            _contactHeaderService = contactHeader;
        }

        [HttpPost]
        [Route("CreateContactHeader")]
        public async Task<ActionResult> CreateContactHeader(CreateContactPageDTO Entities)
        {
            try
            {
                ActionStatus<ContactPageDTO> result = await _contactHeaderService.CreateContactHeaderService(Entities);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully Created Contacts");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("Exception occurred at CreateContactHeader")));

                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("Error occurred at CreateContactHeader ")));
            }
        }
        [HttpPost]
        [Route("EditContactHeader")]
        public async Task<ActionResult> EditContactHeader(EditContactPageDTO data)
        {
            try
            {
                ActionStatus<ContactPageDTO> result = await _contactHeaderService.EditContactHeaderService(data);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully Edited Contacts");
                    return Ok(result);

                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM(" Exception occurred at EditContactHeader")));
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM(" Error occurred at EditContactHeader")));
            }
        }
        [HttpGet]
        [Route("GetContactHeaderbyid")]
        public async Task<ActionResult> GetContactHeaderbyid(long id)
        {
            try
            {
                ActionStatus<ContactPageDTO> result = await _contactHeaderService.GetContactHeaderbyid(id);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully fetched Contacts");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("Exception occurred at GetContactHeaderbyid")));
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("Error occurre at GetContactHeaderbyid")));
            }
        }
        [HttpGet]
        [Route("DeleteContactHeaderofId")]
        public async Task<ActionResult> DeleteContactHeaderofId(long id)
        {
            try
            {
                ActionStatus<ContactPageDTO> result = await _contactHeaderService.DeleteContactHeaderofId(id);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully Deleted Contacts");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("Exception occurred at DeleteContactHeaderofId")));
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("Error occurre at DeleteContactHeaderofId")));

            }
        }
        [HttpPost]
        [Route("GetContactPagePagination")]
        public async Task<ActionResult> GetContactPagePagination(PaginationParams paginationParams)
        {
            try
            {
                ActionStatus<List<ContactPageDTO>> result = await _contactHeaderService.GetContactPagePagination(paginationParams);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully Fetched Data");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("Exception occurred at GetContactPagePagination")));
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("Error occurre at GetContactPagePagination")));
            }
        }
        [HttpGet]
        [Route("DeactivateContactHeaderofId")]
        public async Task<ActionResult> DeactivateContactHeaderofId(long id)
        {
            try
            {
                ActionStatus<ContactPageDTO> result = await _contactHeaderService.DeactivateContactHeaderofId(id);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully Deleted Contacts");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("Exception occurred at DeactivateContactHeaderofId")));
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("Error occurre at DeactivateContactHeaderofId")));

            }
        }
        [HttpGet]
        [Route("ActivateContactHeaderofId")]
        public async Task<ActionResult> ActivateContactHeaderofId(long id)
        {
            try
            {
                ActionStatus<ContactPageDTO> result = await _contactHeaderService.ActivateContactHeaderofId(id);
                if (result)
                {
                    result.Response = new ResponseVM("Successfully Deleted Contacts");
                    return Ok(result);
                }
                else if (result.HasException)
                {
                    return StatusCode(500, new ActionStatus(new ResponseVM("Exception occurred at ActivateContactHeaderofId")));
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ActionStatus(new ResponseVM("Error occurre at ActivateContactHeaderofId")));

            }
        }
    }
}
