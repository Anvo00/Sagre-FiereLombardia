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
        public Events GetAllEvents();

        [OperationContract]
        public Events[] GetFilteredEvents(string Filter);

    }

    public class LombardiaEventsService : ILombardiaEventsService
    {
        public Events GetAllEvents()
        {
            return EventService.FetchEventsAsync().Result;
        }

        public Events[] GetFilteredEvents(string Filter)
        {
            throw new NotImplementedException();

        }
    }
}
