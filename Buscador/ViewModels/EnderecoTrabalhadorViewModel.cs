using System;
using System.ComponentModel.DataAnnotations;

namespace Buscador.ViewModels
{
    public class EnderecoTrabalhadorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Rua")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid TrabalhadorId { get; set; }
    }
}
