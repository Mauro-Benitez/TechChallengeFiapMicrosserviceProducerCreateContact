using MassTransit;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
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

        public async Task PublicMessageCreate(CreateContactMessage contact)
        {
            var nomeFila = "create-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageUpdate(UpdateContactMessage contact)
        {
            var nomeFila = "update-contact-queue";
            await EnsureQueueExists(nomeFila, "update-contact-dlx-exchange", "update-contact-dlx");
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(contact);
        }
        public async Task PublicMessageDelete(RemoveContactMessage id)
        {
            var nomeFila = "delete-contact-queue";
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));
            await endpoint.Send(id);
        }

        private async Task EnsureQueueExists(string queueName, string? dlxExchange = null, string? dlxRoutingKey = null)
        {
            var host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "amqp://localhost";
            var factory = new ConnectionFactory() { Uri = new Uri(host) };

            await using var connection = await factory.CreateConnectionAsync(); // 🚀 Uso correto na versão 7.0
            await using var channel = await connection.CreateChannelAsync(); // 🚀 Novo método na versão 7.0

            var arguments = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(dlxExchange) && !string.IsNullOrEmpty(dlxRoutingKey))
            {
                arguments["x-dead-letter-exchange"] = dlxExchange;
                arguments["x-dead-letter-routing-key"] = dlxRoutingKey;
            }

            await channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: arguments);
        }




    }
}
