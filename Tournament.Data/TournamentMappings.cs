using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Core.Entities;
using AutoMapper;

namespace Tournament.Data
{
    public class TournamentMappings : Profile
    {
        public TournamentMappings()
        {
            CreateMap<Tourney, Tournament.Core.Entities.Tourney>().ReverseMap();
            CreateMap<Game, Tournament.Core.Entities.Game>().ReverseMap();
        }
    }
}
