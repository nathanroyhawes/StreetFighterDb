using System.ComponentModel.DataAnnotations;

namespace SFdb.Models;

public class Moves
{
    // Single Responsibility - This is the main source for all move information
    [Key]
    public String moveId { get; set; }
    public String charId { get; set; }
    public string moveName { get; set; }
    public string moveNotation { get; set; }

}
