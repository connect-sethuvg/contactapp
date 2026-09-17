using ContactPage.Business.Contracts;
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

        //[HttpPost]
        //[Route("CreateContactHeaderDetail")]
        //public Task<ActionResult> CreateContactHeaderDetail (H)




    }
}
