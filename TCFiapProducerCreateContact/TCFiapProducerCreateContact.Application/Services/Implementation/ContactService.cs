using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCFiapProducerCreateContact.Application.Inputs;
using TCFiapProducerCreateContact.Core.Entities;

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
            Contact contact = new Contact(
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
            Contact contact = new Contact(
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

    public class RemoveContactMessage
    {
        public Guid ContactId { get; set; }
    }

}
