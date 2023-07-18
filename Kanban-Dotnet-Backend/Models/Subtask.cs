using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban_Dotnet_Backend.Models;

public class Subtask : BaseModel
{
    public bool Completed { get; set; }
    public string Text { get; set; }
}