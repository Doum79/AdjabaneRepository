using Dahirat_AdjabaneDomaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Port
{
    public interface IEventRepository
    { 
      Task<IEnumerable<Event>> GetAllEventsAsync();
    Task<Event> GetEventByIdAsync(int id);
    Task CreateEventAsync(Event events);
    Task UpdateEventAsync(int id, Event events);
    Task DeleteEventAsync(int id);
}
}
