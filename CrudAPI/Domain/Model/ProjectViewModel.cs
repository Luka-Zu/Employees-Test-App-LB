using CrudAPI.Domain.Model;

namespace CrudAPI.ViewModels
{
    public class ProjectViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<EmployeeMinimalisticView> Employees { get; set; } = new();

    }
}
