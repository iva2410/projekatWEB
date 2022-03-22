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
    public class TerminController : ControllerBase
    {
        public SalonContext Context { get; set; }
        public TerminController(SalonContext context)
        {
            Context = context;
        }

        [Route("Termini")]
        [HttpGet]
        public async Task<ActionResult> Termini()
        {
            try{
                return Ok(await Context.Termini.Select(p=>
                new{
                    id=p.ID,
                    dan=p.Dan
                }).ToListAsync());
                       
               
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       

        
    }
}