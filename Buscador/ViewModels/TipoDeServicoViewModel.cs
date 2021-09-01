using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.ViewModels
{
    public class TipoDeServicoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TrabalhadorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeDoServico { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Serviço")]
        //public IFormFile ImagemUpload { get; set; }        //public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }
        public string AreaProfissional { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public TrabalhadorViewModel Trabalhador { get; set; }
    }
}
