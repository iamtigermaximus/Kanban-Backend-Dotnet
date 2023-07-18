using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban_Dotnet_Backend.Models;

public class Card : BaseModel
{
    public string Title { get; set; }
    public string Desc { get; set; }
    public List<ProjectTask> ProjectTasks { get; set; }

}