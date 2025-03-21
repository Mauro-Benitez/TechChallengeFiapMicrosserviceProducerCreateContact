using TechChallenge.SDK.Infrastructure.Message;

namespace TCFiapProducerCreateContact.Application.Services
{
    public interface IRabbitMqClient
    {
        Task PublicMessageCreateAsync(CreateContactMessage contact);

        Task PublicMessageUpdateAsync(UpdateContactMessage contact);

        Task PublicMessageDeleteAsync(RemoveContactMessage id);

    }
}
