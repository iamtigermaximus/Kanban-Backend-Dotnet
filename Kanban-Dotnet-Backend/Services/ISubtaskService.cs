using System;
using Kanban_Dotnet_Backend.DTOs.ProjectTask;
using Kanban_Dotnet_Backend.DTOs.Subtask;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.Services;

public interface ISubtaskService
{
    Task<ServiceResponse<List<SubtaskResDTO>>> GetAllSubtasks();
    Task<ServiceResponse<SubtaskResDTO>> GetById(int id);
    Task<ServiceResponse<List<SubtaskResDTO>>> Create(SubtaskReqDTO newSubtask);
    Task<ServiceResponse<SubtaskResDTO>> Update(int id,SubtaskReqDTO updatedSubtask);
    Task<ServiceResponse<List<SubtaskResDTO>>> Delete(int id);
}

