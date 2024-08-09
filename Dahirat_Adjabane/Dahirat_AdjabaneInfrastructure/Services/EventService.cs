using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneDomaine.Port;
using Dahirat_AdjabaneInfrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneInfrastructure.Services
{
    public class EventService : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventService (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);

            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }
            return eventEntity;

        }
        public async Task CreateEventAsync(Event events)
        {
            _context.Events.Add(events);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }
            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

     

        public async Task UpdateEventAsync(int id, Event events)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }
            await _context.SaveChangesAsync();
        }
    }
}
