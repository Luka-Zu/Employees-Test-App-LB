using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;

namespace CrudAPI.Domain.Infrastructure.Service
{
    public interface ITeamService
    {
        public Task<List<TeamViewModel>> GetTeams();

        public Task<TeamViewModel?> GetTeam(int id);

        public Task<bool> DeleteTeam(int id);

        public Task<bool> UpdateTeam(int id, TeamUpdateModel team);

        public Task<bool> AddTeam(TeamUpdateModel team);


    }
}
