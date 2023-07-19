using System;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.DTOs.Subtask;

public class SubtaskResDTO : BaseModel
{
    public bool Completed { get; set; }
    public string Text { get; set; }
    public int ProjectTaskId { get; set; }
}

