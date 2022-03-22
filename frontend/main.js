import { Salon } from "./Salon.js";
import{Edukacija} from "./Edukacija.js";
import { Termin } from "./Termin.js";
import { Radnik } from "./Radnik.js";


    fetch("https://localhost:5001/Salon/PreuzmiSalone").then(p=>{
        if(p.ok){
            p.json().then(saloni=>{

                  saloni.forEach(element => {
                    
                    var divb = document.createElement("div");
                    divb.className = "izborSalona";
                    divb.innerHTML = element.naziv;
                    document.body.appendChild(divb);
            
                    divb.onclick=(ev)=>{
                    var s=new Salon(element.id,element.naziv,element.grad);
                    var pozadina=document.body.querySelector(".pozadina");
                    if(pozadina!==null){
                        var rod=pozadina.parentNode;
                        rod.removeChild(pozadina);
                    }

                    var izborSalona=document.body.querySelectorAll(".izborSalona");
                    izborSalona.forEach(element => {
                        let rod = element.parentNode;
                        rod.removeChild(element);
                    });

                    pozadina=document.createElement("div");
                    pozadina.className="pozadina";
                    document.body.appendChild(pozadina);
                       
                s.crtajSalon(pozadina);
                };
                });
            });
        }
    });
        
         
  
      




