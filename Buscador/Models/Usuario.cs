﻿namespace Buscador.Models
{
    public abstract class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}
