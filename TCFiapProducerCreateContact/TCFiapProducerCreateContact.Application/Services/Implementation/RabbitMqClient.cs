using MassTransit;
using Microsoft.Extensions.Configuration;
using TechChallengeFiap.Messages;

namespace TCFiapProducerCreateContact.Application.Services.Implementation
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public RabbitMqClient(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task PublicMessageCreate(CreateContactMessage contact)
        {
            var nomeFila = _configuration.GetSection("MassTransit")["FilaCreate"] ?? "create-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageUpdate(UpdateContactMessage contact)
        {
            var nomeFila = "update-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageDelete(RemoveContactMessage id)
        {
            var nomeFila = "delete-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(id);
        }

        
    }
}
