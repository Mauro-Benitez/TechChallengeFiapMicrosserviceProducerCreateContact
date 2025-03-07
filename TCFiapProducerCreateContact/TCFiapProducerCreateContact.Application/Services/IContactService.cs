using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCFiapProducerCreateContact.Application.Dtos;

namespace TCFiapProducerCreateContact.Application.Services
{
    public interface IContactService
    {
        void CreateContact(ContactDto contactDto);

        void UpdateContact(ContactDto contactDto);

    }
}
