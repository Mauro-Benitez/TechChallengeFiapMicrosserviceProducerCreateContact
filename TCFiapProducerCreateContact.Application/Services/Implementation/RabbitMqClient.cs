﻿using MassTransit;
using Microsoft.Extensions.Configuration;
using TechChallenge.SDK.Infrastructure.Message;

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

        public async Task PublicMessageCreateAsync(CreateContactMessage contact)
        {
            var nomeFila = "create-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageUpdateAsync(UpdateContactMessage contact)
        {
            var nomeFila = "update-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageDeleteAsync(RemoveContactMessage id)
        {
            var nomeFila = "delete-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(id);
        }




    }
}
