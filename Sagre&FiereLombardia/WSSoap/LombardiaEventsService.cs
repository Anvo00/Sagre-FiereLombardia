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
        public List<Event> GetFilteredEventsByComune(string queryParam);

    }

    public class LombardiaEventsService : ILombardiaEventsService
    {
        public List<Event> GetAllEvents()
        {
            return EventService.FetchEventsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public List<Event> GetFilteredEventsByComune(string queryParam)
        {
            List<Event> events = GetAllEvents();
            return null;
        }
    }
}
