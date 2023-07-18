using System;
using AutoMapper;
using Kanban_Dotnet_Backend.Data;
using Kanban_Dotnet_Backend.DTOs.ProjectTask;
using Kanban_Dotnet_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Dotnet_Backend.Services.Impl;

public class ProjectTaskService : IProjectTaskService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public ProjectTaskService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<ProjectTaskResDTO>>> Create(ProjectTaskReqDTO newProjectTask)
    {
        var serviceResponse = new ServiceResponse<List<ProjectTaskResDTO>>();
        try
        {
            var projectTask = _mapper.Map<ProjectTask>(newProjectTask);

            _context.ProjectTasks.Add(projectTask);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.ProjectTasks
                    .Select(c => _mapper.Map<ProjectTaskResDTO>(c))
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<List<ProjectTaskResDTO>>> GetAllProjectTasks()
    {
        var serviceResponse = new ServiceResponse<List<ProjectTaskResDTO>>();
        var dbProjectTasks = await _context.ProjectTasks.ToListAsync();
        serviceResponse.Data = dbProjectTasks.Select(p => _mapper.Map<ProjectTaskResDTO>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ProjectTaskResDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<ProjectTaskResDTO>>();

        try
        {
            var projectTask = await _context.ProjectTasks.FirstOrDefaultAsync(p => p.Id == id);
            if (projectTask is null)
                throw new Exception($"Project task with Id '{id}' not found.");

            _context.ProjectTasks.Remove(projectTask);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.ProjectTasks.Select(p => _mapper.Map<ProjectTaskResDTO>(p)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<ProjectTaskResDTO>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<ProjectTaskResDTO>();
        try
        {
            var dbProjectTasks = await _context.ProjectTasks
            .FirstOrDefaultAsync(p => p.Id == id);
            serviceResponse.Data = _mapper.Map<ProjectTaskResDTO>(dbProjectTasks);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<ProjectTaskResDTO>> Update(ProjectTaskReqDTO updatedProjectTask)
    {
        var serviceResponse = new ServiceResponse<ProjectTaskResDTO>();

        try
        {
            var projectTask = await _context.ProjectTasks.FirstOrDefaultAsync(p => p.Id == updatedProjectTask.Id);
            if (projectTask is null)
                throw new Exception($"Project task with Id '{updatedProjectTask.Id}' not found.");

            projectTask.Text = updatedProjectTask.Text;
            projectTask.Completed = updatedProjectTask.Completed;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<ProjectTaskResDTO>(projectTask);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

}

