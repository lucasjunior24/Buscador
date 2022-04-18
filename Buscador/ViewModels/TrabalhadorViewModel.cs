using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Buscador.ViewModels
{
    public class TrabalhadorViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Nome { get; set; }
        //public IFormFile FotoTrabalhador { get; set; }
        public string Foto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public bool Solicitado { get; set; }
        public string SolicitadoMap { get; set; }
        [Display(Name = "Tipo de Trabalhador")]
        public string TipoDeTrabalhador { get; set; }
        public TipoDeServicoViewModel TipoDeServico { get; set; }
        public EnderecoTrabalhadorViewModel EnderecoTrabalhador { get; set; }
        public string Profissao { get; set; }

        public SelectList TiposDeTrabalhadores { get; set; }

    }
}
