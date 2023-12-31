﻿using System;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.DTOs.Project;

public class ProjectResDTO:BaseModel
{
    public string Name { get; set; }
    public List<CategoryResDTO> Categories { get; set; }
}

