using AutoMapper;
using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Buscador.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class TiposDeServicosController : BaseController
    {
        private readonly ITipoDeServicoRepository _tipoDeServicoRepository;
        private readonly IMapper _mapper;

        public TiposDeServicosController(ITipoDeServicoRepository tipoDeServicoRepository, 
                                         IMapper mapper)
        {
            _tipoDeServicoRepository = tipoDeServicoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<TipoDeServicoViewModel>>(await _tipoDeServicoRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var tipoDeServicoViewModel = await ObterTipoDeServicoTrabalhador(id);
            if (tipoDeServicoViewModel == null)
            {
                return NotFound();
            }

            return View(tipoDeServicoViewModel);
        
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoDeServicoViewModel tipoDeServicoViewModel)
        {
            if (!ModelState.IsValid) return View(tipoDeServicoViewModel);

            var trabalhador = _mapper.Map<TipoDeServico>(tipoDeServicoViewModel);
            await _tipoDeServicoRepository.Adicionar(trabalhador);

            return RedirectToAction(nameof(Index));
        }
       

        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tipoDeServicoViewModel = await _context.TipoDeServicoViewModel.FindAsync(id);
        //    if (tipoDeServicoViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TrabalhadorId"] = new SelectList(_context.Set<TrabalhadorViewModel>(), "Id", "Id", tipoDeServicoViewModel.TrabalhadorId);
        //    return View(tipoDeServicoViewModel);
        //}

        //// POST: TiposDeServicos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,TrabalhadorId,NomeDoServico,Descricao,Imagem,AreaProfissional")] TipoDeServicoViewModel tipoDeServicoViewModel)
        //{
        //    if (id != tipoDeServicoViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tipoDeServicoViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TipoDeServicoViewModelExists(tipoDeServicoViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TrabalhadorId"] = new SelectList(_context.Set<TrabalhadorViewModel>(), "Id", "Id", tipoDeServicoViewModel.TrabalhadorId);
        //    return View(tipoDeServicoViewModel);
        //}

        //// GET: TiposDeServicos/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tipoDeServicoViewModel = await _context.TipoDeServicoViewModel
        //        .Include(t => t.Trabalhador)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tipoDeServicoViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tipoDeServicoViewModel);
        //}

        //// POST: TiposDeServicos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var tipoDeServicoViewModel = await _context.TipoDeServicoViewModel.FindAsync(id);
        //    _context.TipoDeServicoViewModel.Remove(tipoDeServicoViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private async Task<TipoDeServicoViewModel> ObterTipoDeServicoTrabalhador(Guid id)
        {
            return _mapper.Map<TipoDeServicoViewModel>(await _tipoDeServicoRepository.ObterTipoDeServicoTrabalhador(id));
        }

    }
}
