using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.DTOs.Card;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.DTOs.Category;

public class CategoryResDTO:BaseModel
{
    public string CategoryTitle { get; set; }
    public int ProjectId { get; set; }
    public List<CardResDTO> Cards { get; set; }
}