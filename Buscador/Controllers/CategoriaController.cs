using AutoMapper;
using Buscador.Interfaces;
using Buscador.Models;
using Buscador.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    [AllowAnonymous]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public CategoriaController(ICategoriaRepository categoriaRepository,
                                       IMapper mapper,
                                       IWebHostEnvironment hostingEnvironment)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaRepository.ObterTodos();
            var categoriaViewModel = _mapper.Map<IEnumerable<CategoriaViewModel>>(categorias);

            return View(categoriaViewModel);
        }

        public IActionResult Criar()
        {
            var categoriaViewModel = new CategoriaViewModel();
            return View(categoriaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaViewModel);

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaRepository.Adicionar(categoria);
            
            return RedirectToAction(nameof(Index));
        }

    }
}
