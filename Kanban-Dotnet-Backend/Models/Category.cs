using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban_Dotnet_Backend.Models;

public class Category : BaseModel
{
    public string CategoryTitle { get; set; }
    public List<Card> Cards { get; set; }
}