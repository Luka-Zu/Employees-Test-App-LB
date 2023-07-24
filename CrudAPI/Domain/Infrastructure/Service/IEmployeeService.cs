using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Domain.Infrastructure.Service
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployeesTest();

        public Task<List<EmployeeViewModel>> GetEmployees();

        public Task<EmployeeViewModel?> GetEmployee(int id);

        public Task<bool> DeleteEmployee(int id);

        public Task<bool> UpdateEmployee(int id, EmployeeUpdateReq employee); 
        public Task<bool> AddEmployee(EmployeeUpdateReq employee);

        public Task<bool> AddProjectToEmployee(int employeeId, int projectId, ProjectIntoEmployeeInsertReq projectIntoEmployeeInsertReq);

        public Task<bool> DeleteEmployeeFromProject(int employeeId, int projectId);

        public Task<bool> EditEmployeesAssigmentDetailsInProject(int employeeId, int projectId, ProjectEmployeeUpdateReq ProjectEmployeeUpdateReq);

        public Task<string> IsSubordinateOf(int superviserId, int empId);
    }
}
