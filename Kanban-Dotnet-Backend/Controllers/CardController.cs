using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Card;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;
using Kanban_Dotnet_Backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace Kanban_Dotnet_Backend.Controllers;


[ApiController]
[Route("api/v1/Cards")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<CardResDTO>>>> GetAllCards()
    {
        var cards = await _cardService.GetAll();
        return Ok(cards.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<CardResDTO>>>> GetSingle(int id)
    {
        return Ok(await _cardService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<CardResDTO>>>> AddCard(CardReqDTO newCard)
    {
        return Ok(await _cardService.Create(newCard));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<CardResDTO>>> UpdateCategory(int id, CardReqDTO updatedCard)
    {
        var response = await _cardService.Update(id,updatedCard);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<CardResDTO>>> Delete(int id)
    {
        var response = await _cardService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}

