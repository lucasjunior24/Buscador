using Buscador.Extensions;
using Buscador.Models;
using Buscador.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class AutenticacaoController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AutenticacaoController(SignInManager<IdentityUser> signInManager, 
                                      UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult CriarUsuario()
        {
            var usuarioViewModel = new UsuarioViewModel()
            {
                Perfils = EnumHelper.CriarListaDeEnum<Perfil>()
            };
            return View(usuarioViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = usuarioViewModel.Email, Email = usuarioViewModel.Email,  };
                var result = await _userManager.CreateAsync(user, usuarioViewModel.Password);
                if (result.Succeeded)
                {
                    if (usuarioViewModel.Perfil == "trabalhador")
                    {
                        await _userManager.AddClaimAsync(user, new Claim("trabalhador", "trabalhador"));
                    }
                    else
                    {
                        await _userManager.AddClaimAsync(user, new Claim("cliente", "cliente"));
                    }
                    return RedirectToAction("FazerLogin");
                }
            }
            return StatusCode(500, "Falha ao criar conta!");
        }

        public IActionResult FazerLogin()
        {
            var login = new LoginViewModel();

            return View(login);
        }
        [HttpPost]
        public async Task<IActionResult> FazerLogin(LoginViewModel login)
        {
            //var user = new IdentityUser { Email = Input.Email };

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("FazerLogin");
        }
    }
}
