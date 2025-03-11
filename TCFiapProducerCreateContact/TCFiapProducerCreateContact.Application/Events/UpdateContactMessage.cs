using System.ComponentModel.DataAnnotations;

namespace TechChallengeFiap.Messages
{
    public class UpdateContactMessage
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

        public UpdateContactMessage(Guid id, string firstName, string lastName, int Ddd, int phone, string email)
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
