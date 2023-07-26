using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace SFdb.Models
{
    //Class for the properties of the SQL Query
    [Keyless]
    public class AllRecord
    {
        
        
        public string Name { get; set; }
        public string MoveName { get; set; }
        public string MoveNotation { get; set; }  
    }
}

