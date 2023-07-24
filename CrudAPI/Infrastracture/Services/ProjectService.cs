using CrudAPI.Domain.Infrastructure.Repository;
using CrudAPI.Domain.Infrastructure.Service;
using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.Infrastracture.Repositories;
using CrudAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Infrastracture.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;

        public ProjectService(IProjectRepository repository, IProjectEmployeeRepository projectEmployeeRepository , IEmployeeRepository employeeRepository )
        {
            _projectRepository = repository;
            _projectEmployeeRepository = projectEmployeeRepository;
            _employeeRepository = employeeRepository;
        }




        public async Task<bool> AddProject(ProjectUpdateReq project)
        {
            Project Proj = new Project();
            Proj.Name = project.Name;
            Proj.Description = project.Description;
            Proj.CreateDate = project.CreateDate;

            await _projectRepository.AddProject(Proj);
            return true;
        }

        public async Task<bool> AddEmployeeToProject(int employeeId, int projectId, ProjectIntoEmployeeInsertReq projectIntoEmployeeInsertReq)
        {
            Project? project = await _projectRepository.GetProject(projectId);
            Employee? employee = await _employeeRepository.GetEmployee(employeeId);
            if (project == null || employee == null)
            {
                return false;
            }

            ProjectEmployee ProjEmpl = new()
            {
                EmployeeId = employeeId,
                ProjectId = projectId,
                ProjectData = project,
                EmployeeData = employee,
                Description = projectIntoEmployeeInsertReq.Description,
                Role = projectIntoEmployeeInsertReq.Role,
                StartDate = projectIntoEmployeeInsertReq.StartDate,
            };
            return await _projectEmployeeRepository.AddProjectEmployee(ProjEmpl);
        }

        public async Task<bool> DeleteProjectFromTeam(int employeeId, int projectId)
        {
            return await _projectEmployeeRepository.DeleteProjectEmployee(projectId, employeeId);
        }

        public Task<bool> DeleteProject(int id)
        {
            return _projectRepository.DeleteProject(id);

 
        }

        public async Task<bool> EditEmployeesAssigmentDetailsInProject(int employeeId, int projectId, ProjectEmployeeUpdateReq req)
        {
            return await _projectEmployeeRepository.UpdateProjectEmployee(projectId, employeeId, req);
        }

        public async Task<ProjectViewModel?> GetProject(int id)
        {
            Project? Proj = await _projectRepository.GetProject(id);
            if (Proj == null)
            {
                return null;
            }

            ProjectViewModel projectViewModel = new ProjectViewModel()
            {
                Name = Proj.Name,
                Description = Proj.Description,
                CreateDate = Proj.CreateDate,
                Employees = Proj.Employees.Select(emp => new EmployeeMinimalisticView
                {
                    FirstName = emp.EmployeeData.FirstName,
                    LastName = emp.EmployeeData.LastName
                }).ToList()

            };
            return projectViewModel;
        }

        public async Task<List<ProjectViewModel>> GetProjects()
        {
            List<ProjectViewModel> ProjectViewModels = new List<ProjectViewModel>();

            List<Project> Projects = await _projectRepository.GetProjects();
            foreach (var project in Projects)
            {
                ProjectViewModel projectViewModel = new ProjectViewModel()
                {
                    Name = project.Name,
                    Description = project.Description,
                    CreateDate = project.CreateDate,
                    Employees = project.Employees.Select(emp => new EmployeeMinimalisticView
                    {
                        FirstName = emp.EmployeeData.FirstName,
                        LastName = emp.EmployeeData.LastName
                    }).ToList()

                };
                ProjectViewModels.Add(projectViewModel);

            }
            return ProjectViewModels;


        }

        public async Task<bool> UpdateProject(int id, ProjectUpdateReq project)
        {
            return await _projectRepository.UpdateProject(id, project);
        }

      
    }
}
