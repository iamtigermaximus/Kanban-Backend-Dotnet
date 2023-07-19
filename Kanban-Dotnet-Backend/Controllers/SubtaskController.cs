using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.ProjectTask;
using Kanban_Dotnet_Backend.DTOs.Subtask;
using Kanban_Dotnet_Backend.Models;
using Kanban_Dotnet_Backend.Services;
using Kanban_Dotnet_Backend.Services.Impl;
using Microsoft.AspNetCore.Mvc;


namespace Kanban_Dotnet_Backend.Controllers;

[ApiController]
[Route("api/v1/Subtasks")]
public class SubtaskController : ControllerBase
{
    private readonly ISubtaskService _subtaskService;

    public SubtaskController(ISubtaskService subtaskService)
    {
        _subtaskService = subtaskService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<SubtaskResDTO>>>> GetAll()
    {
        var subtasks = await _subtaskService.GetAllSubtasks();
        return Ok(subtasks.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<SubtaskResDTO>>>> GetSingle(int id)
    {
        return Ok(await _subtaskService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<SubtaskResDTO>>>> AddSubtask(SubtaskReqDTO newSubtask)
    {
        return Ok(await _subtaskService.Create(newSubtask));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<SubtaskResDTO>>> UpdateSubtask(int id, SubtaskReqDTO updatedSubtask)
    {
        var response = await _subtaskService.Update(updatedSubtask);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<SubtaskResDTO>>> Delete(int id)
    {
        var response = await _subtaskService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}
