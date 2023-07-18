using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.Services;

public interface IProjectService
{
    Task<ServiceResponse<List<Project>>> GetAllProjects();
    Task<ServiceResponse<Project>> GetById(int id);
    Task<ServiceResponse<List<Project>>> Create(Project entity);
    Task<ServiceResponse<Project>> Update( Project updatedProject);
    Task<ServiceResponse<List<Project>>> Delete(int id);
}