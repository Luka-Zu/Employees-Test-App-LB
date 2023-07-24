using CrudAPI.Domain.Model;

namespace CrudAPI.ViewModels
{
    public class ProjectEmployeeViewModel
    {

        public string Role { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ProjectName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; } = DateTime.Now;

        



    }
}
