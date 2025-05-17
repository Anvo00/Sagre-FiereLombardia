using Microsoft.AspNetCore.Mvc;
using Sagre_FiereLombardia.Services;
using Sagre_FiereLombardia.WSSoap;
using Sagre_FiereLombardia.Models ;
using System.Collections;

namespace Sagre_FiereLombardia.Controllers
{
    public class EventController : Controller
    {
        // Crea un'istanza con Dependency Iniection
        private readonly ILombardiaEventsService _lEventService;
        private List<string> listaComuni;
        private List<string> listaComuniSelezionati;

        public EventController(ILombardiaEventsService eventService)
        {
            _lEventService = eventService;
            listaComuni = new List<string>();
        }

        // Mostra tutti gli eventi
        public IActionResult Index(string searchQuery = null, string filterComune = "")
        {
            try {
                List<Event> events = _lEventService.GetAllEvents();

                // TODO Contare gli eventi per mettere un limite di visualizzazione (pagine come google)

                /*
                if (!string.IsNullOrEmpty(filterComune)) {
                    
                }

          

                if(string.IsNullOrWhiteSpace(searchQuery)) {
                    events = _lEventService.GetAllEvents();
                    
                } else {

                }
                */

                if(filterComune != "")
                {
                    // filtra la lista comuni
                    // mette i comuni filtrati dentro lista comuni
                    listaComuni.Add(filterComune);
                }

                if(listaComuniSelezionati.Count > 0)
                {
                    //fare il filtro deglie eventi
                }

                if (!string.IsNullOrEmpty(searchQuery)) {
                    events = events.Where(e => e.NomeEvento.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Salva i parametri di filtro nella ViewBag
                ViewBag.SearchQuery = searchQuery;
                ViewBag.listaComuni = listaComuni;
                return View();
            } 
            catch (Exception ex){
                // TODO Implementare

                ViewBag.Error = "Si è verificato un errore imprevisto: " + ex.Message;

                return View();
            }
        }

        //Mettere chiamata a task che avviene quando si preme un bottone di un comune, nella task non ritornare dati ma settare un parametro nella classe che dice quali comuni sono selezionati
        [HttpGet]
        public Task<bool> OnComuneSelezionato(string comuneCliccato)
        {
            if(listaComuni.Contains(comuneCliccato))
            {
                listaComuniSelezionati.Add(comuneCliccato);
                return true;
            }
            return false;
        }
    }
}
