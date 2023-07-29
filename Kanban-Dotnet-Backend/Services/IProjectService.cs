using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Project;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.Services;

public interface IProjectService
{
    Task<ServiceResponse<List<ProjectResDTO>>> GetAllProjects();
    Task<ServiceResponse<ProjectResDTO>> GetById(int id);
    Task<ServiceResponse<List<ProjectResDTO>>> Create(ProjectReqDTO entity);
    Task<ServiceResponse<ProjectResDTO>> Update( int id,ProjectReqDTO updatedProject);
    Task<ServiceResponse<List<ProjectResDTO>>> Delete(int id);
}