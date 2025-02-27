using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace TCFiapProducerCreateContact.API.Controllers
{
    [ApiController]
    [Route("[controller]")]      
    public class ContactsController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public ContactsController(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var nomeFila = _configuration.GetSection("MassTransit")["NomedaFila"] ?? "create-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(new Contact("Mauro","mauro@email.com","119999999"));
            return Ok();
        }
    }
}
