namespace SFdb.Models
{
    // SOLID: Single Responsibility - This class is made specifically for 'PUT' in the character controller
    // SOLID: Open/Closed - Extends the functionality of the Character class, allows us to update the data without modifiying the original character clas
    public class UpdateCharacterRequest: Character
    {
        public string Name { get; set; }
    }
}
