using Newtonsoft.Json;
using Sagre_FiereLombardia.Models;
using System.Text.Json.Serialization;

namespace Sagre_FiereLombardia.Services
{
    public class EventService
    {
        public static async Task<Events> FetchEventsAsync()
        {
            string BaseURI = "https://www.dati.lombardia.it/resource/hs8z-dcey.json";
            
            // TODO gestire query parametrizzata

            var client = new HttpClient();

            var response = await client.GetAsync(BaseURI);

            // TODO controllare se l'operazione viene eseguitaa con successo

            string contents = await response.Content.ReadAsStringAsync();
            

            return JsonConvert.DeserializeObject<Events>(contents);
        }
    }
}
