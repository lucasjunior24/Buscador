using AutoMapper;
using Buscador.Interfaces;
using Buscador.Models;
using Buscador.Models.Dto;
using Buscador.Utils.ApiClient;
using Buscador.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class TrabalhadoresController : BaseController
    {
        private readonly ITrabalhadorRepository _trabalhadorRepository;
        private readonly IMapper _mapper;
        private readonly IViaCepClient viaCepClient;


        public TrabalhadoresController(ITrabalhadorRepository trabalhadorRepository,
                                       IMapper mapper, 
                                       IViaCepClient viaCepClient)
        {
            _trabalhadorRepository = trabalhadorRepository;
            _mapper = mapper;
            this.viaCepClient = viaCepClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<TrabalhadorViewModel>>(await _trabalhadorRepository.ObterTodos()));
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrabalhadorViewModel trabalhadorViewModel)
        {
            if (!ModelState.IsValid) return View(trabalhadorViewModel);

            var trabalhador = _mapper.Map<Trabalhador>(trabalhadorViewModel);
            await _trabalhadorRepository.Adicionar(trabalhador);
       
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var trabalhadorViewModel = await ObterTrabalhadorEnderecoEServico(id);
            if (trabalhadorViewModel == null)
            {
                return NotFound();
            }
            return View(trabalhadorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TrabalhadorViewModel trabalhadorViewModel)
        {
            if (id != trabalhadorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(trabalhadorViewModel);

            var trabalhador = _mapper.Map<Trabalhador>(trabalhadorViewModel);
            await _trabalhadorRepository.Atualizar(trabalhador);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var trabalhadorViewModel = await ObterTrabalhadorEnderecoEServico(id);

            if (trabalhadorViewModel == null)
            {
                return NotFound();
            }

            return View(trabalhadorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
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

        private async Task<TrabalhadorViewModel> ObterTrabalhadorEndereco(Guid id)
        {
            return _mapper.Map<TrabalhadorViewModel>(await _trabalhadorRepository.ObterTrabalhadorEndereco(id));
        }

        private async Task<TrabalhadorViewModel> ObterTrabalhadorEnderecoEServico(Guid id)
        {
            return _mapper.Map<TrabalhadorViewModel>(await _trabalhadorRepository.ObterTrabalhadorEnderecoEServico(id));
        }
    }
}
