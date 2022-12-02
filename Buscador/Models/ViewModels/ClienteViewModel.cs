using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Buscador.Models.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        [MaxLength(200, ErrorMessage = "Tamanho máximo de 500 caracteres.")]
        public string Nome { get; set; }
        [Display(Name = "Foto do Cliente")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public IFormFile FotoUploadCliente { get; set; }
        public string Foto { get; set; }
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Telefone { get; set; }
        [EmailAddress(ErrorMessage = "Inclua um '@' no endereço de e-mail.")]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Email { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Documento { get; set; }
        public EnderecoClienteViewModel EnderecoCliente { get; set; }
    }
}
