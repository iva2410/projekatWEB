using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Salon
    {
        [Key]
        public int ID{get; set;}
        [Required]
        public string Naziv{get;set;}
      
        [Required]
        public string Grad{get;set;}

        public List<SalonTretman> Tretmani{get; set;}
        public List<Edukacija> Edukacije{get; set;}
        public List<Radnik> Radnici{get; set;}

        
      
   }
}