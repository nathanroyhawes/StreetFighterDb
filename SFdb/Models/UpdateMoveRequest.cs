namespace SFdb.Models
{
    // SOLID: Single Responsibility - This class is made specifically for the 'PUT' in the character controller
    // SOLID: Open/Closed - Extends the functionality of the Move class, allows us to update the data without modifiying the original move class
    public class UpdateMoveRequest
    {
        public String charId { get; set; }
        public string moveName { get; set; }
        public string moveNotation { get; set; }
    }
}
