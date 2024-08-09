using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Port
{
    public interface IMemberSignInManager
    {
        Task<SignInResult> SignInManager(string UserName, string Password, bool IsPersistent = false, bool shouldLockOutOnFail = false);
        Task<string> SignInJwt(string UserName, string Password);
        Task SignOut();
    }
}
