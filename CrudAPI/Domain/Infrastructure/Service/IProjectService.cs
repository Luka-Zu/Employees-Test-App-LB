using CrudAPI.Domain.Model;
using CrudAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Domain.Infrastructure.Service
{
    public interface IProjectService
    {
        public Task<List<ProjectViewModel>> GetProjects();

        public Task<ProjectViewModel?> GetProject(int id);

        public Task<bool> DeleteProject(int id);

        public Task<bool> UpdateProject(int id, ProjectUpdateReq project);

        public Task<bool> AddProject(ProjectUpdateReq project);


        public Task<bool> AddEmployeeToProject(int employeeId, int projectId, ProjectIntoEmployeeInsertReq projectIntoEmployeeInsertReq);


        public Task<bool> DeleteProjectFromTeam(int employeeId, int projectId);

        public Task<bool> EditEmployeesAssigmentDetailsInProject(int employeeId, int projectId, ProjectEmployeeUpdateReq req);
    }
}
