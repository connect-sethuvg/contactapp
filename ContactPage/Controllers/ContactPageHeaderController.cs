using ContactPage.Business.Contracts;
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

    }
}
