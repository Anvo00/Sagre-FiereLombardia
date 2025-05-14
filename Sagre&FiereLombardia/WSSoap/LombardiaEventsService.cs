using Sagre_FiereLombardia.Models;
using Sagre_FiereLombardia.Services;
using System.ServiceModel;

namespace Sagre_FiereLombardia.WSSoap
{
    [ServiceContract]
    public interface ILombardiaEventsService
    {
        [OperationContract]
        // TODO Capire perché non si usa l'array (rivedere, nel caso, il modello)
        public List<Event> GetAllEvents();

        [OperationContract]
        public List<Event> GetFilteredEvents(string propertyName, string queryParam);

    }

    public class LombardiaEventsService : ILombardiaEventsService
    {
        public List<Event> GetAllEvents()
        {
            return EventService.FetchEventsAsync().Result;
        }

        public List<Event> GetFilteredEvents(string propertyName, string queryParam)
        {
            throw new NotImplementedException();

        }
    }
}
