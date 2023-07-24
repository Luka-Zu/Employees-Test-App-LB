using System.Text.Json.Serialization;

namespace CrudAPI.ViewModels
{
    public class EmployeeViewModel
    {



        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public string PersonalNumber { get; set; } = string.Empty;

        // Navigation

        public List<ProjectEmployeeViewModel> Projects { get; set; } = new();  /// <summary>
        ///  esec shechale mere stringis magivrad rame minimalisturi projectis viewti ro lamazad iyos
        ///  jerjerobit esec mosula
        /// </summary>
        public int? TeamId{ get; set; }

        public string? TeamName { get; set; }

        public int? SuperviserEmployeeId { get; set; } = null;

    }

     
}
