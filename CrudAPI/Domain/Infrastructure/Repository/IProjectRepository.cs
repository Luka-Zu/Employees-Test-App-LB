using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;

namespace CrudAPI.Domain.Infrastructure.Repository
{
    public interface IProjectRepository
    {
        public Task<List<Project>> GetProjects();
        public Task<Project?> GetProject(int id);

        public Task<bool> DeleteProject(int id);

        public Task<bool> UpdateProject(int id, ProjectUpdateReq req);

        public Task<bool> AddProject(Project project);
    }
}
