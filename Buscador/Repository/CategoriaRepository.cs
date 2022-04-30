using Buscador.Data.Context;
using Buscador.Interfaces;
using Buscador.Models;

namespace Buscador.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(BuscadorContext db) : base(db)
        {
        }
    }
}
