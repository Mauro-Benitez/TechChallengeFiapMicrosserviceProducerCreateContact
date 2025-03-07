using MassTransit;
using Microsoft.AspNetCore.Mvc;
using TCFiapProducerCreateContact.Application.Dtos;
using TCFiapProducerCreateContact.Application.Services;

namespace TCFiapProducerCreateContact.API.Controllers
{
    [ApiController]
    [Route("[controller]")]      
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactSerrvice;
        private readonly IConfiguration _configuration;


        public ContactsController(IContactService contactSerrvice, IConfiguration configuration)
        {
            _contactSerrvice = contactSerrvice;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] ContactDto contactDto)
        {
             _contactSerrvice.CreateContact(contactDto);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ContactDto contactDto)
        {
            _contactSerrvice.UpdateContact(contactDto);
            return Ok();
        }
    }
}
