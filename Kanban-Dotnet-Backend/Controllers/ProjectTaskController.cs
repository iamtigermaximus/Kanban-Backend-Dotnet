using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Project;
using Kanban_Dotnet_Backend.DTOs.ProjectTask;
using Kanban_Dotnet_Backend.Models;
using Kanban_Dotnet_Backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace Kanban_Dotnet_Backend.Controllers;


[ApiController]
[Route("api/v1/ProjectTasks")]
public class ProjectTaskController : ControllerBase
{
    private readonly IProjectTaskService _projectTaskService;

    public ProjectTaskController(IProjectTaskService projectTaskService)
    {
        _projectTaskService = projectTaskService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<ProjectTaskResDTO>>>> GetAll()
    {
        var projects = await _projectTaskService.GetAllProjectTasks();
        return Ok(projects.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<ProjectTaskResDTO>>>> GetSingle(int id)
    {
        return Ok(await _projectTaskService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<ProjectTaskResDTO>>>> AddProjectTask(ProjectTaskReqDTO newProjectTask)
    {
        return Ok(await _projectTaskService.Create(newProjectTask));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectTaskResDTO>>> UpdateProjectTask(int id, ProjectTaskReqDTO updatedProjectTask)
    {
        var response = await _projectTaskService.Update(updatedProjectTask);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<ProjectTaskResDTO>>> Delete(int id)
    {
        var response = await _projectTaskService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}
