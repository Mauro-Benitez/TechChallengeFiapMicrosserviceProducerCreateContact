using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCFiapProducerCreateContact.Application.Inputs;

namespace TCFiapProducerCreateContact.Application.Services
{
    public interface IContactService
    {
        void CreateContact(CreateContactInputModel contactInput);

        void UpdateContact(UpdateContactInputModel contactInput);

        void DeleteContact(Guid id);

    }
}
