using AutoMapper;
using CrudAPI.Domain.Infrastructure.Repository;
using CrudAPI.Domain.Infrastructure.Service;
using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;

namespace CrudAPI.Infrastracture.Services
{

    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository repository)
        {
            _teamRepository = repository;
        }


        public async Task<bool> AddTeam(TeamUpdateModel teamView)
        {
            Team Team = new()
            {
                Name = teamView.Name,
                CodeName = teamView.CodeName,
                CreateDate = teamView.CreateTime,
            };
            return await _teamRepository.AddTeam(Team);

        }

        public async Task<bool> DeleteTeam(int id)
        {
            return await _teamRepository.DeleteTeam(id);
        }

        public async Task<TeamViewModel?> GetTeam(int id)
        {
            Team? Team = await _teamRepository.GetTeam(id);
            if (Team == null)
            {
                return null;
            }
            TeamViewModel TeamViewModel = new()
            {
                Name = Team.Name,
                CodeName = Team.CodeName,
                CreateTime = Team.CreateDate,
                EmployeeNames = Team.Employees.Select(emp => new EmployeeMinimalisticView
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName
                }).ToList()
            };

            return TeamViewModel;
        }

        public async Task<List<TeamViewModel>> GetTeams()
        {
            List<Team> teams = await _teamRepository.GetTeams();

            return teams.Select(team => new TeamViewModel
            {
                Name = team.Name,
                CodeName = team.CodeName,
                CreateTime = team.CreateDate,
                EmployeeNames = team.Employees.Select(emp => new EmployeeMinimalisticView
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName
                }).ToList()
            }).ToList();
        }


        public async Task<bool> UpdateTeam(int id, TeamUpdateModel team)
        {
            return await _teamRepository.UpdateTeam(id, team);
           
        }
    }
}
