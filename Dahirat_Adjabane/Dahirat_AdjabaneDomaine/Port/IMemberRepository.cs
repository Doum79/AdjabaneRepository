using Dahirat_AdjabaneDomaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Port
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMember();
        Task<Member> GetMemberId(int id);
        Task Members(Member members);
    }
}
