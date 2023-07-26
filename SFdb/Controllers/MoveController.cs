using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFdb.Data;
using SFdb.Migrations;
using SFdb.Models;
using System.Xml;

namespace SFdb.Controllers
{
    //Each Get, Post, Put, and delete is Asynchronous 
    [ApiController]
    [Route("api/[controller]List")]
    public class MoveController : Controller
    {
        private readonly CharacterAPIDbContext dbContext;
        public MoveController(CharacterAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Reads all moves
        [HttpGet]
        public async Task<IActionResult> GetMoves()
        {
            return Ok(await dbContext.Moves.ToListAsync());

        }

        //Reads one specific move
        [HttpGet]
        [Route("{moveId:guid}")]
        public async Task<IActionResult> GetMove([FromRoute] String moveId)
        {
            var move = await dbContext.Moves.FindAsync(moveId);

            if (move == null)
            {
                return NotFound();
            }

            return Ok(move);
        }

        // Creates Moves - Uses 'AddMoveRequest' class, separating it from using the base Move class and UpdateMoveRequest
        [HttpPost]
        public async Task<IActionResult> AddMove(AddMoveRequest addMoveRequest)
        {
            var move = new Models.Moves()
            {
                moveId = Guid.NewGuid().ToString(),
                moveName = addMoveRequest.moveName,
                charId = addMoveRequest.charId,
                moveNotation = addMoveRequest.moveNotation
            };

            await dbContext.Moves.AddAsync(move);
            await dbContext.SaveChangesAsync();

            return Ok(move);
        }

        //Updates Moves
        //SOLID: Open/Closed - Allows us to change the move entry without altering the 'Moves' Class
        [HttpPut]
        [Route("{moveId:guid}")]
        public async Task<IActionResult> UpdateMove([FromRoute] String moveId, UpdateMoveRequest updateMoveRequest)
        {
            var move = await dbContext.Moves.FindAsync(moveId);

            if (move != null)
            {
                move.charId = updateMoveRequest.charId;
                move.moveName = updateMoveRequest.moveName;
                move.moveNotation = updateMoveRequest.moveNotation;

                await dbContext.SaveChangesAsync();
                return Ok(move);
            }

            return NotFound();
        }
        // Deletes Moves
        [HttpDelete]
        [Route("{moveId:guid}")]
        public async Task<IActionResult> DeleteMove([FromRoute] String moveId)
        {
            var move = await dbContext.Moves.FindAsync(moveId);

            if (move != null)
            {
                dbContext.Remove(move);
                await dbContext.SaveChangesAsync();

                return Ok(move);
            }
            return NotFound();
        }
    }
}