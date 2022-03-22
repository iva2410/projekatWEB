using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Models
{
  
    public class Tretman
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }


        [Required]
        public int VremeTrajanja { get; set; }
       
        
        [JsonIgnore]
        public List<SalonTretman> Salon{get; set;}

        

    }
}