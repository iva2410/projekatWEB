using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Radnik
    {
        [Key]
        public int ID{get; set;}
        [Required]
        [MaxLength(13)]
        public string JMBG { get; set; }
        
        [Required]
        public string Ime{get; set;}

        [Required]
        public string Prezime{get; set;}
        [Required]
        public string Pol{get; set;}
        [Required]
        public int GodineRada{get; set;}
        [Required]
        public int Plata{get; set;}
        public Salon Salon{get; set;}


        
    }
}