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
    public class ProjectController : Controller
    {
        
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectViewModel>>> GetProjects()
        {
            return await _projectService.GetProjects();

            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectViewModel>> GetProject(int id)
        {
            ProjectViewModel? Proj = await _projectService.GetProject(id);
            if(Proj == null)
            {
                return NotFound("With this ID There is not Project");
            }
            return Ok(Proj);
          
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            bool WasDeleted = await _projectService.DeleteProject(id);
            if(WasDeleted)
            {
                return NoContent();
            }
            return NotFound("With This ID no Project exists!");


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, ProjectUpdateReq request)
        {
            bool WasUpdated = await _projectService.UpdateProject(id, request);
            if (WasUpdated)
            {
                return NoContent();
            }
            return NotFound("With this Id no Project exists!");

        }



        [HttpPost]
        public async Task<ActionResult<List<ProjectViewModel>>> AddProject(ProjectUpdateReq project)
        {
            bool WasAdded = await _projectService.AddProject(project);

            if (WasAdded)
            {
                return NoContent();
            }
            return BadRequest();
        }


        [HttpDelete("RemoveProjectFromEmployee/{employeeId}/{projectId}")]
        public async Task<ActionResult> DeleteProjectFromEmployee(int employeeId, int projectId)
        {
            bool WasDeleted = await _projectService.DeleteProjectFromTeam(employeeId, projectId);
            if (WasDeleted)
            {
                return NoContent();
            }
            return NotFound();
         
        }

        [HttpPut("EditEmployeesAssigmentDetailsInProject/{employeeId}/{projectId}")]
        public async Task<ActionResult> EditEmployeesAssigmentDetailsInProject(int employeeId, int projectId, ProjectEmployeeUpdateReq req)
        {
            bool WasUpdated = await _projectService.EditEmployeesAssigmentDetailsInProject(employeeId, projectId, req);
            if (WasUpdated)
            {
                return NoContent();
            }
            return NotFound("Wrong ID");
   
        }

        [HttpPost("AssigEmployeeToProject/{employeeId}/{projectId}")]
        public async Task<ActionResult> AddEmployeeToProject(int employeeId, int projectId, ProjectIntoEmployeeInsertReq projectIntoEmployeeInsertReq)
        {
            bool WasAdded = await _projectService.AddEmployeeToProject(employeeId, projectId, projectIntoEmployeeInsertReq);
            if (WasAdded)
            {
                return NoContent();
            }
            return BadRequest();
      
        }




    }




}
