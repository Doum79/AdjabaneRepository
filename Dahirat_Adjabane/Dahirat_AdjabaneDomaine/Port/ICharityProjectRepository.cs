using Dahirat_AdjabaneDomaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dahirat_AdjabaneDomaine.Port
{
    public interface ICharityProjectRepository
    {
        Task<IEnumerable<CharityProject>> GetAllProjectsAsync();
        Task<CharityProject> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(CharityProject project);
        Task UpdateProjectAsync(int id, CharityProject projectDto);
        Task DeleteProjectAsync(int id);
    }
}
