using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCFiapProducerCreateContact.Core.Entities;

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

        public async Task PublicMessageCreate(Contact contact)
        {
            var nomeFila = _configuration.GetSection("MassTransit")["FilaCreate"] ?? "create-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageUpdate(Contact contact)
        {
            var nomeFila = _configuration.GetSection("MassTransit")["FilaUpdate"] ?? "update-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageDelete(RemoveContactMessage id)
        {
            var nomeFila = _configuration.GetSection("MassTransit")["FilaDelete"] ?? "delete-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(id);
        }

        
    }
}
