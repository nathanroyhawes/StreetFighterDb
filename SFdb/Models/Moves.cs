namespace SFdb.Models
{
    public class Moves : Character
    {
        // move properties
        public int moveId { get; set; }
        public int charId { get; set; }
        public string moveName { get; set; }
        public string moveNotation { get; set; }

    }
}
