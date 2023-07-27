using Microsoft.EntityFrameworkCore;
using SFdb.Data;
using System.Security.Cryptography.X509Certificates;

namespace SFdb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Creates connection to .db file
            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CharacterAPIDbContext>(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            
            //Creates Get for SQL Query
            app.MapGet("/AllRecords", async (CharacterAPIDbContext _ctx) =>
            {
                //Queries DataBase by using RAW SQL - Joins Characters & Moves Tables together and hides GUID information from user
                String query = "SELECT Characters.Name, Moves.moveName, Moves.moveNotation\r\nFROM Characters, Moves\r\nWHERE Characters.Id = Moves.charId;";
                return Results.Ok(_ctx.AllRecords
                                             .FromSqlRaw(query)
                                             .ToListAsync());
            });

            app.Run();


        }
        
    }
 

}