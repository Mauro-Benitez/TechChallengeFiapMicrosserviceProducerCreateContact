using TCFiapProducerCreateContact.Application.Inputs;
using TechChallenge.SDK.Infrastructure.Message;

namespace TCFiapProducerCreateContact.Application.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IRabbitMqClient _rabbitMqClient;

        public ContactService(IRabbitMqClient rabbitMqClient)
        {
            _rabbitMqClient = rabbitMqClient;
        }

        public async Task CreateContactAsync(CreateContactInputModel contactInput)
        {
            CreateContactMessage contact = new CreateContactMessage(
                contactInput.FirstName,
                contactInput.LastName,
                contactInput.DDD,
                contactInput.Phone,
                contactInput.Email
                );

            await _rabbitMqClient.PublicMessageCreateAsync(contact);
           
        }
       
        public async Task UpdateContactAsync(UpdateContactInputModel contactInput)
        {
            UpdateContactMessage contact = new UpdateContactMessage(
                contactInput.Id,
                contactInput.FirstName,
                contactInput.LastName,
                contactInput.DDD,
                contactInput.Phone,
                contactInput.Email
                );

            await _rabbitMqClient.PublicMessageUpdateAsync(contact);
        }

        public async Task DeleteContactAsync(Guid id)
        {
            await _rabbitMqClient.PublicMessageDeleteAsync(new RemoveContactMessage { ContactId = id });
        }
    }
}
