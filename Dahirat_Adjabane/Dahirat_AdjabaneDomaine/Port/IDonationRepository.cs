using Dahirat_AdjabaneDomaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Port
{
    public interface IDonationRepository
    {
        Task<IEnumerable<Donation>> GetAllDonationsAsync();
        Task<Donation> GetDonationByIdAsync(int id);
        Task CreateDonationAsync(Donation dons);
    }
}
