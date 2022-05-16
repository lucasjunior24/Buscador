using Buscador.Data.Context;
using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;

namespace Buscador.Models.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(BuscadorContext db) : base(db)
        {
        }
    }
}
