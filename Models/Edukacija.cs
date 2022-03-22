using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Edukacija
    {
        [Key]
        public int ID{get; set;}

        [Required]
        public string Ime{get; set;}
        [Required]
        public int SlobodnaMesta{get;set;}
       /*[Required]
        public DateTime Vreme {get; set;}*/
        public Salon salon{get;set;}
        public Radnik Radnik{get;set;}
        public List<EdukacijaTermin> termini{get;set;}
    }
}