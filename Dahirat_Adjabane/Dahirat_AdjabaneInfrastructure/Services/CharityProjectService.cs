using Dahirat_AdjabaneDomaine.Entity;
using Dahirat_AdjabaneDomaine.Port;
using Dahirat_AdjabaneInfrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneInfrastructure.Services
{
    public class CharityProjectService : ICharityProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public CharityProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateProjectAsync(CharityProject project)
        {
            _context.CharityProjects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.CharityProjects.FindAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found");
            }
            _context.CharityProjects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CharityProject>> GetAllProjectsAsync()
        {
            return await _context.CharityProjects.ToListAsync();
        }

        public async Task<CharityProject> GetProjectByIdAsync(int id)
        {
            var project = await _context.CharityProjects.FindAsync(id);

            if (project == null)
            {
                throw new KeyNotFoundException("Event not found");
            }
            return project;
        }

        public async Task UpdateProjectAsync(int id, CharityProject projectDto)
        {
            var project = await _context.CharityProjects.FindAsync(id);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found");
            }
            await _context.SaveChangesAsync();
        }
    }
}
