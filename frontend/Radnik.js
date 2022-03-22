export class Radnik{
    constructor(id,jmbg,ime,prezime,pol,godineRada,plata,idsalona){
        this.id=id;
        this.jmbg=jmbg;
        this.ime=ime;
        this.prezime=prezime;
        this.pol=pol;
        this.godineRada=godineRada;
        this.plata=plata;
        this.idsalona=idsalona;
    }
    crtajRadnika(host,i){
        var tr=document.createElement("tr");
        tr.className="trBrisi"+i;
        host.appendChild(tr);


        var td=document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML=this.jmbg;
        tr.appendChild(td);

        td=document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML=this.ime;
        tr.appendChild(td);

        td=document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML=this.prezime;
        tr.appendChild(td);

        td=document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML=this.pol;
        tr.appendChild(td);

        td=document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML=this.godineRada;
        tr.appendChild(td);

        td=document.createElement("td");
        td.className="tdRadnici";
        td.innerHTML=this.plata+ " dinara";
        tr.appendChild(td);

        

        td=document.createElement("td");
        td.className="tdRadnici";
        tr.appendChild(td);

        let btnOtpusti=document.createElement("button");
        btnOtpusti.innerHTML="Otpusti";
        btnOtpusti.className="btn";
        td.appendChild(btnOtpusti);
        btnOtpusti.onclick=(ev)=>{
            if(confirm("Da li ste sigurni?")){
            fetch("https://localhost:5001/Radnik/IzbrisatiRadnika/"+this.id,{
                method:"DELETE"
                
            }).then(p=>{
              
                if(p.ok){
                    
                    var tab=document.querySelector(".trBrisi"+i);
                   
                    var roditelj=tab.parentNode;
                    roditelj.removeChild(tab);
                    
                }
                else{
                    alert("Nije moguce otpustiti radnika");
                }
            
            });
        }

            
        }
    }
}