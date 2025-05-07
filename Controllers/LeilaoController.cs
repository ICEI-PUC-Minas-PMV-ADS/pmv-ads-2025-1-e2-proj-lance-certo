using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanceCerto.WebApp.Data;
using LanceCerto.WebApp.Models;

namespace LanceCerto.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        private readonly LanceCertoDbContext _context;

        public LeilaoController(LanceCertoDbContext context)
        {
            _context = context;
        }

        // GET: Leilao
        public async Task<IActionResult> Index()
        {
            var lanceCertoDbContext = _context.Leiloes.Include(l => l.Imovel).Include(l => l.Vencedor);
            return View(await lanceCertoDbContext.ToListAsync());
        }

        // GET: Leilao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _context.Leiloes
                .Include(l => l.Imovel)
                .Include(l => l.Vencedor)
                .FirstOrDefaultAsync(m => m.LeilaoId == id);
            if (leilao == null)
            {
                return NotFound();
            }

            return View(leilao);
        }

        

        // POST: Leilao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public IActionResult Create()
        {
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Titulo");

            ViewBag.StatusList = new SelectList(new List<string> { "PENDENTE", "ATIVO", "ENCERRADO" });

            return View();
        }

        // POST: Leilao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeilaoId,ImovelId,InicioEm,FimEm,Status,MaiorLanceAtual")] Leilao leilao)
        {
            Console.WriteLine("===== ENTROU NO MÉTODO POST DO LEILÃO =====");

            if (leilao.InicioEm >= leilao.FimEm)
            {
                ModelState.AddModelError("FimEm", "A data de fim deve ser posterior à data de início.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(leilao);
                await _context.SaveChangesAsync();
                Console.WriteLine(">>> Leilão salvo com sucesso <<<");
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine(">>> ModelState INVÁLIDO <<<");

                foreach (var error in ModelState)
                {
                    foreach (var subError in error.Value.Errors)
                    {
                        Console.WriteLine($"Erro no campo '{error.Key}': {subError.ErrorMessage}");
                    }
                }
            }

            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Cidade", leilao.ImovelId);
            ViewBag.StatusList = new SelectList(new List<string> { "PENDENTE", "ATIVO", "ENCERRADO" }, leilao.Status);
            leilao.MaiorLanceAtual = 0;

            return View(leilao);
        }

        // GET: Leilao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _context.Leiloes.FindAsync(id);
            if (leilao == null)
            {
                return NotFound();
            }
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Cidade", leilao.ImovelId);
            ViewData["VencedorId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", leilao.VencedorId);
            return View(leilao);
        }

        // POST: Leilao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeilaoId,ImovelId,VencedorId,InicioEm,FimEm,Status,MaiorLanceAtual")] Leilao leilao)
        {
            if (id != leilao.LeilaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leilao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeilaoExists(leilao.LeilaoId))
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
            ViewData["ImovelId"] = new SelectList(_context.Imoveis, "ImovelId", "Cidade", leilao.ImovelId);
            ViewData["VencedorId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", leilao.VencedorId);
            return View(leilao);
        }

        // GET: Leilao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leilao = await _context.Leiloes
                .Include(l => l.Imovel)
                .Include(l => l.Vencedor)
                .FirstOrDefaultAsync(m => m.LeilaoId == id);
            if (leilao == null)
            {
                return NotFound();
            }

            return View(leilao);
        }

        // POST: Leilao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leilao = await _context.Leiloes.FindAsync(id);
            if (leilao != null)
            {
                _context.Leiloes.Remove(leilao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeilaoExists(int id)
        {
            return _context.Leiloes.Any(e => e.LeilaoId == id);
        }
    }
}
