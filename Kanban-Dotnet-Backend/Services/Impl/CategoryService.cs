using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban_Dotnet_Backend.Data;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Dotnet_Backend.Services.Impl;

public class CategoryService : ICategoryService
{
private readonly IMapper _mapper;
private readonly DataContext _context;

public CategoryService(IMapper mapper, DataContext context)
{
    _mapper = mapper;
    _context = context;
}

public async Task<ServiceResponse<List<CategoryResDTO>>> Create(CategoryReqDTO newCategory)
{
    var serviceResponse = new ServiceResponse<List<CategoryResDTO>>();
    try
    {
        var category = _mapper.Map<Category>(newCategory);

        _context.Categories.Add(category);

        await _context.SaveChangesAsync();

        serviceResponse.Data = await _context.Categories
                .Select(c => _mapper.Map<CategoryResDTO>(c))
                .ToListAsync();
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
}

public async Task<ServiceResponse<List<CategoryResDTO>>> GetAll()
{
    var serviceResponse = new ServiceResponse<List<CategoryResDTO>>();
    var dbCategories = await _context.Categories
            .Include(c => c.Project)
            .ToListAsync();

    serviceResponse.Data = dbCategories.Select(c => _mapper.Map<CategoryResDTO>(c)).ToList();
    return serviceResponse;
}


public async Task<ServiceResponse<CategoryResDTO>> GetById(int id)
{
    var serviceResponse = new ServiceResponse<CategoryResDTO>();
    try
    {
        var dbCategories = await _context.Categories
        .Include(c => c.Project)
        .FirstOrDefaultAsync(c => c.Id == id);
        serviceResponse.Data = _mapper.Map<CategoryResDTO>(dbCategories);
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
}

public async Task<ServiceResponse<CategoryResDTO>> Update(CategoryReqDTO updatedCategory)
{
    var serviceResponse = new ServiceResponse<CategoryResDTO>();

    try
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == updatedCategory.Id);
        if (category is null)
            throw new Exception($"Category with Id '{updatedCategory.Id}' not found.");

            category.CategoryTitle = updatedCategory.CategoryTitle;

        await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<CategoryResDTO>(category);
    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }

    return serviceResponse;

}

public async Task<ServiceResponse<List<CategoryResDTO>>> Delete(int id)
{
    var serviceResponse = new ServiceResponse<List<CategoryResDTO>>();

    try
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category is null)
            throw new Exception($"Category with Id '{id}' not found.");

        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();

        serviceResponse.Data = await _context.Categories.Select(c => _mapper.Map<CategoryResDTO>(c)).ToListAsync();

    }
    catch (Exception ex)
    {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
    }

    return serviceResponse;
}

}