using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Termin
    {
         [Key]
        public int ID { get; set; }
        [Required]
        public string Dan{get;set;}
        public List<EdukacijaTermin> Edukacija{get; set;}
        
    }
}