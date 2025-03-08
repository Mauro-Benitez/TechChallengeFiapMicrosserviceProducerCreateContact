using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCFiapProducerCreateContact.Application.Dtos;
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

        public void CreateContact(ContactDto contactDto)
        {
            Contact contact = new Contact(contactDto.Name, contactDto.Email,contactDto.Phone);

            _rabbitMqClient.PublicMessageCreate(contact);
           
        }
       
        public void UpdateContact(ContactDto contactDto)
        {
            Contact contact = new Contact(contactDto.Name, contactDto.Email, contactDto.Phone);

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
