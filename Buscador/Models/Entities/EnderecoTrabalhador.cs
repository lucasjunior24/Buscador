﻿using System;

namespace Buscador.Models.Entitiies
{
    public class EnderecoTrabalhador : Endereco
    {
        public Guid TrabalhadorId { get; set; }
        public Trabalhador Trabalhador { get; set; }
    }
}
