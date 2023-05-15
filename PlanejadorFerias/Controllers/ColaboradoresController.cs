using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlanejadorFerias.Data;
using PlanejadorFerias.Models;

namespace PlanejadorFerias.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly PlanejadorFeriasContext _context;

        public ColaboradoresController(PlanejadorFeriasContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index()
        {
            return _context.Colaboradores != null ?
                        View(await _context.Colaboradores.ToListAsync()) :
                          Problem("Entity set 'PlanejadorFeriasContext.Colaboradores'  is null.");
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradores == null)
            {
                return NotFound();
            }

            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cargo,Setor,DataAdmissao")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                colaboradores.Id = Guid.NewGuid();
                _context.Add(colaboradores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores.FindAsync(id);
            if (colaboradores == null)
            {
                return NotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Cargo,Setor,DataAdmissao")] Colaboradores colaboradores)
        {
            if (id != colaboradores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradoresExists(colaboradores.Id))
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
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();

            }

            var colaboradores = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradores == null)
            {
                return NotFound();
            }

            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Colaboradores == null)
            {
                return Problem("Entity set 'PlanejadorFeriasContext.Colaboradores'  is null.");
            }
            var colaboradores = await _context.Colaboradores.FindAsync(id);
            if (colaboradores != null)
            {
                _context.Colaboradores.Remove(colaboradores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradoresExists(Guid id)
        {
          return (_context.Colaboradores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
