using System;

namespace Buscador.Models
{
    public class Perfil : Entity
    {
        public Guid UserId { get; set; }
        public PerfilDeUsuario PerfilDeUsuario { get; set; }

    }
}
