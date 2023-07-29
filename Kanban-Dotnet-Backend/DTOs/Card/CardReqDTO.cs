using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban_Dotnet_Backend.DTOs.Card
{
    public class CardReqDTO
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int CategoryId { get; set; }
    }
}