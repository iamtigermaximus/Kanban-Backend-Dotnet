using System;
namespace Kanban_Dotnet_Backend.DTOs.ProjectTask;

public class ProjectTaskReqDTO
{
    public bool Completed { get; set; }
    public string Text { get; set; }
    public int CardId { get; set; }
}

