using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context,
        ILogger logger,
        int retry = 0)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}