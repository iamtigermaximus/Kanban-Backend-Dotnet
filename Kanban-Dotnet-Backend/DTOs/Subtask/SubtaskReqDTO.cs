using System;

namespace Kanban_Dotnet_Backend.DTOs.Subtask;

public class SubtaskReqDTO
{
    public int Id { get; set; }
    public bool Completed { get; set; }
    public string Text { get; set; }
}

