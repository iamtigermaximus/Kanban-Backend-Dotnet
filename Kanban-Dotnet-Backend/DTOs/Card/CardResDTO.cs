using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_Dotnet_Backend.Models;

namespace Kanban_Dotnet_Backend.DTOs.Card
{
    public class CardResDTO:BaseModel
    {
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}