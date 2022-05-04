using AutoMapper;
using Buscador.Extensions;
using Buscador.Interfaces;
using Buscador.Models;
using Buscador.Models.Dto;
using Buscador.Utils.ApiClient;
using Buscador.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    [Authorize]
    public class TrabalhadoresController : BaseController
    {
        private readonly ITrabalhadorRepository _trabalhadorRepository;
        private readonly IMapper _mapper;
        private readonly IViaCepClient viaCepClient;
        private readonly IEnderecoTrabalhadorRepository enderecoTrabalhadorRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICategoriaRepository _categoriaRepository;

        public TrabalhadoresController(ITrabalhadorRepository trabalhadorRepository,
                                       IMapper mapper,
                                       IViaCepClient viaCepClient,
                                       IEnderecoTrabalhadorRepository enderecoTrabalhadorRepository,
                                       UserManager<IdentityUser> userManager,
                                       SignInManager<IdentityUser> signInManager,
                                       IWebHostEnvironment hostingEnvironment,
                                       ICategoriaRepository categoriaRepository)
        {
            _trabalhadorRepository = trabalhadorRepository;
            _mapper = mapper;
            this.viaCepClient = viaCepClient;
            this.enderecoTrabalhadorRepository = enderecoTrabalhadorRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
            _categoriaRepository = categoriaRepository;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var trabalhadores = await _trabalhadorRepository.ObterTodos();
            var trabalhadoresViewModel = _mapper.Map<IEnumerable<TrabalhadorViewModel>>(trabalhadores);
            trabalhadoresViewModel.Select(t => t.Solicitado ? t.SolicitadoMap = "Sim" : t.SolicitadoMap = "Não");
            return View(trabalhadoresViewModel);
        }

        //[Authorize(Policy = "trabalhador")]
        public async Task<IActionResult> ObterTrabalhador(Guid userId)
        {
            var trabalhadorViewModel = await ObterTrabalhadorEnderecoPorUserId(userId);
            //trabalhadorViewModel.TipoDeTrabalhador.GetDescription();
            if (User.HasClaim(t => t.Type == "trabalhador") && trabalhadorViewModel == null)
            {
                return RedirectToAction("Create");
            }
            if (trabalhadorViewModel == null)
            {
                return NotFound();
            }

            return View(trabalhadorViewModel);

        }

        public async Task<IActionResult> Details(Guid id)
        {
            var trabalhadorViewModel = await ObterTrabalhadorEndereco(id);
            if (trabalhadorViewModel == null)
            {
                return NotFound();
            }

            return View(trabalhadorViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaRepository.ObterTodos();

            var trabalhador = new TrabalhadorViewModel()
            {
                TiposDeTrabalhadores = EnumHelper.CriarListaDeEnum<TipoDeTrabalhador>(),
                ListagemDeCategorias = categorias.OrderBy(c => c.Nome)
                                                            .Select(d => new SelectListItem { Text = d.Nome, Value = d.Id.ToString() })
                                                            .ToList(),
            };
            return View(trabalhador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrabalhadorViewModel trabalhadorViewModel)
        {
            if (!ModelState.IsValid) return View(trabalhadorViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(trabalhadorViewModel.FotoUpload, imgPrefixo))
            {
                return View(trabalhadorViewModel);
            }

            trabalhadorViewModel.Foto = imgPrefixo + trabalhadorViewModel.FotoUpload.FileName;

            var trabalhador = _mapper.Map<Trabalhador>(trabalhadorViewModel);
            await _trabalhadorRepository.Adicionar(trabalhador);

            return RedirectToAction("ObterTrabalhador", new { userId = trabalhadorViewModel.UserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarDadosDoTrabalhador(TrabalhadorViewModel trabalhadorViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction("ObterTrabalhador", new { userId = trabalhadorViewModel.UserId });

            var trabalhador = _mapper.Map<Trabalhador>(trabalhadorViewModel);
            await _trabalhadorRepository.Atualizar(trabalhador);
            
            return RedirectToAction("ObterTrabalhador", new { userId = trabalhadorViewModel.UserId });
        }

        public async Task<IActionResult> SolicitarTrabalhador(Guid id)
        {
            if (id == Guid.Empty) return NotFound();
            var trabalhadorViewModel = await _trabalhadorRepository.ObterPorId(id);
            var trabalhador = _mapper.Map<Trabalhador>(trabalhadorViewModel);
            trabalhador.SolicitarTrabalhador();

            await _trabalhadorRepository.Atualizar(trabalhador);

            return RedirectToAction("Index");
            //return RedirectToAction("Solicitacao", "Create", new { servicoId = servicoId });
        }
        
        [HttpPost, ActionName("ExcluirTrabalhador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirTrabalhador(Guid id)
        {
            var trabalhadorViewModel = await ObterTrabalhadorEnderecoEServico(id);

            if (trabalhadorViewModel == null) return NotFound();

            await _trabalhadorRepository.Remover(id);

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
        public async Task<IActionResult> AtualizarEndereco(TrabalhadorViewModel trabalhadorViewModel)
        {

            if (!ModelState.IsValid) return RedirectToAction("ObterTrabalhador", new { userId = trabalhadorViewModel.UserId });

            await enderecoTrabalhadorRepository.Atualizar(_mapper.Map<EnderecoTrabalhador>(trabalhadorViewModel.EnderecoTrabalhador));

            return RedirectToAction("ObterTrabalhador", new { userId = trabalhadorViewModel.UserId }); 
        }

        private async Task<TrabalhadorViewModel> ObterTrabalhadorEnderecoPorUserId(Guid userId)
        {
            return _mapper.Map<TrabalhadorViewModel>(await _trabalhadorRepository.ObterTrabalhadorEnderecoPorUserId(userId));
        }

        private async Task<TrabalhadorViewModel> ObterTrabalhadorEndereco(Guid id)
        {
            return _mapper.Map<TrabalhadorViewModel>(await _trabalhadorRepository.ObterTrabalhadorEndereco(id));
        }

        private async Task<TrabalhadorViewModel> ObterTrabalhadorEnderecoEServico(Guid id)
        {
            return _mapper.Map<TrabalhadorViewModel>(await _trabalhadorRepository.ObterTrabalhadorEnderecoEServico(id));
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            string projectRootPath = _hostingEnvironment.ContentRootPath;

            var path = Path.Combine(projectRootPath,
                                    "wwwroot/imagens",
                                    imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Ja existe um arquivo com este nome!");
                return false;
            }

            // gravar arquivo em disco
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
