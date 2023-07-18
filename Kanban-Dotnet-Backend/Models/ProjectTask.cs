using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban_Dotnet_Backend.Models;

public class ProjectTask : BaseModel
{
    public bool Completed { get; set; }
    public string Text { get; set; }
    public List<Subtask> Subtasks { get; set; }
}