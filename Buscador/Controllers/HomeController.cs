using Buscador.Models;
using Buscador.Utils.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPerfilService _perfilService;

        public HomeController(ILogger<HomeController> logger, IPerfilService perfilService)
        {
            _logger = logger;
            _perfilService = perfilService;
        }

        public async Task<IActionResult> Index(Guid userId)
        {
            if (userId != Guid.Empty)
            {
                var perfil = await _perfilService.ObterPerfilUserId(userId);
                return View(perfil);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
