using Microsoft.AspNetCore.Mvc;
using LanceCerto.WebApp.Data;
using LanceCerto.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LanceCerto.WebApp.Controllers
{
    public class ImovelController : Controller
    {
        private readonly LanceCertoDbContext _context;

        public ImovelController(LanceCertoDbContext context)
        {
            _context = context;
        }

        // GET: Imovel
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

            var imoveisFiltrados = await query.OrderBy(i => i.Titulo).ToListAsync();
            return View(imoveisFiltrados);
        }

        // GET: Imovel/Create
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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.ImovelId == id);

            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imovel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Imovel imovel)
        {
            if (id != imovel.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Imoveis.Any(e => e.ImovelId == imovel.ImovelId))
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
            return View(imovel);
        }

        // GET: Imovel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.ImovelId == id);
            if (imovel == null)
            {
                return NotFound();
            }

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
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}