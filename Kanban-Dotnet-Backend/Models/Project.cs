using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban_Dotnet_Backend.Models;

public class Project : BaseModel
{
    public string Name { get; set; }
    public List<Category>? Categories { get; set; }
}