using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban_Dotnet_Backend.DTOs.Project;
using Kanban_Dotnet_Backend.DTOs.Category;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Project, ProjectReqDTO>();
        CreateMap<ProjectReqDTO, Project>();
        CreateMap<Project, ProjectResDTO>();

        CreateMap<Category, CategoryReqDTO>();
        CreateMap<CategoryReqDTO, Category>();
        CreateMap<Category, CategoryResDTO>();
    }
}