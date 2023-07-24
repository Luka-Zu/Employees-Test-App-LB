using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;

namespace CrudAPI.Domain.Infrastructure.Repository
{
    public interface IProjectEmployeeRepository
    {
        public Task<List<ProjectEmployee>> GetProjectEmployees();

        public Task<ProjectEmployee?> GetProjectEmployee(int projectId, int employeeId);

        public Task<bool> DeleteProjectEmployee(int projectId, int employeeId);

        public Task<bool> AddProjectEmployee(ProjectEmployee employee);

        public Task<bool> UpdateProjectEmployee(int projectId, int employeeId, ProjectEmployeeUpdateReq req);




        // es washaleeeeeeeeeeee uechveli mere aq arunda iyos
        public Task<Employee?> GetEmployeeById(int employeeId);

        // es washaleeeeeeeeeeee uechveli mere aq arunda iyos 
        public Task<Project?> GetProjectById(int projectId);
    }
}
