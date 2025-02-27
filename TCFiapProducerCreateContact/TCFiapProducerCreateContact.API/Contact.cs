namespace TCFiapProducerCreateContact.API
{
    public class Contact
    {
        public string Nome { get; set; }

         public string Email { get; set; }

        public string Phone { get; set; }

        public Contact(string nome, string email, string address)
        {
            Nome = nome;
            Email = email;
            Phone = address;
        }
    }
}
