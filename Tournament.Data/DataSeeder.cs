using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


using Tournament.Core.Entities;
using Tournament.Data.Data;

namespace Tournament.Data
{
    public class DataSeeder
    {
        public static void SeedData(TournamentContext context)
        {
            if (context.Game.Any() || context.Tourney.Any()) return;

             // Add initial data for Games
            var games = new[]
            {
                new Game { Title = "Game 1", Time = DateTime.UtcNow, TournamentId = 1 },
                new Game { Title = "Game 2", Time = DateTime.UtcNow, TournamentId = 1 }
                // Add more initial games if needed
            };
            context.Game.AddRange(games);
            context.SaveChanges();

            // Add initial data for Tourneys
            var tourneys = new[]
            {
                new Tourney { Title = "Tournament 1", StartDate = DateTime.UtcNow, Games = [.. games] },
                new Tourney { Title = "Tournament 2", StartDate = DateTime.UtcNow, Games = [.. games] }
                // Add more initial tourneys if needed
            };
            context.Tourney.AddRange(tourneys);
            context.SaveChanges();
        }

    }
}
