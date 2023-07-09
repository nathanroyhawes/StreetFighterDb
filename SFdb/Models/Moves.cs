using System.ComponentModel.DataAnnotations;

namespace SFdb.Models;

public class Moves
{
    // move properties
    [Key]
    public String moveId { get; set; }
    public int charId { get; set; }
    public string moveName { get; set; }
    public string moveNotation { get; set; }

}
