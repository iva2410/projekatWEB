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
    public class RadnikController : ControllerBase
    {
        public SalonContext Context { get; set; }
        public RadnikController(SalonContext context)
        {
            Context = context;
        }

    [Route("DodajRadnika/{jmbg}/{ime}/{prezime}/{pol}/{godrada}/{plata}/{idSalona}")]
    [HttpPost]
    public async Task<ActionResult> DodajRadnika(string jmbg,string ime,string prezime, string pol,int godrada,int plata,int idSalona)
    {
        Radnik radnici=await Context.Radnici.Where(p=>p.JMBG==jmbg).FirstOrDefaultAsync();
        if(radnici!=null)
        {
            return  BadRequest("Jedan radnik moze raditi samo u jednom salonu!");
        }
        else
        {
            Radnik radnik=new Radnik();
            radnik.JMBG=jmbg;
            radnik.Ime=ime;
            radnik.Prezime=prezime;
            radnik.Pol=pol;
            radnik.GodineRada=godrada;
            radnik.Plata=plata;
            Salon salon=await Context.Saloni.FirstOrDefaultAsync(s=>s.ID==idSalona);
            radnik.Salon=salon;
            if(jmbg.Length!=13)
                return BadRequest("JMBG mora imati 13 karaktera!");
            if(string.IsNullOrEmpty(radnik.Ime))
                return BadRequest("Niste uneli ime!");
            if(string.IsNullOrEmpty(radnik.Prezime))
                return BadRequest("Niste uneli prezime!");
            if(string.IsNullOrEmpty(radnik.Pol))
                return BadRequest("Niste uneli pol!");
            if(radnik.GodineRada>64)
                return BadRequest("Pogresna vrednost!");
            if(radnik.Plata<0)
                return BadRequest("Pogresna vrednost plate!");

            Context.Radnici.Add(radnik);
            await Context.SaveChangesAsync();
            return Ok($"Radnik sa ID-em {radnik.ID} je dodat!");
        }
    }

    [Route("IzbrisatiRadnika/{id}")]
    [HttpDelete]
    public async Task<ActionResult> IzbrisatiRadnika(int id)
    {
       
        try{
            var radnik=await Context.Radnici.Where(p=>p.ID==id).FirstOrDefaultAsync();
           if (radnik==null)
           {
               return BadRequest("Radnik nije pronadjen");
           }
           var edukacija=await Context.Edukacije.Where(p=>p.Radnik==radnik).FirstOrDefaultAsync();
           if(edukacija!=null)
           {
               return BadRequest("Nije moguce otpustiti radnika");
           }
           string jmbg=radnik.JMBG;
            Context.Radnici.Remove(radnik);
            await Context.SaveChangesAsync();
            return Ok($"Uspesno obrisan radnik sa jmbg-om {jmbg}");
            
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("VratiRadnika/{salonid}")]
    [HttpPut]
    public async Task<ActionResult> VratiRadnika([FromRoute] int salonid)
    {
        try{
            var salonRadnici=Context.Radnici
                    .Where(p=>p.Salon.ID==salonid);
            var radnici=await salonRadnici.ToListAsync();
            return Ok
            (
                radnici.Select(p=>
                new{
                    ID=p.ID,
                    JMBG=p.JMBG,
                    Ime=p.Ime,
                    Prezime=p.Prezime,
                    Pol=p.Pol,
                    GodineRada=p.GodineRada,
                    Plata=p.Plata,
                    Salon=p.Salon
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