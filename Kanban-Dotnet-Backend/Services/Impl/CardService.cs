using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban_Dotnet_Backend.Data;
using Kanban_Dotnet_Backend.DTOs.Card;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_Dotnet_Backend.Services.Impl;

public class CardService: ICardService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CardService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<ServiceResponse<List<CardResDTO>>> Create(CardReqDTO newCard)
    {
        var serviceResponse = new ServiceResponse<List<CardResDTO>>();
        try
        {
            var card = _mapper.Map<Card>(newCard);

            _context.Cards.Add(card);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Cards
                    .Select(c => _mapper.Map<CardResDTO>(c))
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<List<CardResDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<CardResDTO>>();
        var dbCards = await _context.Cards.ToListAsync();
        serviceResponse.Data = dbCards.Select(c => _mapper.Map<CardResDTO>(c)).ToList();
        return serviceResponse;
    }


    public async Task<ServiceResponse<CardResDTO>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<CardResDTO>();
        try
        {
            var dbCards = await _context.Cards
            .FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<CardResDTO>(dbCards);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<CardResDTO>> Update(CardReqDTO updatedCard)
    {
        var serviceResponse = new ServiceResponse<CardResDTO>();

        try
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == updatedCard.Id);
            if (card is null)
                throw new Exception($"Card with Id '{updatedCard.Id}' not found.");

            card.Title = updatedCard.Title;
            card.Desc = updatedCard.Desc;


            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<CardResDTO>(card);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

    }

    public async Task<ServiceResponse<List<CardResDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<CardResDTO>>();

        try
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card is null)
                throw new Exception($"Card with Id '{id}' not found.");

            _context.Cards.Remove(card);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Cards.Select(c => _mapper.Map<CardResDTO>(c)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

}