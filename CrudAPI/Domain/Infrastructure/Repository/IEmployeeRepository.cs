using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Domain.Infrastructure.Repository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee?> GetEmployee(int id);

        public Task<bool> DeleteEmployee(int id);

        public Task<bool> UpdateEmployee(int id, EmployeeUpdateReq req);
         
        public Task<bool> AddEmployee(Employee employee);

    }
}
