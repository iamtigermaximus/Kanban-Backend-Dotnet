using System;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.DTOs.ProjectTask;

public class ProjectTaskResDTO: BaseModel
{
    public bool Completed { get; set; }
    public string Text { get; set; }
}

