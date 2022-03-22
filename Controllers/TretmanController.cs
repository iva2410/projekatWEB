using Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace webprojekatControllers
{
    [ApiController]
    [Route("[controller]")]
    public class TretmanController : ControllerBase
    {
        public SalonContext Context { get; set; }
        public TretmanController(SalonContext context)
        {
            Context = context;
        }

        [Route("Izmena/{tretmanid}/{cena}")]
        [HttpPut]
            public async Task<ActionResult> Izmena( int tretmanid,int cena)
            {
                if(cena<=0)
                    return BadRequest("Pogresna vrednost");
                try{
                    var tretman=Context.SaloniTretmani.Where(p=>p.ID==tretmanid).FirstOrDefault();
                   if(tretman!=null)
                   {
                       tretman.Cena=cena;
                       await Context.SaveChangesAsync();
                       return Ok("Izmena uspesno izvrsena!");
                   }
                   else{
                       return BadRequest("Tretman nije pronadjen!");
                   }
                }
                catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        
        

        [Route("DodajTretman/{naziv}/{cena}/{vremetrajanja}/{idSalona}")]
        [HttpPost]
        public async Task<ActionResult> DodajTretman(string naziv,int cena,int vremetrajanja,int idSalona)
        {
            if(idSalona<0)
                return BadRequest("Salon ne postoji!");
            if(cena<=0)
                return BadRequest("Pogresna cena");
            try{
                
                Tretman t=new Tretman{
                    Naziv=naziv,
                    VremeTrajanja=vremetrajanja
                
                };
            
               // Context.Tretmani.Add(t);
                var nadjenSalon=await Context.Saloni.FindAsync(idSalona);
                
                SalonTretman st=new SalonTretman
                {
                    Cena=cena
                };
                st.Tretman=t;
                st.Salon=nadjenSalon;
                Context.SaloniTretmani.Add(st);
                Context.Tretmani.Add(t);
                await Context.SaveChangesAsync();
                return Ok("uspesno");
                                    
           }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        [Route("VratiTretman/{salonid}")]
        [HttpPut]
        public async Task<ActionResult> VratiTretman([FromRoute] int salonid)
        {
            try{
                var salonTretman=Context.SaloniTretmani
                        .Include(p=>p.Tretman)
                        .Include(p=>p.Salon)
                        .Where(p=>p.Salon.ID==salonid);
                        
                var tretmani=await salonTretman.ToListAsync();
                return Ok(
                   
                       tretmani.Select(p=>
                       new{
                           ID=p.ID,
                           naziv=p.Tretman.Naziv,
                           cena=p.Cena,
                           vreme=p.Tretman.VremeTrajanja,
                           
                       }).ToList()
                   );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

     
    }
}