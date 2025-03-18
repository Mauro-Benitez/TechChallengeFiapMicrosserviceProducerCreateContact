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

        public void CreateContact(CreateContactInputModel contactInput)
        {
            CreateContactMessage contact = new CreateContactMessage(
                contactInput.FirstName,
                contactInput.LastName,
                contactInput.DDD,
                contactInput.Phone,
                contactInput.Email
                );

            _rabbitMqClient.PublicMessageCreate(contact);
           
        }
       
        public void UpdateContact(UpdateContactInputModel contactInput)
        {
            UpdateContactMessage contact = new UpdateContactMessage(
                contactInput.Id,
                contactInput.FirstName,
                contactInput.LastName,
                contactInput.DDD,
                contactInput.Phone,
                contactInput.Email
                );

            _rabbitMqClient.PublicMessageUpdate(contact);
        }

        public void DeleteContact(Guid id)
        {
            _rabbitMqClient.PublicMessageDelete(new RemoveContactMessage { ContactId = id });
        }
    }
}
