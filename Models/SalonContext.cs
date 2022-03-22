using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Models
{
    public class SalonContext : DbContext
    {
        public DbSet<Salon> Saloni { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<Termin> Termini { get; set; }
        public DbSet<Tretman> Tretmani { get; set; }
        public DbSet<Edukacija> Edukacije{get; set;}

        public DbSet<EdukacijaTermin> EdukacijaTermini{get; set;}

        public DbSet<SalonTretman> SaloniTretmani{get;set;}
        public SalonContext(DbContextOptions options) : base(options)
        {
            
        }       
    }
}