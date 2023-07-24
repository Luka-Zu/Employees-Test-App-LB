using CrudAPI.Data;
using CrudAPI.Domain.Infrastructure.Repository;
using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Infrastracture.Repositories
{

    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _context;

        public TeamRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddTeam(Team Team)
        {
            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();

            return true;
       
        }

        public async Task<bool> DeleteTeam(int id)
        {
            Team? Team = await _context.Teams.FindAsync(id);
            if(Team == null) {
                return false;
            }
            _context.Teams.Remove(Team);    
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<Team?> GetTeam(int id)
        {
            return await _context.Teams
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(e => e.TeamId == id);
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Teams.Include(e => e.Employees)
                .ToListAsync();

        }

        public async Task<bool> UpdateTeam(int id, TeamUpdateModel req)
        {
            Team? ToUpdate = await _context.Teams.FindAsync(id);
            if (ToUpdate == null)
            {
                return false;
            }

            ToUpdate.CreateDate = req.CreateTime;
            ToUpdate.CodeName = req.CodeName;  
            ToUpdate.Name = req.Name;
            
            await _context.SaveChangesAsync();

            return true;
            
        }
    }
}
