using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCFiapProducerCreateContact.Core.Entities
{
    public class Contact
    {

        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int DDD { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string Email { get; set; }

        //create
        public Contact(string firstName, string lastName, int Ddd, int phone, string email)
        {
            Id = new Guid();
            FirstName = firstName;
            LastName = lastName;
            DDD = Ddd;
            Phone = phone;
            Email = email;
        }

        //update
        public Contact(Guid id, string firstName, string lastName, int Ddd, int phone, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DDD = Ddd;
            Phone = phone;
            Email = email;
        }
    }
}
