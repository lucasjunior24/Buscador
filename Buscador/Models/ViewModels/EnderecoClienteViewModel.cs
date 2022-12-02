using System;
using System.ComponentModel.DataAnnotations;

namespace Buscador.Models.ViewModels
{
    public class EnderecoClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Rua")]
        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        [MaxLength(4, ErrorMessage = "Tamanho máximo de 4 caracteres")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Complemento { get; set; }
        public string Cep { get; set; }
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Campo '{0}' Obrigatório")]
        public string Estado { get; set; }
        public Guid ClienteId { get; set; }
    }
}
