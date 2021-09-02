using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buscador.Data.Context;
using Buscador.ViewModels;
using Buscador.Interfaces;

namespace Buscador.Controllers
{
    public class TiposDeServicosController : BaseController
    {
        private readonly ITipoDeServicoRepository _tipoDeServicoRepository;

        public TiposDeServicosController(ITipoDeServicoRepository tipoDeServicoRepository)
        {
            _tipoDeServicoRepository = tipoDeServicoRepository;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var buscadorContext = _context.TipoDeServicoViewModel.Include(t => t.Trabalhador);
        //    return View(await buscadorContext.ToListAsync());
        //}

        //public async Task<IActionResult> Details(Guid? id)
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

        //// GET: TiposDeServicos/Create
        //public IActionResult Create()
        //{
        //    ViewData["TrabalhadorId"] = new SelectList(_context.Set<TrabalhadorViewModel>(), "Id", "Id");
        //    return View();
        //}

        //// POST: TiposDeServicos/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,TrabalhadorId,NomeDoServico,Descricao,Imagem,AreaProfissional")] TipoDeServicoViewModel tipoDeServicoViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        tipoDeServicoViewModel.Id = Guid.NewGuid();
        //        _context.Add(tipoDeServicoViewModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TrabalhadorId"] = new SelectList(_context.Set<TrabalhadorViewModel>(), "Id", "Id", tipoDeServicoViewModel.TrabalhadorId);
        //    return View(tipoDeServicoViewModel);
        //}

        //// GET: TiposDeServicos/Edit/5
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

    }
}
