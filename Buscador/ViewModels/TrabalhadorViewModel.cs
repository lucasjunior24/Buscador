using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.ViewModels
{
    public class TrabalhadorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IFormFile FotoTrabalhador { get; set; }
        public string Foto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public int TipoDeTrabalhador { get; set; }
        public TipoDeServicoViewModel TipoDeServico { get; set; }
        public EnderecoTrabalhadorViewModel EnderecoTrabalhador { get; set; }
        public string Profissao { get; set; }

    }
}
