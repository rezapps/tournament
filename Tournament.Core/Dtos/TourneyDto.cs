using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.Core.Dtos
{
    public class TourneyDto
    {
        public string Title { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate => StartDate.AddMonths(3);

    }
}
