using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneDomaine.Port;
using Dahirat_AdjabaneInfrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneInfrastructure.Services
{
    public class MemberService : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetMember()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberId(int id)
        {
            var memberEntity = await _context.Members.FindAsync(id);

            if (memberEntity == null)
            {
                throw new KeyNotFoundException("Event not found");
            }
            return memberEntity;
        }

        public async Task Members(Member members)
        {
            _context.Members.Add(members);
            await _context.SaveChangesAsync();
        }
    }
}
