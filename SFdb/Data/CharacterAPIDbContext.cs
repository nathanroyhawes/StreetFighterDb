using Microsoft.EntityFrameworkCore;

namespace SFdb.Data;

public class CharacterAPIDbContext : DbContext
{
    public DbSet<Models.Character> Characters { get; set; }
    //public DbSet<Models.Moves> Moves { get; set; }


    public CharacterAPIDbContext() : base()
    {
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Character>().ToTable("Characters");
        //modelBuilder.Entity<Models.Moves>().ToTable("Moves");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SF.db");
    }

}
