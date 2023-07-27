using System.ComponentModel.DataAnnotations;

namespace SFdb.Models;

public class Moves
{
    
    [Key]
    public String moveId { get; set; }
    public String charId { get; set; }
    public string moveName { get; set; }
    public string moveNotation { get; set; }

}
