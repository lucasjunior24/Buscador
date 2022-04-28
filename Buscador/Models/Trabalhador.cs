using System;
using System.Collections.Generic;

namespace Buscador.Models
{
    public class Trabalhador : Usuario
    {
        public string Documento { get; set; }
        public TipoDeTrabalhador TipoDeTrabalhador { get; set; }
        public TipoDeServico TipoDeServico { get; set; }
        public EnderecoTrabalhador EnderecoTrabalhador { get; set; }
        public List<Solicitacao> Solicitacao { get; set; }
        public string Profissao { get; set; }
        public bool Solicitado { get; private set; }
        public bool Disponivel { get; private set; }
        public string TempoExperiencia { get; set; }
        public string Descricao { get; set; }
        public string CursoOuFormaçao { get; set; }
        public void SolicitarTrabalhador()
        {
            Solicitado = true;
        }

    }
}
