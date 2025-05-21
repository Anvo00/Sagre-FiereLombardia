using Sagre_FiereLombardia.Models;
using Sagre_FiereLombardia.Services;
using System.ServiceModel;

namespace Sagre_FiereLombardia.WSSoap
{
    [ServiceContract]
    public interface ILombardiaEventsService
    {
        [OperationContract]
        public List<Event> GetAllEvents();

        [OperationContract]
        public List<Event> GetEventsByComune(string queryParam);
        
        [OperationContract]
        public List<Event> GetEventsByName(string queryParam);
        
    }

    public class LombardiaEventsService : ILombardiaEventsService
    {
        public List<Event> GetAllEvents()
        {
            return EventService.FetchEventsAsync().Result;
        }


        public List<Event> GetEventsByComune(string queryParam)
        {
            List<Event> events = GetAllEvents();
            return events.Where(e => e.Comune.Replace("  ","").StartsWith(queryParam, StringComparison.OrdinalIgnoreCase)).ToList();    
        }


        public List<Event> GetEventsByName(string queryParam)
        {
            List<Event> events = GetAllEvents();
            return events.Where(e => e.NomeEvento.Replace("  ", "").StartsWith(queryParam, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
