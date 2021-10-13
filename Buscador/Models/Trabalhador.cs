namespace Buscador.Models
{
    public class Trabalhador : Usuario
    {
        public string Documento { get; set; }
        public TipoDeTrabalhador TipoDeTrabalhador { get; set; }
        public TipoDeServico TipoDeServico { get; set; }
        public EnderecoTrabalhador EnderecoTrabalhador { get; set; }
        public string Profissao { get; set; }
        public bool Solicitado { get; set; }
    }
}
