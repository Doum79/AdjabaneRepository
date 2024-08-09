using Dahirat_AdjabaneDomaine.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Port
{
    public interface IMemberRoleManager
    {
        Task<IdentityResult> CreateRole(string RoleName);
        ICollection<MemberRole> FindAllRole();
        Task<MemberRole> GetUserRole(string Id);
        Task<bool> AssignClaim(string Id, Claim claim);
        Task<bool> AssignClaim(string Id, string type, string value);
        Task<bool> RemoveClaim(string Id, Claim claim);
        Task<ICollection<Claim>> GetAllClaim(string Id);
    }
}
