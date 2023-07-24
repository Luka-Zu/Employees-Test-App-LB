using Azure;

namespace CrudAPI.Domain.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public List<ProjectEmployee> Employees { get; } = new();


    }
}
