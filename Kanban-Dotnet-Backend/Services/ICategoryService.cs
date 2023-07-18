using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryResDTO>>> GetAll();
        Task<ServiceResponse<CategoryResDTO>> GetById(int id);
        Task<ServiceResponse<List<CategoryResDTO>>> Create(CategoryReqDTO entity);
        Task<ServiceResponse<CategoryResDTO>> Update( CategoryReqDTO updatedCategory);
        Task<ServiceResponse<List<CategoryResDTO>>> Delete(int id);
    }
}