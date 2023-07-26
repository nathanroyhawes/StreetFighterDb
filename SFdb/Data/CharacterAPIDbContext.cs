using Microsoft.EntityFrameworkCore;
using System.IO.Pipes;

namespace SFdb.Data;

public class CharacterAPIDbContext : DbContext
{
    public DbSet<Models.Character> Characters { get; set; }
    public DbSet<Models.Moves> Moves { get; set; }
    //add set for All Records in both characters and Moves
    public DbSet<Models.AllRecord> AllRecords { get; set; } = default!;


    public CharacterAPIDbContext() : base()
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Character>().ToTable("Characters");
        modelBuilder.Entity<Models.Moves>().ToTable("Moves");
        //Prevents creation of another table
        modelBuilder.Entity<Models.AllRecord>(b => b.ToView("sql"));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SF.db");
    }

}
