using CrudAPI.Domain.Model;

namespace CrudAPI.ViewModels
{
    public class TeamViewModel
    {
        public string CodeName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public List<EmployeeMinimalisticView> EmployeeNames { get; set; } = new List<EmployeeMinimalisticView> {};



    }
}
