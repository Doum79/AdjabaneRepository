using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneDomaine.Port;
using Dahirat_AdjabaneInfrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneInfrastructure.Services
{
    public class DonationService : IDonationRepository
    {
        private readonly ApplicationDbContext _context;

        public DonationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateDonationAsync(Donation dons)
        {
            _context.Donations.Add(dons);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Donation>> GetAllDonationsAsync()
        {
            return await _context.Donations.ToListAsync();
        }

        public async Task<Donation> GetDonationByIdAsync(int id)
        {
            var DonationEntity = await _context.Donations.FindAsync(id);

            if (DonationEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }
            return DonationEntity;
        }
    }
}
