using System.ComponentModel.DataAnnotations;

namespace TCFiapProducerCreateContact.Application.Inputs
{
    public class UpdateContactInputModel
    {
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "O ID é obrigatório.")]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-zÀ-ÿ]{2,50}$", ErrorMessage = "Nome inválido.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-zÀ-ÿ]{2,50}$", ErrorMessage = "Sobrenome inválido.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O endereço de email não é valido")]
        public string Email { get; set; }

        [Required]
        [Range(11, 99, ErrorMessage = "DDD inválido - O DDD deve estar entre 11 ou 99")]
        public int DDD { get; set; }

        [Required]
        [Range(10000000, 999999999, ErrorMessage = "O tamanho do telefone deve ser de 8 a 9 dígitos")]        
        public int Phone { get; set; }
    }
}
