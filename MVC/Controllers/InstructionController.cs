using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class InstructionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
