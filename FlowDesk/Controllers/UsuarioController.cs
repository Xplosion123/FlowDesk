using Microsoft.AspNetCore.Mvc;

namespace FlowDesk.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
