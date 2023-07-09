using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFdb.Data;
using SFdb.Models;

namespace SFdb.Controllers
{
    [ApiController]
    [Route("api/[controller]List")]
    public class CharacterController : Controller
    {
        private readonly CharacterAPIDbContext dbContext;
        public CharacterController(CharacterAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            return Ok(await dbContext.Characters.ToListAsync());
 
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCharacter([FromRoute] String id)
        {
            var character = await dbContext.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // add characters
        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterRequest addCharacterRequest)
        {
            var character = new Character()
            {
                Id = Guid.NewGuid().ToString(),
                Name = addCharacterRequest.Name
            };

            await dbContext.Characters.AddAsync(character);
            await dbContext.SaveChangesAsync();

            return Ok(character);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCharacter([FromRoute] Guid id, UpdateCharacterRequest updateCharacterRequest)
        {
            var character = await dbContext.Characters.FindAsync(id);

            if (character != null)
            {
               character.Name = updateCharacterRequest.Name;

                await dbContext.SaveChangesAsync();
                return Ok(character);
            }

            return NotFound();
        }
        // remove characters
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCharacter([FromRoute] Guid id)
        {
            var character = await dbContext.Characters.FindAsync(id);

            if (character != null)
            {
                dbContext.Remove(character);
                await dbContext.SaveChangesAsync();

                return Ok(character);
            }
            return NotFound();
        }
    }
}
