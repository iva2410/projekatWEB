using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EdukacijaTermin
    {
        [Key]
        public int ID{get;set;}

        [Required]
        public DateTime Vreme {get; set;}
        public Edukacija Edukacija{get; set;}
        public Termin Termin{get;set;}
    }
}