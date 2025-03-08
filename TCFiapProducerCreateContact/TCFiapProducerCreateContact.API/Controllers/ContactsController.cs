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
        private readonly IContactService _contactService;
        private readonly IConfiguration _configuration;


        public ContactsController(IContactService contactSerrvice, IConfiguration configuration)
        {
            _contactService = contactSerrvice;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] ContactDto contactDto)
        {
            _contactService.CreateContact(contactDto);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ContactDto contactDto)
        {
            _contactService.UpdateContact(contactDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _contactService.DeleteContact(id);
            return Ok();
        }
    }
}
