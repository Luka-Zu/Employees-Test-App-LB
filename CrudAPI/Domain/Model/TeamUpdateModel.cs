using CrudAPI.Infrastracture.Services;

namespace CrudAPI.Domain.Model
{
    public class TeamUpdateModel
    {
        public string CodeName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime CreateTime { get; set; } = DateTime.Now;

    }
}
