using System;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.DTOs.Subtask;

public class SubtaskResDTO : BaseModel
{
    public int Id { get; set; }
    public bool Completed { get; set; }
    public string Text { get; set; }
}

