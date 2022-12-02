using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Buscador.Controllers
{
    public class AgendamentoController : BaseController
    {
        public AgendamentoController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid trabalhadorId)
        {


            return RedirectToAction("Index", "Trabalhadores");
        }
    }
}
