using Microsoft.AspNetCore.Mvc;
using TCFiapProducerCreateContact.Application.Inputs;
using TCFiapProducerCreateContact.Application.Services;

namespace TCFiapProducerCreateContact.API.Controllers
{
    [ApiController]
    [Route("[controller]")]      
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;


        public ContactsController(IContactService contactSerrvice)
        {
            _contactService = contactSerrvice;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactInputModel contactInput)
        {
            _contactService.CreateContact(contactInput);
            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContactInputModel contactInput)
        {
            _contactService.UpdateContact(contactInput);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _contactService.DeleteContact(id);
            return Accepted();
        }
    }
}
