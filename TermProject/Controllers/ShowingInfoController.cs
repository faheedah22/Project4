using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class ShowingInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
