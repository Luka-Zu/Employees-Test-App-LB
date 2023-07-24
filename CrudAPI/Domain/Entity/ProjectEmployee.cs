using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudAPI.Domain.Models
{
    public class ProjectEmployee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }

        public string Role { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public Employee EmployeeData { get; set; } = new Employee();
        
        public Project ProjectData { get; set; } = new Project();
    }
}
