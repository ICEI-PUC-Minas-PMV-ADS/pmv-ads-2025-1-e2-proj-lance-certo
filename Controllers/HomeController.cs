using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LanceCerto.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: /Home/Index
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            // Redireciona usuários logados para a tela principal do sistema
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Imovel");
            }

            return View(); // Tela inicial pública com "Entrar" e "Criar Conta"
        }

        // GET: /Home/Error
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionFeature != null)
            {
                _logger.LogError(exceptionFeature.Error,
                    "Erro não tratado na rota: {Path}", exceptionFeature.Path);
            }

            return View("Error");
        }

        // GET: /Home/Privacy (caso tenha a view de política de privacidade)
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}