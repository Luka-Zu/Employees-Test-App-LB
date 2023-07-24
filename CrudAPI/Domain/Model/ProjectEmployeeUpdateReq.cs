namespace CrudAPI.ViewModels
{
    public class ProjectEmployeeUpdateReq
    {
        public string Role { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;

        

    }
}
