using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SFdb.Models
{
    public class Character
    {
       
        [Key]
        public String Id { get; set; }
        public string Name { get; set; }
    }
}
