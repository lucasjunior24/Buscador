using Buscador.Models.Entitiies;
using Buscador.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrabalhadorRepository _trabalhadorRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(ILogger<HomeController> logger,
                    ITrabalhadorRepository trabalhadorRepository,
                    IClienteRepository clienteRepository,
                    UserManager<IdentityUser> userManager,
                    SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _trabalhadorRepository = trabalhadorRepository;
            this.clienteRepository = clienteRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if(signInManager.IsSignedIn(User))
            {
                var id = userManager.GetUserId(User);
                var userId = Guid.Parse(id);

                var trabalhador = await _trabalhadorRepository.ObterTrabalhadorEnderecoPorUserId(userId);
                var cliente = await clienteRepository.ObterClienteEnderecoPorUserId(userId);

                if (User.HasClaim(c => c.Type == "trabalhador") && trabalhador == null)
                    return RedirectToAction("Create", "Trabalhadores");
                if (User.HasClaim(c => c.Type == "cliente") && cliente == null)
                {
                    return RedirectToAction("Create", "cliente");
                }
            }

            return View();
        }

        [Authorize]
        public IActionResult SelecionarPerfil()
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
