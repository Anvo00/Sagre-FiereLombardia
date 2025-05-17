using Newtonsoft.Json;
using Sagre_FiereLombardia.Models;
using System.Text.Json.Serialization;

namespace Sagre_FiereLombardia.Services
{
    public class EventService
    {
        public static async Task<List<Event>> FetchEventsAsync()
        {
            // Endpoint API in JSON
            string BaseURI = "https://www.dati.lombardia.it/resource/hs8z-dcey.json?filter=5000";
            // Il limite è di 5000 in quanto il numero di eventi si aggira attorno ai 2500 e tenendo conto dell'eliminazione
            // di eventi passati per l'aggiunta di quelli nuovi nel caso peggiore non supererebbe i 5000 circa


            // Crea un'istanza di un Client HTTP per effettuare la richiesta
            var client = new HttpClient();
            var response = await client.GetAsync(BaseURI);


            // Controlla che l'operazione sia stata eseguita con successo
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Si è verificato il seguente errore : {response.StatusCode}");
            }

            // Traduce il contenuto della risposta in una stringa
            string contents = await response.Content.ReadAsStringAsync();

            // Deserializza il contenuto JSON in un oggetto Events
            return JsonConvert.DeserializeObject<List<Event>>(contents);
        }
    }
}
