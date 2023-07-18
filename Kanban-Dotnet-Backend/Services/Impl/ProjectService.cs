using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban_Dotnet_Backend.Data;
using Kanban_Dotnet_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Dotnet_Backend.Services.Impl
{
   public class ProjectService : IProjectService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public ProjectService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<Project>>> Create(Project newProject)
    {
        var serviceResponse = new ServiceResponse<List<Project>>();
        try
        {
            var project = _mapper.Map<Project>(newProject);

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Projects
                    .Select(c => _mapper.Map<Project>(c))
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Project>>> GetAllProjects()
    {
        var serviceResponse = new ServiceResponse<List<Project>>();
        var dbProjects = await _context.Projects.ToListAsync();
        serviceResponse.Data = dbProjects.Select(c => _mapper.Map<Project>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<Project>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<Project>();
        try
        {
            var dbProjects = await _context.Projects
            .FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<Project>(dbProjects);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<Project>> Update( Project updatedProject)
    {
        var serviceResponse = new ServiceResponse<Project>();

        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(c => c.Id == updatedProject.Id);
            if (project is null)
                throw new Exception($"Project with Id '{updatedProject.Id}' not found.");

            project.Name = updatedProject.Name;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<Project>(project);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

    }

  public async Task<ServiceResponse<List<Project>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<Project>>();

        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project is null)
                throw new Exception($"Project with Id '{id}' not found.");

            _context.Projects.Remove(project);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Projects.Select(p => _mapper.Map<Project>(p)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

}

}