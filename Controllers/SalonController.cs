using Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace webprojekatControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalonController : ControllerBase
    {
        public SalonContext Context { get; set; }
        public SalonController(SalonContext context)
        {
            Context = context;
        }

        [Route("PreuzmiSalone")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiSalone()
        {
            try{
                return Ok(await Context.Saloni.Select(p=>
                new
                {
                    ID=p.ID,
                    Naziv=p.Naziv,
                    Grad=p.Grad

                }).ToListAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniSalon/{id}/{naziv}/{grad}")]
        [HttpPut]
        public async Task<ActionResult> PromeniSalon(int id,string naziv,string grad)
        {
            if(string.IsNullOrEmpty(naziv))
                return BadRequest("Niste uneli naziv salona!");
            if(string.IsNullOrEmpty(grad))
                return BadRequest("Niste uneli grad!");
            try{
                var salon=Context.Saloni.Where(p=>p.ID==id).FirstOrDefault();
                if(salon!=null)
                {
                    salon.Naziv=naziv;
                    salon.Grad=grad;

                    await Context.SaveChangesAsync();
                    return Ok("Izmena uspesno izvrsena!");
                }
                else{
                    return BadRequest("Salon nije pronadjen!");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("IzbrisiSalon/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiSalon(int id)
        {
            
            try
            {
                var salon=Context.Saloni.Where(p=>p.ID==id).FirstOrDefault();
                var radnici=await Context.Radnici.Where(s=>s.Salon==salon).ToListAsync();
                radnici.ForEach(radnik=>
                {
                    Context.Radnici.Remove(radnik);
                });
                
                var tretmani=await Context.SaloniTretmani.Where(p=>p.Salon==salon).ToListAsync();
                tretmani.ForEach(tretmani=>
                {
                    Context.SaloniTretmani.Remove(tretmani);
                });

                var edukacije=await Context.Edukacije.Where(p=>p.salon==salon).ToListAsync();
                edukacije.ForEach(edukacija=>
                {
                    Context.Edukacije.Remove(edukacija);
                });
                var termini=await Context.EdukacijaTermini.Where(p=>p.Edukacija.salon==salon).ToListAsync();
                termini.ForEach(termin=>
                {
                    Context.EdukacijaTermini.Remove(termin);
                });
                
                
                string naziv=salon.Naziv;
                Context.Remove(salon);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno izbrisan salon {naziv}");
            }
            catch(Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        


    }
}