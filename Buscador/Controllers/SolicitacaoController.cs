using AutoMapper;
using Buscador.Interfaces;
using Buscador.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : BaseController
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly IMapper _mapper;

        public SolicitacaoController(ISolicitacaoRepository trabalhadorRepository,
                                       IMapper mapper)
        {
            _solicitacaoRepository = trabalhadorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SolicitacaoViewModel>>(await _solicitacaoRepository.ObterTodos()));
        }

    }


}
