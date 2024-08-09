using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneInfrastructure.DataContext;
using Dahirat_AdjabaneInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dahirat_AdjabaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly DonationService _donationService;
        public DonationController(DonationService donationService)
        {
            _donationService = donationService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donation>>> GetDonations()
        {
          var dons =   await _donationService.GetAllDonationsAsync();
            return Ok(dons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Donation>> GetDonation(int id)
        {
            var donation = await _donationService.GetDonationByIdAsync(id);

            if (donation == null)
            {
                return NotFound();
            }

            return donation;
        }

        [HttpPost]
        public async Task<ActionResult<Donation>> PostDonation(Donation donation)
        {
           await _donationService.CreateDonationAsync(donation);

           return CreatedAtAction(nameof(GetDonation), new { id = donation.DonationId }, donation);
        }
    }
}
