using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.ProjectTask;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.Services;

public interface IProjectTaskService
{
     Task<ServiceResponse<List<ProjectTaskResDTO>>> GetAllProjectTasks();
     Task<ServiceResponse<ProjectTaskResDTO>> GetById(int id);
     Task<ServiceResponse<List<ProjectTaskResDTO>>> Create(ProjectTaskReqDTO newProjectTask);
     Task<ServiceResponse<ProjectTaskResDTO>> Update( int id,ProjectTaskReqDTO updatedProjectTask);
     Task<ServiceResponse<List<ProjectTaskResDTO>>> Delete(int id);
}