using System;

namespace Kanban_Dotnet_Backend.DTOs.Subtask;

public class SubtaskReqDTO
{
    public bool Completed { get; set; }
    public string Text { get; set; }
    public int ProjectTaskId { get; set; }
}

