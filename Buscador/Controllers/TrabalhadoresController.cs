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
    public class TrabalhadoresController : Controller
    {
        private readonly ITrabalhadorRepository _trabalhadorRepository;

        public TrabalhadoresController(ITrabalhadorRepository trabalhadorRepository)
        {
            _trabalhadorRepository = trabalhadorRepository;
        }

        // GET: Trabalhadores
        public async Task<IActionResult> Index()
        {
            return View(await _trabalhadorRepository.ObterTodos());
        }

        // GET: Trabalhadores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalhadorViewModel = await _context.TrabalhadorViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabalhadorViewModel == null)
            {
                return NotFound();
            }

            return View(trabalhadorViewModel);
        }

        // GET: Trabalhadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trabalhadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Foto,Telefone,Email,Documento,TipoDeTrabalhador,Profissao")] TrabalhadorViewModel trabalhadorViewModel)
        {
            if (ModelState.IsValid)
            {
                trabalhadorViewModel.Id = Guid.NewGuid();
                _context.Add(trabalhadorViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabalhadorViewModel);
        }

        // GET: Trabalhadores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalhadorViewModel = await _context.TrabalhadorViewModel.FindAsync(id);
            if (trabalhadorViewModel == null)
            {
                return NotFound();
            }
            return View(trabalhadorViewModel);
        }

        // POST: Trabalhadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Foto,Telefone,Email,Documento,TipoDeTrabalhador,Profissao")] TrabalhadorViewModel trabalhadorViewModel)
        {
            if (id != trabalhadorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabalhadorViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabalhadorViewModelExists(trabalhadorViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trabalhadorViewModel);
        }

        // GET: Trabalhadores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalhadorViewModel = await _context.TrabalhadorViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabalhadorViewModel == null)
            {
                return NotFound();
            }

            return View(trabalhadorViewModel);
        }

        // POST: Trabalhadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trabalhadorViewModel = await _context.TrabalhadorViewModel.FindAsync(id);
            _context.TrabalhadorViewModel.Remove(trabalhadorViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabalhadorViewModelExists(Guid id)
        {
            return _context.TrabalhadorViewModel.Any(e => e.Id == id);
        }
    }
}
