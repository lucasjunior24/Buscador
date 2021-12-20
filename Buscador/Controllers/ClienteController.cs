using AutoMapper;
using Buscador.Interfaces;
using Buscador.Models;
using Buscador.Models.Dto;
using Buscador.Utils.ApiClient;
using Buscador.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;
        private readonly IViaCepClient viaCepClient;


        public ClienteController(IClienteRepository clienteRepository,
                                       IMapper mapper,
                                       IViaCepClient viaCepClient)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
            this.viaCepClient = viaCepClient;
        }

        public async Task<IActionResult> Index()
        {
            var cliente = await clienteRepository.ObterTodos();
            var clienteViewModel = mapper.Map<IEnumerable<ClienteViewModel>>(cliente);

            return View(clienteViewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var clienteViewModel = await ObterClienteEndereco(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = mapper.Map<Cliente>(clienteViewModel);
            await clienteRepository.Adicionar(cliente);

            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> BuscarCep(string cep)
        {
            var dados = await viaCepClient.BuscarCep(cep);
            if (typeof(RetornoViaCepDto).GetProperties().All(a => a.GetValue(dados) != null))
                return Json(new { dados, type = "success" });
            else
            {
                return Json(new { dados, type = "fail" });
            }
        }

        private async Task<ClienteViewModel> ObterClienteEndereco(Guid id)
        {
            return mapper.Map<ClienteViewModel>(await clienteRepository.ObterClienteEndereco(id));
        }

    }
}
