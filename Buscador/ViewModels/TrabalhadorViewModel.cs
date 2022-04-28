using Microsoft.AspNetCore.Http;
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
        public IFormFile FotoUpload { get; set; }
        public string Foto { get; set; }
        public string FraseBio { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        [Display(Name = "CPF")]
        public string Documento { get; set; }
        public bool Solicitado { get; set; }
        public string SolicitadoMap { get; set; }
        [Display(Name = "Tipo de Trabalhador")]
        public string TipoDeTrabalhador { get; set; }
        public TipoDeServicoViewModel TipoDeServico { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]

        [Display(Name = "Seus cursos ou sua Formação profissional")]
        public string CursoOuFormaçao { get; set; }
        public EnderecoTrabalhadorViewModel EnderecoTrabalhador { get; set; }
        public string Profissao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [Display(Name = "Tempo de experiencia")]
        public string TempoExperiencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public SelectList TiposDeTrabalhadores { get; set; }

    }
}
