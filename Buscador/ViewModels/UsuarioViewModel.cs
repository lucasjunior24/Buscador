using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Buscador.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Campo {0} Obrigatório")]
        [EmailAddress(ErrorMessage = "Inclua um '@' no endereço de e-mail.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo {0} Obrigatório")]
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }
        public SelectList Perfils { get; set; }

        [Required(ErrorMessage = "Campo {0} Obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Campo {0} Obrigatório")]
        [Compare("Password", ErrorMessage = "As senhas precisam ser iguais")]
        public string ConfirmPassword { get; set; }
    }
}
