using AutoMapper;
using Buscador.Models.Entities;
using Buscador.Models.Interfaces;
using Buscador.Models.Repository;
using Buscador.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class AgendamentoController : BaseController
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper _mapper;
        public AgendamentoController(IAgendamentoRepository agendamentoRepository, UserManager<IdentityUser> userManager, IClienteRepository clienteRepository, IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            this.userManager = userManager;
            this.clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgendamentoViewModel agendamentoVM)
        {
            var id = userManager.GetUserId(User);
            var userId = Guid.Parse(id);
            var cliente = await clienteRepository.ObterClienteEnderecoPorUserId(userId);
            if (User.HasClaim(c => c.Type == "cliente") && cliente == null)
            {
                return RedirectToAction("Create", "cliente");
            }

            agendamentoVM.ClienteId = cliente.Id;

            var agendamento = _mapper.Map<Agendamento>(agendamentoVM);

            agendamento.GravarDataDoAgendamento();

            await _agendamentoRepository.Create(agendamento);
            return RedirectToAction("Index", "AgendamentoDoCliente");
        }
    }
}
