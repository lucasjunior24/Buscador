using Buscador.Data.Context;
using Buscador.Models.Entities;
using Buscador.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Models.Repository
{
    public class AgendamentoDoClienteRepository : IAgendamentoDoClienteRepository
    {
        private readonly BuscadorContext Db;

        public AgendamentoDoClienteRepository(BuscadorContext db)
        {
            Db = db;
        }
        public async Task<List<Agendamento>> ObterTodosPorClienteId(Guid clienteId)
        {

            var agendamentos = await Db.Agendamentos.AsNoTracking()
                .Include(s => s.Cliente)
                .Include(s => s.Trabalhador)
               .Where(a => a.ClienteId == clienteId).ToListAsync();

            return agendamentos;
        }
    }
}
