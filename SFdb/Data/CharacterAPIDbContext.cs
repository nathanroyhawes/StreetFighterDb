using Microsoft.EntityFrameworkCore;

namespace SFdb.Data
{
    public class CharacterAPIDbContext : DbContext
    {
        public CharacterAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Character> Characters => Set<Models.Character>();
    }
}
