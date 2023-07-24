using CrudAPI.Domain.Infrastructure.Repository;
using CrudAPI.Domain.Infrastructure.Service;
using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;


namespace CrudAPI.Infrastracture.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository
            , IProjectRepository projectRepository
            , IProjectEmployeeRepository projectEmployeeRepository)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
        }

        public async Task<List<Employee>> GetEmployeesTest()
        {
            return await _employeeRepository.GetEmployees();
        }
        public async Task<List<EmployeeViewModel>> GetEmployees()
        {
            List<Employee> employees = await _employeeRepository.GetEmployees();

            List<EmployeeViewModel> employeeViewModels = new();

            foreach (Employee emp in employees)
            {

                EmployeeViewModel EmpView = MapEmployeeToView(emp)!; // Can not be null
                employeeViewModels.Add(EmpView!);
            }

            return employeeViewModels;

        }

        public async Task<EmployeeViewModel?> GetEmployee(int id)
        {
            Employee? employee = await _employeeRepository.GetEmployee(id);
            EmployeeViewModel? EmployeeView = MapEmployeeToView(employee);

            return EmployeeView;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            bool WasDeleted = await _employeeRepository.DeleteEmployee(id);
            

            return WasDeleted;
        }

        public async Task<bool> UpdateEmployee(int id, EmployeeUpdateReq request)
        {
            bool WasUpdated = await _employeeRepository.UpdateEmployee(id, request);
            
            

            return WasUpdated;
          
        }
        
        public async Task<bool> AddEmployee(EmployeeUpdateReq request)
        {
            Employee ToAdd = new() 
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Position = request.Position,
                BirthDate = request.BirthDate,
                EnrollmentDate = request.EnrollmentDate,
                TeamId = request.TeamId,
                SuperviserEmployeeId = request.SuperviserEmployeeId

            };
            await _employeeRepository.AddEmployee(ToAdd);
         
            return true;
        }


        private EmployeeViewModel? MapEmployeeToView(Employee? employee)
        {
            if (employee == null)
            {
                return null;
            }
            

            EmployeeViewModel EmployeeView = new()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                BirthDate = employee.BirthDate,
                EnrollmentDate = employee.EnrollmentDate,
                TeamId = employee.TeamId,
                SuperviserEmployeeId = employee.SuperviserEmployeeId,
                PersonalNumber = employee.PersonalNumber,
                Projects = employee.Projects.Select(proj => new ProjectEmployeeViewModel
                {
                    Description = proj.Description,
                    ProjectName = proj.ProjectData.Name,
                    Role = proj.Role,
                    StartDate = proj.StartDate,
                }).ToList()
            };
            if (employee.Team != null)
            {
                EmployeeView.TeamName = employee.Team.Name;
            }
            
            return EmployeeView;
        }


        public async Task<bool> AddProjectToEmployee(int employeeId, int projectId, ProjectIntoEmployeeInsertReq projectIntoEmployeeInsertReq)
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

        public async Task<bool> DeleteEmployeeFromProject(int employeeId, int projectId)
        {

            return await _projectEmployeeRepository.DeleteProjectEmployee(projectId, employeeId);            
        }

        public async Task<bool> EditEmployeesAssigmentDetailsInProject(int employeeId, int projectId, ProjectEmployeeUpdateReq ProjectEmployeeUpdateReq)
        {
            return await _projectEmployeeRepository.UpdateProjectEmployee(projectId, employeeId, ProjectEmployeeUpdateReq);
            
        }

        public async Task<string> IsSubordinateOf(int superviserId, int empId)
        {
   

            Employee? SuperviserEmp = await _employeeRepository.GetEmployee(superviserId);
            Employee? Emp = await _employeeRepository.GetEmployee(empId);

            if (Emp == null || SuperviserEmp == null)
            {
                return "Wrong IDs";
            }


            while(Emp.Superviser != null) 
            { 
            
                Emp = Emp.Superviser;
                if (Emp.EmployeeId == SuperviserEmp.EmployeeId)
                {
                    return "Is Subordinate";
                }

            }

            return "Is not Subordinate";


        }
    }
}
