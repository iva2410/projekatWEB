export class Tretman{
    constructor(id,naziv,cena,vreme,salon)
    {
        this.id=id;
        this.naziv=naziv;
        this.cena=cena;
        this.vreme=vreme;
        this.salon=salon;
    }

    crtajTretman(host,i){
        var tr=document.createElement("tr");
        tr.className="brisi"+i;
        host.appendChild(tr);

        var td=document.createElement("td");
        td.className="tdTretman";
        td.innerHTML=this.naziv;
        tr.appendChild(td);

        var td=document.createElement("td");
        td.className="trcena";
        td.innerHTML=this.cena;
        tr.appendChild(td);

        var td=document.createElement("td");
        td.className="tdTretman";
        td.innerHTML=this.vreme+" minuta";
        tr.appendChild(td);

      

        td=document.createElement("td");
        td.className="tdTretman";
        tr.appendChild(td);

      

        let btnIzmeniT=document.createElement("button");
        btnIzmeniT.innerHTML="Izmeni cenu";
        btnIzmeniT.className="btn";
        //td.appendChild(btnIzmeniT);

        let inputCena=document.createElement("input");
        inputCena.style.display="block";
        inputCena.className="cena";
        inputCena.type="number";
        //td.appendChild(inputCena);

        let div=document.createElement("div");
        div.className="div";
        td.appendChild(div);
        div.appendChild(btnIzmeniT);
        div.appendChild(inputCena);


        

        btnIzmeniT.onclick=(ev)=>{
            fetch("https://localhost:5001/Tretman/Izmena/"+this.id+"/"+td.querySelector(".cena").value,
            {
                method:"PUT"

            }).then(s=>{
                if(s.ok){
                    tr.querySelector(".trcena").innerHTML=td.querySelector(".cena").value;
                    td.querySelector(".cena").value='';
                }
                else {
                    alert("Doslo je do greske!");
                }
            })
        }

      

    }
}