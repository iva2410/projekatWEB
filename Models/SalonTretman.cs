using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class SalonTretman
    {
        [Key]
        public int ID { get; set; }

        [JsonIgnore]
        public Salon Salon { get; set; }

        public Tretman Tretman {get; set;}

         public int Cena{get; set;}
  
  
    }
}