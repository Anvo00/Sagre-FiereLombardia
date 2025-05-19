using Newtonsoft.Json;
using Sagre_FiereLombardia.Models;

namespace Sagre_FiereLombardia.Services
{
    public class EventService
    {
        public static async Task<List<Event>> FetchEventsAsync(string queryParams = "", int? limit = 5000)
        {
            // Endpoint API in JSON
            string BaseURI = $"https://www.dati.lombardia.it/resource/hs8z-dcey.json?$limit={limit}";
            // Il limite è di 5000 in quanto il numero di eventi si aggira attorno ai 2500 e tenendo conto dell'eliminazione
            // di eventi passati per l'aggiunta di quelli nuovi nel caso peggiore non supererebbe i 5000 circa

            if (!string.IsNullOrWhiteSpace(queryParams))
                BaseURI += $"&{queryParams}";


            // Crea un'istanza di un Client HTTP per effettuare la richiesta
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(BaseURI);


            // Controlla che l'operazione sia stata eseguita con successo
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Si è verificato il seguente errore : {response.StatusCode}");
            }

            // Traduce il contenuto della risposta in una stringa
            string contents = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<List<Event>>(contents);

            } catch(Exception e)
            {
                throw new Exception($"Si è verificato il seguente errore : {e.Message}");
            }
            // Deserializza il contenuto JSON in un oggetto Events
        }
    }
}
