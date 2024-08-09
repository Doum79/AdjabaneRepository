using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Entity
{
    public class Donation
    {
        public int DonationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public int? EventId { get; set; }
        public int? ProjectId { get; set; }
    }
}
