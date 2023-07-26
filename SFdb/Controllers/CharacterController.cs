using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFdb.Data;
using SFdb.Models;

namespace SFdb.Controllers
{
    //Each Get, Post, Put, and Delete is Asynchronous 
    [ApiController]
    [Route("api/[controller]List")]
    public class CharacterController : Controller
    {
        private readonly CharacterAPIDbContext dbContext;
        public CharacterController(CharacterAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Reads all characters
        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            return Ok(await dbContext.Characters.ToListAsync());
 
        }
        //Reads one specific character
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

        // Creates a character
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

        //Updates Characters
        //SOLID: Open/Closed - Allows us to change the character entry without altering the 'Character' Class
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCharacter([FromRoute] String id, UpdateCharacterRequest updateCharacterRequest)
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
        //Deletes a Character
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCharacter([FromRoute] String id)
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
