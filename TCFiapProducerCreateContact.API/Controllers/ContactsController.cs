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
            await _contactService.CreateContactAsync(contactInput);
            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContactInputModel contactInput)
        {
            await _contactService.UpdateContactAsync(contactInput);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contactService.DeleteContactAsync(id);
            return Accepted();
        }
    }
}
