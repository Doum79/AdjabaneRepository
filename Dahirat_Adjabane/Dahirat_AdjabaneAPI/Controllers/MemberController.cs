using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Dahirat_AdjabaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberService _memberService;

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
          var member =   await _memberService.GetMember();

            return Ok(member);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _memberService.GetMemberId(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
           await _memberService.Members(member);
           
           return CreatedAtAction(nameof(GetMember), new { id = member.MemberId }, member);
        }
    }
}
