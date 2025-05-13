using Microsoft.AspNetCore.Mvc;

namespace Sagre_FiereLombardia.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
