using System;
using AutoMapper;
using Kanban_Dotnet_Backend.Data;
using Kanban_Dotnet_Backend.DTOs.ProjectTask;
using Kanban_Dotnet_Backend.DTOs.Subtask;
using Kanban_Dotnet_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Dotnet_Backend.Services.Impl;

public class SubtaskService: ISubtaskService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public SubtaskService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<SubtaskResDTO>>> Create(SubtaskReqDTO newSubtask)
    {
        var serviceResponse = new ServiceResponse<List<SubtaskResDTO>>();
        try
        {
            var subtask = _mapper.Map<Subtask>(newSubtask);

            _context.Subtasks.Add(subtask);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Subtasks
                    .Select(c => _mapper.Map<SubtaskResDTO>(c))
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<List<SubtaskResDTO>>> GetAllSubtasks()
    {
        var serviceResponse = new ServiceResponse<List<SubtaskResDTO>>();
        var dbSubtasks = await _context.Subtasks.ToListAsync();
        serviceResponse.Data = dbSubtasks.Select(s => _mapper.Map<SubtaskResDTO>(s)).ToList();
        return serviceResponse;
    }


    public async Task<ServiceResponse<List<SubtaskResDTO>>>Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<SubtaskResDTO>>();

        try
        {
            var subtask = await _context.Subtasks.FirstOrDefaultAsync(s => s.Id == id);
            if (subtask is null)
                throw new Exception($"Subtask with Id '{id}' not found.");

            _context.Subtasks.Remove(subtask);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Subtasks.Select(p => _mapper.Map<SubtaskResDTO>(p)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<SubtaskResDTO>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<SubtaskResDTO>();
        try
        {
            var dbSubtask = await _context.Subtasks
            .FirstOrDefaultAsync(s => s.Id == id);
            serviceResponse.Data = _mapper.Map<SubtaskResDTO>(dbSubtask);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<SubtaskResDTO>> Update(SubtaskReqDTO updatedSubtask)
    {
        var serviceResponse = new ServiceResponse<SubtaskResDTO>();

        try
        {
            var subtask = await _context.Subtasks.FirstOrDefaultAsync(s => s.Id == updatedSubtask.Id);
            if (subtask is null)
                throw new Exception($"Subtask  with Id '{updatedSubtask.Id}' not found.");

            subtask.Text = updatedSubtask.Text;
            subtask.Completed = updatedSubtask.Completed;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<SubtaskResDTO>(subtask);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

  
}

