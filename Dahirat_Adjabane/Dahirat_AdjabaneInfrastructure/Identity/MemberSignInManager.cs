using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneDomaine.Port;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneInfrastructure.Identity
{
    public class MemberSignInManager : IMemberSignInManager
    {
        UserManager<Member> _memberUserManager;
        SignInManager<Member> _signInManager;
        private readonly RoleManager<MemberRole> roleManager;

        public MemberSignInManager(UserManager<Member> memberUserManager, SignInManager<Member> signInManager)
        {
            _memberUserManager = memberUserManager;
            _signInManager = signInManager;
           
        }


        public async Task<string> SignInJwt(string UserName, string Password)
        {
            var user = await _memberUserManager.FindByNameAsync(UserName);

            if (user == null)
                return string.Empty;

            var goodpassword = await _memberUserManager.CheckPasswordAsync(user, Password);

            if (!goodpassword)
                return string.Empty;



            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(0.5)).ToUnixTimeSeconds().ToString()),
            };

            if (user.UserType == 3)
            {
                var role = await _memberUserManager.GetRolesAsync(user);

                new Claim(ClaimTypes.NameIdentifier, user.EtbCode);
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber);
                new Claim(ClaimTypes.Name, user.UserName);
                new Claim(ClaimTypes.Role, role.Count > 0 ? role[0] : "");
            }

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Str@tageme_$ecurity_Corporate_[2020]_Ariel_Tech")), SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public async Task<SignInResult> SignInManager(string UserName, string Password, bool IsPersistent = false, bool shouldLockOutOnFail = false)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(UserName, Password, IsPersistent, shouldLockOutOnFail);
                return result;
            }
            catch (Exception ex)
            {
                return SignInResult.Failed;
            }
        }


        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
