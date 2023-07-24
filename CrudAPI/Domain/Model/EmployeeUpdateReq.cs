using System.Text.Json.Serialization;

namespace CrudAPI.ViewModels
{
    public class EmployeeUpdateReq
    {



        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // Navigation
        public int? TeamId { get; set; }

        public int? SuperviserEmployeeId { get; set; } = null;

    }


}
