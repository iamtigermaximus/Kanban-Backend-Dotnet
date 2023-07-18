using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Card;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.Services
{
    public interface ICardService
    {
        Task<ServiceResponse<List<CardResDTO>>> GetAll();
        Task<ServiceResponse<CardResDTO>> GetById(int id);
        Task<ServiceResponse<List<CardResDTO>>> Create(CardReqDTO entity);
        Task<ServiceResponse<CardResDTO>> Update(CardReqDTO updatedCard);
        Task<ServiceResponse<List<CardResDTO>>> Delete(int id);
    }
}