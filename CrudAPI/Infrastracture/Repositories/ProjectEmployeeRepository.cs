using CrudAPI.Data;
using CrudAPI.Domain.Infrastructure.Repository;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Infrastracture.Repositories
{
    
    public class ProjectEmployeeRepository : IProjectEmployeeRepository
    {
        private readonly DataContext _context;

        public ProjectEmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProjectEmployee(ProjectEmployee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProjectEmployee(int projectId, int employeeId)
        {
            ProjectEmployee? projectEmployee = await _context.ProjectEmployees
                .FirstOrDefaultAsync(e=>e.EmployeeId == employeeId && e.ProjectId == projectId);
            if (projectEmployee == null)
            {
                return false;
            }
            _context.ProjectEmployees.Remove(projectEmployee);
            _context.SaveChanges();
            return true;
         
        }

        public async Task<Employee?> GetEmployeeById(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<Project?> GetProjectById(int projectId)
        {
            return await _context.Projects.FindAsync(projectId);
        }

        public async Task<ProjectEmployee?> GetProjectEmployee(int projectId, int employeeId)
        {
            return await _context.ProjectEmployees
                .Include(e => e.EmployeeData)
                .Include(e => e.ProjectData)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.ProjectId == projectId);
        }

        public async Task<List<ProjectEmployee>> GetProjectEmployees()
        {
            return await _context.ProjectEmployees
                .Include(e => e.EmployeeData)
                .Include(e => e.ProjectData)
                .ToListAsync();

        }

        public async Task<bool> UpdateProjectEmployee(int projectId, int employeeId, ProjectEmployeeUpdateReq req)
        {
            ProjectEmployee? projectEmployee = await _context.ProjectEmployees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.ProjectId == projectId);
            if (projectEmployee == null)
            {
                return false;
            }
            projectEmployee.StartDate = req.StartDate;
            projectEmployee.Role = req.Role;
            projectEmployee.Description = req.Description;

            await _context.SaveChangesAsync();
            return true;
            
        }
    }
}

