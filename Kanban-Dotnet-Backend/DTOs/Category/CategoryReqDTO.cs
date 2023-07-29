using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban_Dotnet_Backend.DTOs.Category;

public class CategoryReqDTO
{
    public string CategoryTitle { get; set; }
    public int ProjectId { get; set; }
}