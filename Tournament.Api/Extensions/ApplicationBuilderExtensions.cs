using Tournament.Data;
using Tournament.Data.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Tournament.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void SeedData(this TournamentContext context)
        {
            DataSeeder.SeedData(context);
        }
    }
}
