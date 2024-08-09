using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Entity
{
    public class Member : IdentityUser<string>
    {

        public int MemberId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string PostMember { get; set; }
        public string Roles { get; set; }
        public string Phone { get; set; }
        public string EtbCode { get; set; }
        public string Email { get; set; }
        public int? UserType { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
