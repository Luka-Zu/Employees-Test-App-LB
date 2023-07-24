namespace CrudAPI.Domain.Model
{
    public class ProjectUpdateReq
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
