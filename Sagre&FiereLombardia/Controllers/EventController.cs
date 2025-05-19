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
        private List<string> listComuni;
        private string selectedComune = "";
        private List<Event> events;

        public EventController(ILombardiaEventsService eventService)
        {
            _lEventService = eventService;
            listComuni = new List<string>();
            events = new List<Event>();
        }

        // Mostra tutti gli eventi
        public IActionResult Index(string searchQuery = "", string filterComune = "", string selectedComune = "")
        {

            try
            {

                // Popolazione della lista degli eventi con tutti gli eventi disponibili nel dataset
                events = _lEventService.GetAllEvents();

                // TODO Contare gli eventi per mettere un limite di visualizzazione (pagine come google)
                int nEvent = events.Count;
                // ...

                // Popolazione della lista dei comuni con tutti i comuni disponibili nel dataset
                // TODO Mettere un massimo di comuni visualizzati nella lista

                listComuni = events.Select(e => e.Comune).Distinct().ToList();
                // Alternativa con foreach (commentato)
                // foreach (Event e in events) {listComuni.Add(e.Comune);}


                // Ricerca e visualizzazione della lista dei comuni con filtro
                if (!string.IsNullOrEmpty(filterComune))
                {
                    // Filtra la lista dei comuni in base alla ricerca dell'utente
                    listComuni = listComuni.Where(c =>
                        c.Replace(" ", "").StartsWith(filterComune.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)).ToList();
                    // Replace(" ","") -> ignora gli spazi
                }

                // Controlla se c'è un comune selezionato e filtra tutti gli eventi
                if (!string.IsNullOrEmpty(selectedComune))
                {
                    events = events.Where(e =>
                        e.Comune.StartsWith(selectedComune, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Controlla se c'è un input nella barra di ricerca degli eventi
                // Se la lista è già stata filtrata per comune, allora esegue una ricerca sulla lista filtrata, su tutto altrimenti
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    events = events.Where(e =>
                        e.NomeEvento.Replace(" ", "").StartsWith(searchQuery.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Salva i risultati filtrati nella ViewBag
                ViewBag.filteredEvents = events;
                ViewBag.listComuni = listComuni;

                // Salva i parametri nella ViewBag
                ViewBag.searchQuery = searchQuery;
                ViewBag.selectedComune = selectedComune;
                ViewBag.filterComune = filterComune; // Serve??

                return View();

            }
            catch (Exception ex)
            {

                // Codice preso dal progetto degli altri - CONTROLLARE!!!
                ViewBag.Error = "Si è verificato un errore imprevisto: " + ex.Message;
                ViewBag.filteredEvents = new List<Event>();
                ViewBag.listComuni = new List<string>();

                return View();
            }
        }
    }
}
