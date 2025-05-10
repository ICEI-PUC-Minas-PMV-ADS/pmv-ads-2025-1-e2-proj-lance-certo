using Microsoft.AspNetCore.Mvc;
using LanceCerto.WebApp.Data;
using LanceCerto.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace LanceCerto.WebApp.Controllers
{
    [Authorize]
    public class ImovelController : Controller
    {
        private readonly LanceCertoDbContext _context;

        public ImovelController(LanceCertoDbContext context)
        {
            _context = context;
        }

        // GET: Imovel
        [HttpGet]
        public async Task<IActionResult> Index(string? cidade, string? estado, string? tipo, decimal? precoMaximo)
        {
            var query = _context.Imoveis.AsQueryable();

            if (!string.IsNullOrWhiteSpace(cidade))
                query = query.Where(i => i.Cidade.Contains(cidade));

            if (!string.IsNullOrWhiteSpace(estado))
                query = query.Where(i => i.Estado.Contains(estado));

            if (!string.IsNullOrWhiteSpace(tipo))
                query = query.Where(i => i.Tipo.Contains(tipo));

            if (precoMaximo.HasValue)
                query = query.Where(i => i.PrecoMinimo <= precoMaximo.Value);

            var imoveisFiltrados = await query
                .OrderBy(i => i.Titulo)
                .ToListAsync();

            return View(imoveisFiltrados);
        }

        // GET: Imovel/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imovel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imovel);
        }

        // GET: Imovel/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var imovel = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.ImovelId == id);

            if (imovel == null)
                return NotFound();

            return View(imovel);
        }

        // GET: Imovel/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
                return NotFound();

            return View(imovel);
        }

        // POST: Imovel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Imovel imovel)
        {
            if (id != imovel.ImovelId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Imoveis.AnyAsync(e => e.ImovelId == imovel.ImovelId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(imovel);
        }

        // GET: Imovel/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var imovel = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.ImovelId == id);

            if (imovel == null)
                return NotFound();

            return View(imovel);
        }

        // POST: Imovel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel != null)
            {
                _context.Imoveis.Remove(imovel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Imovel/Error
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}