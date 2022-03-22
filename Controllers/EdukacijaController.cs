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
    public class EdukacijaController : ControllerBase
    {
        public SalonContext Context { get; set; }
        public EdukacijaController(SalonContext context)
        {
            Context = context;
        }

        [Route("PrikaziEdukacije/{terminid}/{salonid}")]
        [HttpGet]

        public async Task<ActionResult> PrikaziEdukacije(int terminid,int salonid)
        {
            try{
                if(salonid<0)
                {
                    return BadRequest("Salon ne postoji");
                }
                if(terminid<0)
                {
                    return BadRequest("Termin ne postoji");
                }
                var ret= await Context.EdukacijaTermini
                                        
                                        .Include(p=>p.Termin)
                                        .Include(p=>p.Edukacija)
                                        .Include(p=>p.Edukacija.Radnik)
                                        .Where(p=>p.Edukacija.salon.ID==salonid && p.Termin.ID==terminid)
                                        .Select(p=>
                                        new
                                        {
                                            id=p.ID,
                                            naziv=p.Edukacija.Ime,
                                            mesta=p.Edukacija.SlobodnaMesta,
                                            vreme=p.Vreme.ToString("HH:mm"),
                                           ime=p.Edukacija.Radnik.Ime,
                                           prezime=p.Edukacija.Radnik.Prezime
                                         }).ToListAsync();                                
                 return Ok(ret);
                          
        
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        


      

       

      

        

        
    }
}