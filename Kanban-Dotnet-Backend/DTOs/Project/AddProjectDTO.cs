using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.DTOs.Project
{
    public class AddProjectDTO :BaseModel
    {
         public string Name { get; set; }
         public List<Category>? Data { get; set; }
    }
}