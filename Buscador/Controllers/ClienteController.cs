using AutoMapper;
using Buscador.Models.Dto;
using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Buscador.Models.Services;
using Buscador.Models.ViewModels;
using Buscador.Utils.ApiClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IUploadArquivo _uploadArquivo;
        private readonly IEnderecoClienteRepository enderecoClienteRepository;

        public ClienteController(IClienteRepository clienteRepository,
                                       IMapper mapper,
                                       IViaCepClient viaCepClient,
                                       UserManager<IdentityUser> userManager,
                                       SignInManager<IdentityUser> signInManager, 
                                       IUploadArquivo uploadArquivo,
                                       IEnderecoClienteRepository enderecoClienteRepository)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
            this.viaCepClient = viaCepClient;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _uploadArquivo = uploadArquivo;
            this.enderecoClienteRepository = enderecoClienteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cliente = await clienteRepository.ObterTodos();
            var clienteViewModel = mapper.Map<IEnumerable<ClienteViewModel>>(cliente);

            return View(clienteViewModel);
        }

        //[Authorize(Policy = "cliente")]
        public async Task<IActionResult> ObterCliente(Guid userId)
        {
            var clienteViewModel = await ObterClienteEnderecoPorUserId(userId);
            if (User.HasClaim(c => c.Type == "cliente") && clienteViewModel == null)
            {
                return RedirectToAction("Create", "cliente");
            }
            if (clienteViewModel == null)
            {
                return NotFound();
            }

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
            var clienteViewModel = new ClienteViewModel();
            return View(clienteViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);


            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await _uploadArquivo.RealizarUploadArquivo(clienteViewModel.FotoUploadCliente, imgPrefixo))
            {
                return View(clienteViewModel);
            }

            clienteViewModel.Foto = imgPrefixo + clienteViewModel.FotoUploadCliente.FileName;

            var cliente = mapper.Map<Cliente>(clienteViewModel);
            await clienteRepository.Adicionar(cliente);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarDadosDoCliente(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction("ObterCliente", new { userId = clienteViewModel.UserId });

            var cliente = mapper.Map<Cliente>(clienteViewModel);
            await clienteRepository.Atualizar(cliente);

            return RedirectToAction("ObterCliente", new { userId = clienteViewModel.UserId });
        }

        [HttpPost, ActionName("excluirCliente")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> excluirCliente(Guid id)
        {
            var clienteViewModel = await ObterClienteEndereco(id);

            if (clienteViewModel == null) return NotFound();

            await clienteRepository.Remover(id);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction("ObterCliente", new { userId = clienteViewModel.UserId });

            await enderecoClienteRepository.Atualizar(mapper.Map<EnderecoCliente>(clienteViewModel.EnderecoCliente));

            return RedirectToAction("ObterCliente", new { userId = clienteViewModel.UserId });

        }

        private async Task<ClienteViewModel> ObterClienteEnderecoPorUserId(Guid userId)
        {
            return mapper.Map<ClienteViewModel>(await clienteRepository.ObterClienteEnderecoPorUserId(userId));
        }

        private async Task<ClienteViewModel> ObterClienteEndereco(Guid id)
        {
            return mapper.Map<ClienteViewModel>(await clienteRepository.ObterClienteEndereco(id));
        }

    }
}
