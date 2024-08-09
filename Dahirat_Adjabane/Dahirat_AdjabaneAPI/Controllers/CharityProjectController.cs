using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dahirat_AdjabaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityProjectController : ControllerBase
    {
        private readonly CharityProjectService _charityProjectService;

        public CharityProjectController(CharityProjectService project)
        {
            _charityProjectService = project;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharityProject>>> GetAllProjects()
        {
            var projects = await _charityProjectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharityProject>> GetProject(int id)
        {
            var project = await _charityProjectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(CharityProject project)
        {
            await _charityProjectService.CreateProjectAsync(project);
            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, CharityProject projectDto)
        {
            try
            {
                await _charityProjectService.UpdateProjectAsync(id, projectDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _charityProjectService.DeleteProjectAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
