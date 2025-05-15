using Microsoft.AspNetCore.Mvc;
using Sagre_FiereLombardia.Services;
using Sagre_FiereLombardia.WSSoap;

namespace Sagre_FiereLombardia.Controllers
{
    public class EventController : Controller
    {
        // Crea un'istanza con Dependency Iniection
        private readonly LombardiaEventsService _lEventService;

        public EventController(LombardiaEventsService eventService)
        {
            _lEventService = eventService;
        }

        // Mostra tutti gli eventi
        public IActionResult Index()
        {
            return View();
        }

        // Mostra gli eventi filtrati
        public IActionResult Filter()
        {
            return View();
        }
    }
}
