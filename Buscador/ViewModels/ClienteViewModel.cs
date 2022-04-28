using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Buscador.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        //public IFormFile FotoCliente { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        [Display(Name = "CPF")]
        public string Documento { get; set; }
        public EnderecoClienteViewModel EnderecoCliente { get; set; }
    }
}
