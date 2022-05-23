using AutoMapper;
using Buscador.Extensions;
using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Buscador.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class SolicitacaoController : BaseController
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly IMapper _mapper;
        private readonly ITrabalhadorRepository _trabalhadorRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly UserManager<IdentityUser> userManager;

        public SolicitacaoController(ISolicitacaoRepository solicitacaoRepository,
                                       IMapper mapper,
                                       ITrabalhadorRepository trabalhadorRepository,
                                       IClienteRepository clienteRepository, 
                                       UserManager<IdentityUser> userManager)
        {
            _solicitacaoRepository = solicitacaoRepository;
            _mapper = mapper;
            _trabalhadorRepository = trabalhadorRepository;
            this.clienteRepository = clienteRepository;
            this.userManager = userManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(_mapper.Map<IEnumerable<SolicitacaoViewModel>>(await _solicitacaoRepository.ObterTodos()));
        //}
        //public async Task<IActionResult> MinhasSolicitacoes(Guid clienteId)
        //{
        //    var solicitacoesViewModel = _mapper.Map<List<SolicitacaoViewModel>>(await _solicitacaoRepository.ObterMinhasSolicitacoes(clienteId));
        //    return View(solicitacoesViewModel);
        //}

        public async Task<IActionResult> MinhaSolicitacoes(Guid userId)
        {
            var listaSoliciacao = await _solicitacaoRepository.ObteSolicitacoesDoCliente(userId);
            var listDeSolicitacaoVm = _mapper.Map<List<SolicitacaoViewModel>>(listaSoliciacao);
            if (listDeSolicitacaoVm == null)
            {
                return NotFound();
            }

            return View(listDeSolicitacaoVm);
        }

        public async Task<IActionResult> Create(Guid trabalhadorId)
        {
            var trabalhador = await _trabalhadorRepository.ObterPorId(trabalhadorId);
            trabalhador.SolicitarTrabalhador();
            await _trabalhadorRepository.Atualizar(trabalhador);

            var id = userManager.GetUserId(User);
            var userId = Guid.Parse(id);
            var cliente = await clienteRepository.ObterClienteEnderecoPorUserId(userId);
            if (User.HasClaim(c => c.Type == "cliente") && cliente == null)
            {
                return RedirectToAction("Create", "cliente");
            }

            var solicitacaoViewModel = new SolicitacaoViewModel
            {
                NomeDoTrabalhador = trabalhador.Nome,
                ProfissaoDoTrabalhador = trabalhador.Profissao,
                TrabalhadorId = trabalhador.Id,

                ClienteId = cliente.Id,
                NomeDoCliente = cliente.Nome
            };

            return View(solicitacaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolicitacaoViewModel solicitacaoViewModel)
        {

            if (!ModelState.IsValid) return View(solicitacaoViewModel);

            var solicitacao = _mapper.Map<Solicitacao>(solicitacaoViewModel);
            
            solicitacao.AguadarAprovacaoDaSolicitacao();
            solicitacao.GravarDataDaSolicitacao();

            await _solicitacaoRepository.Adicionar(solicitacao);

            return RedirectToAction("Index", "Trabalhadores");
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        
        public async Task<IActionResult> MinhaSolicitacoesDeTrabalhador(Guid userId)
        {
            var trabalhador = await _trabalhadorRepository.ObterTrabalhadorEnderecoPorUserId(userId);

            var listaSoliciacao = await _solicitacaoRepository.ObteSolicitacoesDeTrabalhador(trabalhador.Id);

            var listaSolicitacaoViewModel = new List<SolicitacaoViewModel>();
            foreach (var solicitacao in listaSoliciacao)
            {
                var solicitacaoViewModel = new SolicitacaoViewModel()
                {
                    Id = solicitacao.Id,
                    DataDaSolicitacao = solicitacao.DataDaSolicitacao,
                    NomeDoCliente = solicitacao.NomeDoCliente,
                    NomeDoTrabalhador = solicitacao.NomeDoTrabalhador,
                    ProfissaoDoTrabalhador = solicitacao.ProfissaoDoTrabalhador,
                    StatusDaSolicitacao = solicitacao.StatusDaSolicitacao.GetDescription(),
                    ClienteId = solicitacao.ClienteId,
                    Trabalhador = solicitacao.Trabalhador,
                    TrabalhadorId = solicitacao.TrabalhadorId
                };
                listaSolicitacaoViewModel.Add(solicitacaoViewModel);
            }



            return View(listaSolicitacaoViewModel);
        }
        public async Task<IActionResult> AprovarSolicitacao(Guid solicitacaoId)
        {
            var soliciacao = await _solicitacaoRepository.ObterSolicitacaoPorId(solicitacaoId);
            soliciacao.AprovarSolicitacao();

            await _solicitacaoRepository.Atualizar(soliciacao);

            var id = userManager.GetUserId(User);
            var userId = Guid.Parse(id);

            return RedirectToAction("MinhaSolicitacoesDeTrabalhador", new { userId });
        }
    }


}
