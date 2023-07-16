using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFdb.Data;
using SFdb.Migrations;
using SFdb.Models;

namespace SFdb.Controllers
{
    [ApiController]
    [Route("api/[controller]List")]
    public class MoveController : Controller
    {
        private readonly CharacterAPIDbContext dbContext;
        public MoveController(CharacterAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoves()
        {
            return Ok(await dbContext.Moves.ToListAsync());

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMove([FromRoute] String moveId)
        {
            var move = await dbContext.Moves.FindAsync(moveId);

            if (move == null)
            {
                return NotFound();
            }

            return Ok(move);
        }

        // add moves
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
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMove([FromRoute] Guid moveId, UpdateMoveRequest updateMoveRequest)
        {
            var move = await dbContext.Characters.FindAsync(moveId);

            if (move != null)
            {
                move.Name = updateMoveRequest.moveName;

                await dbContext.SaveChangesAsync();
                return Ok(move);
            }

            return NotFound();
        }
        // remove characters
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteMove([FromRoute] Guid moveId)
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