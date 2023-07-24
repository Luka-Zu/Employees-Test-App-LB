using AutoMapper;
using CrudAPI.Data;
using CrudAPI.Domain.Infrastructure.Service;
using CrudAPI.Domain.Model;
using CrudAPI.Domain.Models;
using CrudAPI.Infrastracture.Services;
using CrudAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Controllers
{


    [Route("/api/[controller]")]
    [ApiController]

    public class TeamController : Controller
    {


        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }


        [HttpGet]
        public async Task<ActionResult<List<TeamViewModel>>> GetTeams()
        {
            return Ok(await _teamService.GetTeams());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamViewModel>> GetTeam(int id)
        {
            TeamViewModel? Team = await _teamService.GetTeam(id);
            if(Team == null)
            {
                return NotFound("With Such ID Team does not exist!");
            }
            return Ok(Team);
        }





        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TeamViewModel>>> DeleteTeam(int id)
        {

            bool WasDeleted= await _teamService.DeleteTeam(id);
            if (WasDeleted)
            {
                return NoContent();
            }
            return NotFound("With such Id no Team exists!");

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeam(int id, TeamUpdateModel request)
        {
            bool WasUpdated = await _teamService.UpdateTeam(id, request);
            if(WasUpdated)
            {
                return NoContent();
            }
            return NotFound("With such Id no Team exists!");
        }

        [HttpPost]
        public async Task<ActionResult> AddTeam(TeamUpdateModel emp)
        {
            bool WasAdded = await _teamService.AddTeam(emp);            
            if (WasAdded)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
