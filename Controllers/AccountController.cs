using Microsoft.AspNetCore.Mvc;
using LanceCerto.WebApp.Models;
using LanceCerto.WebApp.Data;

namespace LanceCerto.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly LanceCertoDbContext _context;

        public AccountController(LanceCertoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(CadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario()
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    DataNascimento = model.DataNascimento,
                    Estado = "ATIVO"
                };
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}
