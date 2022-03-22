export class Edukacija{
    constructor(id,naziv,mesta,termin,radnik,salonid)
    {
        this.id=id;
        this.naziv=naziv;
        this.mesta=mesta;
        this.termin=termin;
        this.radnik=radnik;
       
        
        this.salonid=salonid;
    }
   

    dodajUTab(host){
        var tr=document.createElement("tr");
        tr.className="trE";
        host.appendChild(tr);

        var td=document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML=this.naziv;
        tr.appendChild(td);

        var td1 = document.createElement("td");
        td1.className="tdmesta";
        td1.innerHTML = this.mesta;
        tr.appendChild(td1);

        td = document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML = this.termin;
        tr.appendChild(td);


        td=document.createElement("td");
        td.className="tdrRadnici";
        td.innerHTML=this.radnik;
        tr.appendChild(td);
        
   
            
        }

    
    
}