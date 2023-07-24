using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;

namespace CrudAPI.Domain.Infrastructure.Repository
{
    public interface ITeamRepository
    {
        public Task<List<Team>> GetTeams();
        public Task<Team?> GetTeam(int id);

        public Task<bool> DeleteTeam(int id);

        public Task<bool> UpdateTeam(int id, TeamUpdateModel req);

        public Task<bool> AddTeam(Team Team);
    }
}
