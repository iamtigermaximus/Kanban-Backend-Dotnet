using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban_Dotnet_Backend.Data;
using Kanban_Dotnet_Backend.DTOs.Project;
using Kanban_Dotnet_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Dotnet_Backend.Services.Impl;

public class ProjectService : IProjectService
{
private readonly IMapper _mapper;
private readonly DataContext _context;

public ProjectService(IMapper mapper, DataContext context)
{
    _mapper = mapper;
    _context = context;
}

public async Task<ServiceResponse<List<ProjectResDTO>>> Create(ProjectReqDTO newProject)
{
    var serviceResponse = new ServiceResponse<List<ProjectResDTO>>();
    try
    {
        var project = _mapper.Map<Project>(newProject);

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        serviceResponse.Data = await _context.Projects
                .Select(c => _mapper.Map<ProjectResDTO>(c))
                .ToListAsync();
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
}

public async Task<ServiceResponse<List<ProjectResDTO>>> GetAllProjects()
{
    var serviceResponse = new ServiceResponse<List<ProjectResDTO>>();
    var dbProjects = await _context.Projects
            .Include(p => p.Categories)
            .ThenInclude(c => c.Cards)
            .ToListAsync();

    serviceResponse.Data = dbProjects.Select(c => _mapper.Map<ProjectResDTO>(c)).ToList();
    return serviceResponse;
}


public async Task<ServiceResponse<ProjectResDTO>> GetById(int id)
{
    var serviceResponse = new ServiceResponse<ProjectResDTO>();
    try
    {
        var dbProjects = await _context.Projects
        .Include(p => p.Categories)
        .ThenInclude(c => c.Cards)
        .FirstOrDefaultAsync(c => c.Id == id);

        serviceResponse.Data = _mapper.Map<ProjectResDTO>(dbProjects);
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
}

public async Task<ServiceResponse<ProjectResDTO>> Update(ProjectReqDTO updatedProject)
{
    var serviceResponse = new ServiceResponse<ProjectResDTO>();

    try
    {
        var project = await _context.Projects.FirstOrDefaultAsync(c => c.Id == updatedProject.Id);
        if (project is null)
            throw new Exception($"Project with Id '{updatedProject.Id}' not found.");

        project.Name = updatedProject.Name;

        await _context.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<ProjectResDTO>(project);
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }

    return serviceResponse;

}

public async Task<ServiceResponse<List<ProjectResDTO>>> Delete(int id)
{
    var serviceResponse = new ServiceResponse<List<ProjectResDTO>>();

    try
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        if (project is null)
            throw new Exception($"Project with Id '{id}' not found.");

        _context.Projects.Remove(project);

        await _context.SaveChangesAsync();

        serviceResponse.Data = await _context.Projects.Select(p => _mapper.Map<ProjectResDTO>(p)).ToListAsync();

    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }

    return serviceResponse;
}

}