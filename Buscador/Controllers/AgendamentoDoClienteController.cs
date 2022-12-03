using AutoMapper;
using Buscador.Models.Interfaces;
using Buscador.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class AgendamentoDoClienteController : BaseController
    {

        private readonly IAgendamentoDoClienteRepository _agendamentoDoClienteRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper _mapper;
        public AgendamentoDoClienteController(IAgendamentoDoClienteRepository agendamentoDoClienteRepository, UserManager<IdentityUser> userManager, IClienteRepository clienteRepository, IMapper mapper)
        {
            _agendamentoDoClienteRepository = agendamentoDoClienteRepository;
            this.userManager = userManager;
            this.clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var id = userManager.GetUserId(User);
            var userId = Guid.Parse(id);
            var cliente = await clienteRepository.ObterClienteEnderecoPorUserId(userId);
            if (User.HasClaim(c => c.Type == "cliente") && cliente == null)
            {
                return RedirectToAction("Create", "cliente");
            }
            var agendamentos = await _agendamentoDoClienteRepository.ObterTodosPorClienteId(cliente.Id);


            var agendamentosVM = _mapper.Map<List<AgendamentoViewModel>>(agendamentos);
            return View(agendamentosVM);
        }
    }
}
