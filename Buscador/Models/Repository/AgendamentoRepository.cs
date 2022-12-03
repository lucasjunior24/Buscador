using Buscador.Data.Context;
using Buscador.Models.Entities;
using Buscador.Models.Interfaces;
using System.Threading.Tasks;

namespace Buscador.Models.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly BuscadorContext Db;

        public AgendamentoRepository(BuscadorContext db)
        {
            Db = db;
        }

        public async Task Create(Agendamento agendamento)
        {
            await Db.AddAsync(agendamento);
            await Db.SaveChangesAsync();
        }
    }
}
