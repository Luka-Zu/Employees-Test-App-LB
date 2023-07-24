using CrudAPI.Data;
using CrudAPI.Domain.Infrastructure.Repository;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee? employee = await _context.Employees
                .Include(e=>e.Team)
                .Include(e => e.Projects)
                .ThenInclude(e => e.ProjectData)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            return await _context
                .Employees
                .Include(e=>e.Team)
                .Include(e=>e.Superviser)
                .Include(e=>e.Projects)
                .ThenInclude(e => e.ProjectData)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
           
            
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees
                .Include(e=>e.Team)
                .Include(e => e.Superviser)
                .Include(e=>e.Projects)
                .ThenInclude(e=>e.ProjectData)
                .ToListAsync();
        }

  

        public async Task<bool> UpdateEmployee(int id, EmployeeUpdateReq req)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            employee.FirstName = req.FirstName;
            employee.LastName = req.LastName;
            employee.BirthDate = req.BirthDate;
            employee.EnrollmentDate = req.EnrollmentDate;
            employee.Position = req.Position;
            employee.SuperviserEmployeeId = req.SuperviserEmployeeId;
            employee.TeamId = req.TeamId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
