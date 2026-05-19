using Microsoft.AspNetCore.Mvc;

namespace FlowDesk.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
