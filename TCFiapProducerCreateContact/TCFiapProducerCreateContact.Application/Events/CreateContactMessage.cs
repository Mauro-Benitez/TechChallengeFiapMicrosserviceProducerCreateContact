using System.ComponentModel.DataAnnotations;

namespace TechChallengeFiap.Messages
{
    public class CreateContactMessage
    {

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
        public CreateContactMessage(string firstName, string lastName, int Ddd, int phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            DDD = Ddd;
            Phone = phone;
            Email = email;
        }
    }
}
