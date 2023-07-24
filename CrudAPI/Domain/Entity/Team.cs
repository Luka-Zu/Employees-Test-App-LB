using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client.Kerberos;
using Azure;

namespace CrudAPI.Domain.Models
{
    public class Team
    {

        public int TeamId { get; set; }
        public string CodeName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; } = DateTime.Now; 
        public List<Employee> Employees { get; set; } = new List<Employee>(); 


    }
}
