using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanceCerto.WebApp.Data;
using LanceCerto.WebApp.Models;

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

        private void PopularDropdowns()
        {
            ViewBag.Estados = new List<string>
            {
                "AC","AL","AM","AP","BA","CE","DF","ES","GO","MA",
                "MG","MS","MT","PA","PB","PE","PI","PR","RJ","RN",
                "RO","RR","RS","SC","SE","SP","TO"
            };

            ViewBag.Tipos = new List<string> { "Casa", "Apartamento", "Terreno", "Comercial", "Outro" };
            ViewBag.StatusList = new List<string> { "Disponível", "Indisponível", "Vendido", "Em Leilão" };
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? cidade, string? estado, string? tipo, decimal? precoMaximo)
        {
            var query = _context.Imoveis.AsQueryable();

            if (!string.IsNullOrWhiteSpace(cidade))
                query = query.Where(i => i.Cidade.Contains(cidade));

            if (!string.IsNullOrWhiteSpace(estado))
                query = query.Where(i => i.Estado == estado);

            if (!string.IsNullOrWhiteSpace(tipo))
                query = query.Where(i => i.Tipo == tipo);

            if (precoMaximo.HasValue)
                query = query.Where(i => i.PrecoMinimo <= precoMaximo.Value);

            var imoveis = await query.OrderBy(i => i.Titulo).ToListAsync();
            return View(imoveis);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopularDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Imovel imovel)
        {
            if (!ModelState.IsValid)
            {
                PopularDropdowns();
                return View(imovel);
            }

            _context.Add(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var imovel = await _context.Imoveis.FirstOrDefaultAsync(i => i.ImovelId == id);
            if (imovel == null)
                return NotFound();

            return View(imovel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
                return NotFound();

            PopularDropdowns();
            return View(imovel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Imovel imovel)
        {
            if (id != imovel.ImovelId)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                PopularDropdowns();
                return View(imovel);
            }

            try
            {
                _context.Update(imovel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Imoveis.AnyAsync(e => e.ImovelId == id))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var imovel = await _context.Imoveis.FirstOrDefaultAsync(i => i.ImovelId == id);
            if (imovel == null)
                return NotFound();

            return View(imovel);
        }

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

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}