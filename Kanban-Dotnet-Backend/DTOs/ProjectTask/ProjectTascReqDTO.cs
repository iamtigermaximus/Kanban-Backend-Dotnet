﻿using System;
namespace Kanban_Dotnet_Backend.DTOs.ProjectTask;

public class ProjectTascReqDTO
{
    public int Id { get; set; }
    public bool Completed { get; set; }
    public string Text { get; set; }
}

