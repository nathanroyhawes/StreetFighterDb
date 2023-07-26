using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SFdb.Models
{
    public class Character
    {
        // Single Responsibility - This is the main source for all character information
        [Key]
        public String Id { get; set; }
        public string Name { get; set; }
    }
}
