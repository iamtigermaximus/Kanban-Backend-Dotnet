using System;
using Kanban_Dotnet_Backend.DTOs.Category;

namespace Kanban_Dotnet_Backend.DTOs.Project;

public class ProjectReqDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CategoryReqDTO> Categories { get; set; }

}

