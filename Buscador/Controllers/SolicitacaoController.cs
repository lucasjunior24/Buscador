using AutoMapper;
using Buscador.Interfaces;
using Buscador.Models;
using Buscador.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : BaseController
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly IMapper _mapper;
        private readonly ITrabalhadorRepository _trabalhadorRepository;
        private readonly IClienteRepository _clienteRepository;

        public SolicitacaoController(ISolicitacaoRepository solicitacaoRepository,
                                       IMapper mapper,
                                       ITrabalhadorRepository trabalhadorRepository, 
                                       IClienteRepository clienteRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
            _mapper = mapper;
            _trabalhadorRepository = trabalhadorRepository;
            _clienteRepository = clienteRepository;
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

        //public async Task<IActionResult> Details(Guid id)
        //{
        //    var solicitacaoViewModel = _mapper.Map<SolicitacaoViewModel>(await _solicitacaoRepository.ObterSolicitacaoPorId(id));
        //    if (solicitacaoViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(solicitacaoViewModel);
        //}

        public async Task<IActionResult> CriarSolicitacao(Guid trabalhadorId)
        {
            var trabalhador = await _trabalhadorRepository.ObterPorId(trabalhadorId);

            var solicitacaoViewModel = new SolicitacaoViewModel();
            solicitacaoViewModel.NomeTrabalhador = trabalhador.Nome;
            solicitacaoViewModel.TrabalhadorId = trabalhador.Id;
            solicitacaoViewModel.ProfisssaoDoTrabalhador = trabalhador.Profissao;


            return View(solicitacaoViewModel);
        }

        public async Task<IActionResult> Create(SolicitacaoViewModel solicitacaoViewModel)
        {
            var cliente = await _clienteRepository.ObterClienteEnderecoPorUserId(solicitacaoViewModel.UserId);
            //if (!ModelState.IsValid) return View(solicitacaoViewModel);
            solicitacaoViewModel.NomeSolicitante = cliente.Nome;
            solicitacaoViewModel.ClienteId = cliente.Id;

            var solicitacao = _mapper.Map<Solicitacao>(solicitacaoViewModel);

            solicitacao.GravarDataDaSolicitacao();

            await _solicitacaoRepository.Adicionar(solicitacao);

            return RedirectToAction("Trabalhadores", "Index");
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}

    }


}
