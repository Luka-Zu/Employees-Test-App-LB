
using System.ComponentModel.DataAnnotations;

namespace CrudAPI.Domain.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;



        public DateTime? BirthDate { get; set; } = null;

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The PersonalNumber must be exactly 11 digits.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The PersonalNumber must contain only digits.")]
        public string PersonalNumber { get; set; } = string.Empty; // 11-digit personal number

        // Navigation
        public int? TeamId { get; set; }
        public Team? Team { get; set; }

        public List<ProjectEmployee> Projects { get; } = new();


        public Employee? Superviser { get; set; }
        public int? SuperviserEmployeeId { get; set; }
        public List<Employee> Subordinates { get; set; } = new();

    
    }
}
