using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Project;
using Kanban_Dotnet_Backend.Models;
using Kanban_Dotnet_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kanban_Dotnet_Backend.Controllers;

[ApiController]
[Route("api/v1/Categories")]
public class ProjectController : ControllerBase
{
  private readonly IProjectService _projectService;

  public ProjectController(IProjectService projectService)
  {
    _projectService = projectService;
  }

  [HttpGet()]
  public async Task<ActionResult<ServiceResponse<List<ProjectResDTO>>>> GetAll()
  {
    var projects = await _projectService.GetAllProjects();
    return Ok(projects.Data);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ServiceResponse<List<ProjectResDTO>>>> GetSingle(int id)
  {
    return Ok(await _projectService.GetById(id));
  }

  [HttpPost()]
  public async Task<ActionResult<ServiceResponse<List<ProjectResDTO>>>> AddProject(ProjectReqDTO newProject)
  {
    return Ok(await _projectService.Create(newProject));
  }

[HttpPut("{id}")]
public async Task<ActionResult<ServiceResponse<ProjectResDTO>>> UpdateProject(int id, ProjectReqDTO updatedProject)
{
    var response = await _projectService.Update(updatedProject);

    if (!response.Success)
    {
        return NotFound(response);
    }

    return Ok(response);
}

  [HttpDelete("{id}")]
  public async Task<ActionResult<ServiceResponse<ProjectResDTO>>> Delete(int id)
  {
     var response = await _projectService.Delete(id);
     if (response.Data is null)
     {
         return NotFound(response);
     }

     return Ok(response);
  }
}