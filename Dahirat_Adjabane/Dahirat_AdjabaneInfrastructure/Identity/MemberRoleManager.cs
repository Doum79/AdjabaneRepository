using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneDomaine.Port;
using Dahirat_AdjabaneInfrastructure.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneInfrastructure.Identity
{
    public class MemberRoleManager : IMemberRoleManager
    {
      private readonly  ApplicationDbContext _context;
      private readonly RoleManager<MemberRole> _roleManager;

        public MemberRoleManager(ApplicationDbContext context, RoleManager<MemberRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateRole(string RoleName)
        {
            try
            {
                var isRoleExists = await _roleManager.RoleExistsAsync(RoleName.ToUpper());
                if (!isRoleExists)
                {
                    var result = await _roleManager.CreateAsync(new MemberRole { Name = RoleName });
                    return result;
                }

                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Success;
            }
        }



        public ICollection<MemberRole> FindAllRole()
        {
            try
            {
                var roles = _roleManager.Roles.ToList();
                return roles;
            }
            catch (Exception ex)
            {
                return new List<MemberRole>();
            }
        }

        public async Task<MemberRole> GetUserRole(string Id)
        {
            try
            {
                var roleId = _context.UserRoles.Where(ur => ur.UserId == Id).FirstOrDefault();
                if (roleId != null)
                {
                    var role = await _roleManager.FindByIdAsync(roleId.RoleId.ToString());
                    return role;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AssignClaim(string Id, Claim claim)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id);
                var result = await _roleManager.AddClaimAsync(role, claim);

                if (result.Succeeded)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AssignClaim(string Id, string type, string value)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id);
                var result = await _roleManager.AddClaimAsync(role, new Claim(type, value));

                if (result.Succeeded)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveClaim(string Id, Claim claim)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id);
                var result = await _roleManager.RemoveClaimAsync(role, claim);

                if (result.Succeeded)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ICollection<Claim>> GetAllClaim(string Id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id);
                var result = await _roleManager.GetClaimsAsync(role);

                return result;
            }
            catch (Exception ex)
            {
                return new List<Claim>();
            }
        }
    }
}
