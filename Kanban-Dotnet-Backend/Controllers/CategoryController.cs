using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;
using Kanban_Dotnet_Backend.Services;
using Kanban_Dotnet_Backend.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kanban_Dotnet_Backend.Controllers;

[ApiController]
[Route("api/v1/Projects")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<CategoryResDTO>>>> GetAllCategories()
    {
        var categories = await _categoryService.GetAll();
        return Ok(categories.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<CategoryResDTO>>>> GetSingle(int id)
    {
        return Ok(await _categoryService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<CategoryResDTO>>>> AddCategory(CategoryReqDTO newCategory)
    {
        return Ok(await _categoryService.Create(newCategory));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<CategoryResDTO>>> UpdateCategory(int id, CategoryReqDTO updatedCategory)
    {
        var response = await _categoryService.Update(updatedCategory);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<CategoryResDTO>>> Delete(int id)
    {
        var response = await _categoryService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}