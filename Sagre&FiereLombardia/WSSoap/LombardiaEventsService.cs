using Sagre_FiereLombardia.Models;

namespace Sagre_FiereLombardia.WSSoap
{
    public interface ILombardiaEventsService
    {
        public Events[] GetAllEvents();
        public Events[] GetFilteredEvents(string Filter);

    }

    public class LombardiaEventsService : ILombardiaEventsService
    {
        public Events[] GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Events[] GetFilteredEvents(string Filter)
        {
            throw new NotImplementedException();
        }
    }
}
