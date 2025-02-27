using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCFiapProducerCreateContact.Core.ValueObjects;

namespace TCFiapProducerCreateContact.Core.Entities
{
    public class Contact
    {
     
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
