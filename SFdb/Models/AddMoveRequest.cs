namespace SFdb.Models
{
    //Single Responsibility - This class is used specifically to create a new move
    public class AddMoveRequest
    {
        public String charId { get; set; }
        public string moveName { get; set; }
        public string moveNotation { get; set; }
    }
}
