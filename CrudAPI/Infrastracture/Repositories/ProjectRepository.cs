using CrudAPI.Data;
using CrudAPI.Domain.Infrastructure.Repository;
using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Infrastracture.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return true;

            
        }

        public async Task<bool> DeleteProject(int id)
        {
            Project? project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }
            _context.Projects.Remove(project);

            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Project?> GetProject(int id)
        {
            return await _context.Projects
                .Include(e=>e.Employees)
                .ThenInclude(e=>e.EmployeeData)
                .FirstOrDefaultAsync(e => e.ProjectId == id);
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _context.Projects
                .Include(e=>e.Employees)
                .ThenInclude(e=>e.EmployeeData)
                .ToListAsync();
        }

        public async Task<bool> UpdateProject(int id, ProjectUpdateReq req)
        {
            Project? proj = await _context.Projects.FindAsync(id);
            if (proj == null)
            {
                return false;
            }
            proj.CreateDate = req.CreateDate;
            proj.Name = req.Name;
            proj.Description = req.Description;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
