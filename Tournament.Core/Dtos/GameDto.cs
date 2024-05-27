using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Dtos
{
    public class GameDto
    {
        public string Title { get; set; }
        public DateTime Time { get; set; }
    }
}
