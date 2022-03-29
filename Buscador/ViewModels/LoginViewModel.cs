using System.ComponentModel.DataAnnotations;

namespace Buscador.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Inclua um '@' no endereço de e-mail.")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Password { get; set; }

        [Display(Name = "Esqueceu a Senha?")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public bool RememberMe { get; set; }
    }
}
