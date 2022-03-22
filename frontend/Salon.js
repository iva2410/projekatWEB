import {Radnik} from "./Radnik.js"
import {Termin} from "./Termin.js"
import {Edukacija } from "./Edukacija.js";
import {Tretman} from "./Tretman.js"

export class Salon{
    constructor(id,naziv,grad)
    {
        
        this.id=id;
        this.naziv=naziv;
        this.grad=grad;

        this.kont=null;
       
    }

    crtajSalon(host)
    {
        this.kont = document.createElement("div");
        this.kont.className = "GlavniKontejner";
        host.appendChild(this.kont);

        let glavno=document.createElement("div");
        glavno.className="glavno";
      

        let naziv=document.createElement("div");
        naziv.className="naziv";
        glavno.appendChild(naziv);

        let labNaziv=document.createElement("label");
        labNaziv.className="labNaziv";
        labNaziv.style.display="block";
        labNaziv.innerHTML="Naziv salona:";
        naziv.appendChild(labNaziv);

        let lbNaziv=document.createElement("label");
        lbNaziv.className="lbNaziv";
        lbNaziv.style.display="block";
        lbNaziv.innerHTML=this.naziv;
        naziv.appendChild(lbNaziv);

        let inputNaziv=document.createElement("input");
        inputNaziv.className="inputNaziv";
        inputNaziv.style.display="none";
        inputNaziv.type="text";
        naziv.appendChild(inputNaziv);


        let grad=document.createElement("div");
        grad.className="grad";
        glavno.appendChild(grad);

        let labGrad=document.createElement("label");
        labGrad.className="labGrad";
        labGrad.style.display="block";
        labGrad.innerHTML="Grad:";
        grad.appendChild(labGrad);

        let lbGrad=document.createElement("label");
        lbGrad.className="lbGrad";
        lbGrad.style.display="block";
        lbGrad.innerHTML=this.grad;
        grad.appendChild(lbGrad);

        let inputGrad=document.createElement("input");
        inputGrad.style.display="none";
        inputGrad.className="inputGrad";
        inputGrad.type="text";
        grad.appendChild(inputGrad);

        let btnIzmeni=document.createElement("button");
        btnIzmeni.innerHTML="Izmeni";
        btnIzmeni.className="btn"; 
        btnIzmeni.style.display="block";
        glavno.appendChild(btnIzmeni);

        let btnSacuvaj=document.createElement("button");
        btnSacuvaj.innerHTML="Sacuvaj";
        btnSacuvaj.className="btn";
        btnSacuvaj.style.display="none";
        glavno.appendChild(btnSacuvaj);

        let btnOtkazi=document.createElement("button");
        btnOtkazi.innerHTML="Otkazi";
        btnOtkazi.className="btn";
        btnOtkazi.style.display="none";
        glavno.appendChild(btnOtkazi);

        let prikaz=document.createElement("div");
        prikaz.className="prikaz";
       

        let labRadnik=document.createElement("h5");
        labRadnik.className="labRadnik";
        labRadnik.innerHTML="Radnici";
        prikaz.appendChild(labRadnik);

        var tabRadnici=document.createElement("table");
        tabRadnici.className="tabRadnici";
        prikaz.appendChild(tabRadnici);

        var tabhead1=document.createElement("thead");
        tabRadnici.appendChild(tabhead1);

        var tr1=document.createElement("tr");
        tabhead1.appendChild(tr1);

        var tabBody=document.createElement("tbody");
        tabBody.className="tabRadnika";
        tabRadnici.appendChild(tabBody);

        let th1;
        var zg1=["JMBG","Ime","Prezime","Pol","Godine rada","Plata","Otkaz"];
        zg1.forEach(el=>{
            th1=document.createElement("th");
            th1.innerHTML=el;
            tr1.appendChild(th1);
        })

        labRadnik=document.createElement("h5");
        labRadnik.className="tretmani";
        labRadnik.innerHTML="Tretmani";
        prikaz.appendChild(labRadnik);
        var tabTretmani=document.createElement("table");
        tabTretmani.className="tabTretmani";
        prikaz.appendChild(tabTretmani);

        var tabhead2=document.createElement("thead");
        tabTretmani.appendChild(tabhead2);

        var tr2=document.createElement("tr");
        tabhead2.appendChild(tr2);

        var tabBody2=document.createElement("tbody");
        tabBody2.className="tabTretman";
        tabTretmani.appendChild(tabBody2);

        let th2;
        var zg2=["Naziv","Cena","Vreme trajanja","Izmena"];
        zg2.forEach(el=>{
            th2=document.createElement("th");
            th2.innerHTML=el;
            tr2.appendChild(th2);
        })

        

        btnIzmeni.onclick=(ev)=>{
            lbNaziv.style.display="none";
            lbGrad.style.display="none";
            inputNaziv.style.display="block";
            inputGrad.style.display="block";
            btnIzmeni.style.display="none";
            btnSacuvaj.style.display="block";
            btnOtkazi.style.display="block";
            
            glavno.querySelector(".inputNaziv").value=this.naziv;
            glavno.querySelector(".inputGrad").value=this.grad;
           
        }

        this.kont.appendChild(glavno);

        this.kont.appendChild(prikaz);

        this.popuniListuRadnika();
        this.popuniListuTretmana();


        btnSacuvaj.onclick=(ev)=>{
            let naziv=glavno.querySelector(".inputNaziv").value;
            let grad=glavno.querySelector(".inputGrad").value;
            
            fetch("https://localhost:5001/Salon/PromeniSalon/"+this.id+"/"+naziv+"/"+grad,{
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
                body: JSON.stringify({
                    "id":this.id,
                    "naziv":naziv,
                    "grad":grad
                })
            }).then(p=>{
                if(p.ok){
                    console.log("ok");
                    lbNaziv.innerHTML=naziv;
                    lbGrad.innerHTML=grad;
                    lbNaziv.style.display="block";
                    lbGrad.style.display="block";
                    inputNaziv.style.display="none";
                    inputGrad.style.display="none";

                    btnIzmeni.style.display="block";
                    btnSacuvaj.style.display="none";
                    btnOtkazi.style.display="none";
                   
                }
                else{
                    console.log("nije ok");
                    lbNaziv.innerHTML=this.naziv;
                    lbGrad.innerHTML=this.grad;
                    lbNaziv.style.display="block";
                    lbGrad.style.display="block";
                    inputNaziv.style.display="none";
                    inputGrad.style.display="none";
                    btnIzmeni.style.display="block";
                    btnSacuvaj.style.display="none";
                    btnOtkazi.style.display="none";
                 
                }

            })
        
        }

        btnOtkazi.onclick=(ev)=>{
            lbNaziv.innerHTML=this.naziv;
            lbGrad.innerHTML=this.grad;
            lbNaziv.style.display="block";
            lbGrad.style.display="block";
            inputNaziv.style.display="none";
            inputGrad.style.display="none";
            btnIzmeni.style.display="block";
            btnSacuvaj.style.display="none";
            btnOtkazi.style.display="none";
            
        }

        let btnObrisi=document.createElement("button");
        btnObrisi.innerHTML="Obrisi";
        btnObrisi.className="btn";
        glavno.appendChild(btnObrisi);

        btnObrisi.onclick=(ev)=>{
            if(confirm("Da li ste sigurni?")){
            fetch("https://localhost:5001/Salon/IzbrisiSalon/"+this.id,{
                method: "DELETE"
            }).then(p=>{
                if(p.ok){
                alert("Uspesno obrisan salon!");
                document.location.reload();
                }
                else{
                    alert("Greska!");
                }
            });
        }
        } 

        this.crtajDodavanjeRadnika(glavno);
        this.crtajDodavanjeTretmana(glavno);
        this.crtajEdukacije(prikaz);
        
        this.kont.appendChild(prikaz);
        
    }

     crtajDodavanjeRadnika(glavno) {

            let btnDodajR=document.createElement("button");
            btnDodajR.innerHTML="Zaposli radnika";
            btnDodajR.className="btn";
            btnDodajR.style.display="block";
            glavno.appendChild(btnDodajR);

            let DIVJMBG=document.createElement("div");
            DIVJMBG.className="DIVJMBG";
            glavno.appendChild(DIVJMBG);

            let labJMBG=document.createElement("label");
            labJMBG.className="labJMBG";
            labJMBG.style.display="none";
            labJMBG.innerHTML="JMBG";
            DIVJMBG.appendChild(labJMBG);
           
            let inputJMBG=document.createElement("input");
            inputJMBG.className="inputJMBG";
            inputJMBG.style.display="none";
            DIVJMBG.appendChild(inputJMBG);

            let divIme = document.createElement("div");
            divIme.className = "divIme";
            glavno.appendChild(divIme);

            let labIme = document.createElement("label");
            labIme.className = "labIme";
            labIme.style.display="none";
            labIme.innerHTML = "Ime:";
            divIme.appendChild(labIme);

            let inputIme = document.createElement("input");
            inputIme.className = "inputIme";
            inputIme.style.display="none";
            inputIme.type = "text";
            divIme.appendChild(inputIme);

            let divPrezime = document.createElement("div");
            divPrezime.className = "divPrezime";
            glavno.appendChild(divPrezime);

            let labPrezime = document.createElement("label");
            labPrezime.className = "labPrezime";
            labPrezime.style.display="none";
            labPrezime.innerHTML = "Prezime:";
            divPrezime.appendChild(labPrezime);

            let inputPRrezime = document.createElement("input");
            inputPRrezime.style.display="none";
            inputPRrezime.className = "inputPRrezime";
            inputPRrezime.type = "text";
            divPrezime.appendChild(inputPRrezime);

            let divPol=document.createElement("div");
            divPol.className="divPol";
            glavno.appendChild(divPol);

            let labPol=document.createElement("label");
            labPol.className="labPol";
            labPol.style.display="none";
            labPol.innerHTML="Pol:";
            divPol.appendChild(labPol);

            let inputPol=document.createElement("input");
            inputPol.className="inputPol";
            inputPol.style.display="none";
            inputPol.type="text";
            divPol.appendChild(inputPol);

            let divGodine = document.createElement("div");
            divGodine.className = "divGodine";
            glavno.appendChild(divGodine);
    
            let labGodine = document.createElement("label");
            labGodine.className = "labGodine";
            labGodine.style.display="none";
            labGodine.innerHTML = "Godine rada:";
            divGodine.appendChild(labGodine);
    
            let inputGodine = document.createElement("input");
            inputGodine.className = "inputGodine";
            inputGodine.style.display="none";
            inputGodine.type = "number";
            divGodine.appendChild(inputGodine);

            let divPlata = document.createElement("div");
            divPlata.className = "divPlata";
            glavno.appendChild(divPlata);
    
            let labPlata = document.createElement("label");
            labPlata.className = "labPlata";
            labPlata.style.display="none";
            labPlata.innerHTML = "Plata ";
            divPlata.appendChild(labPlata);
    
            let inputPlata = document.createElement("input");
            inputPlata.className = "inputPlata";
            inputPlata.style.display="none";
            inputPlata.type = "number";
            divPlata.appendChild(inputPlata);


            btnDodajR.onclick=(ev)=>{
                labJMBG.style.display="block";
                inputJMBG.style.display="block";
                labIme.style.display="block";
                inputIme.style.display="block";
                labPrezime.style.display="block";
                inputPRrezime.style.display="block";
                labPol.style.display="block";    
                inputPol.style.display="block";
                labGodine.style.display="block";
                inputGodine.style.display="block";
                labPlata.style.display="block";
                inputPlata.style.display="block";
                btnOtkaziRad.style.display="block";
                btnSacuvajRad.style.display="block";
            }

            let btnSacuvajRad=document.createElement("button");
            btnSacuvajRad.innerHTML="Sacuvaj promene";
            btnSacuvajRad.className="btn";
            btnSacuvajRad.style.display="none";
            glavno.appendChild(btnSacuvajRad);
            btnSacuvajRad.onclick=(ev)=> {
                let jmbg=glavno.querySelector(".inputJMBG").value;
                let ime=glavno.querySelector(".inputIme").value;
                let prezime=glavno.querySelector(".inputPRrezime").value;
                let pol=glavno.querySelector(".inputPol").value;
                let god=glavno.querySelector(".inputGodine").value;
                let plata=glavno.querySelector(".inputPlata").value;
                
                fetch("https://localhost:5001/Radnik/DodajRadnika/"+jmbg+"/"+ime+"/"+prezime+"/"+pol+"/"+god+"/"+plata+"/"+this.id,
                {
                    method:"POST",
                    headers:{
                        "Content-Type":"aplication/json"
                    },
                    body: JSON.stringify(jmbg,ime,prezime,pol,god,plata,this.id)
                }).then(s=>{
                    if(s.ok){
                        this.popuniListuRadnika();
                    }
                    else{
                        alert("greska!");
                    }
                })

                labJMBG.style.display="none";
                inputJMBG.style.display="none";
                labIme.style.display="none";
                inputIme.style.display="none";
                labPrezime.style.display="none";
                inputPRrezime.style.display="none";
                labPol.style.display="none";    
                inputPol.style.display="none";
                labGodine.style.display="none";
                inputGodine.style.display="none";
                labPlata.style.display="none";
                inputPlata.style.display="none";
                btnOtkaziRad.style.display="none";
                btnSacuvajRad.style.display="none";
            
            }

            let btnOtkaziRad=document.createElement("button");
            btnOtkaziRad.innerHTML="Otkazi";
            btnOtkaziRad.className="btn";
            btnOtkaziRad.style.display="none"
            glavno.appendChild(btnOtkaziRad);

            btnOtkaziRad.onclick=(ev)=>{
                labJMBG.style.display="none";
                inputJMBG.style.display="none";
                labIme.style.display="none";
                inputIme.style.display="none";
                labPrezime.style.display="none";
                inputPRrezime.style.display="none";
                labPol.style.display="none";    
                inputPol.style.display="none";
                labGodine.style.display="none";
                inputGodine.style.display="none";
                labPlata.style.display="none";
                inputPlata.style.display="none";
                btnOtkaziRad.style.display="none";
                btnSacuvajRad.style.display="none";
            }


        }
        crtajDodavanjeTretmana(glavno){

            let btnDodajT=document.createElement("button");
            btnDodajT.innerHTML="Dodaj tretman";
            btnDodajT.className="btn";
            btnDodajT.style.display="block";
            glavno.appendChild(btnDodajT);

            let divNaziv=document.createElement("div");
            divNaziv.className="divNaziv";
            glavno.appendChild(divNaziv);

            let labNaziv=document.createElement("label");
            labNaziv.className="labNaziv";
            labNaziv.style.display="none";
            labNaziv.innerHTML="Naziv:";
            divNaziv.appendChild(labNaziv);

            let inputNaziv=document.createElement("input");
            inputNaziv.className="inputnaziv";
            inputNaziv.style.display="none";
            divNaziv.appendChild(inputNaziv);

            let divCena=document.createElement("div");
            divCena.className="divCena";
            glavno.appendChild(divCena);

            let labCena=document.createElement("label");
            labCena.className="labCena";
            labCena.style.display="none";
            labCena.innerHTML="Cena:";
            divCena.appendChild(labCena);

            let inputCena=document.createElement("input");
            inputCena.className="inputCena";
            inputCena.style.display="none";
            divCena.appendChild(inputCena);

            let divVreme=document.createElement("div");
            divVreme.className="divVreme";
            glavno.appendChild(divVreme);

            let labVreme=document.createElement("label");
            labVreme.className="labVreme";
            labVreme.style.display="none";
            labVreme.innerHTML="Vreme trajanja:";
            divVreme.appendChild(labVreme);

            let inputVreme=document.createElement("input");
            inputVreme.className="inputVreme";
            inputVreme.style.display="none";
            divVreme.appendChild(inputVreme);

            btnDodajT.onclick=(ev)=>{
                labNaziv.style.display="block";
                inputNaziv.style.display="block";
                labCena.style.display="block";
                inputCena.style.display="block";
                labVreme.style.display="block";
                inputVreme.style.display="block";
                
                btnOtkaziT.style.display="block";
                btnSacuvajT.style.display="block";
            }

            let btnSacuvajT=document.createElement("button");
            btnSacuvajT.innerHTML="Sacuvaj promene";
            btnSacuvajT.className="btn";
            btnSacuvajT.style.display="none";
            glavno.appendChild(btnSacuvajT);

            btnSacuvajT.onclick=(ev)=>{
                let naziv=glavno.querySelector(".inputnaziv").value;
                let cena=glavno.querySelector(".inputCena").value;
                let vreme=glavno.querySelector(".inputVreme").value;

                fetch("https://localhost:5001/Tretman/DodajTretman/"+naziv+"/"+cena+"/"+vreme+"/"+this.id,
                {
                    method:"POST",
                    headers:{
                        "Content-Type":"application/json"
                    },
                    body: JSON.stringify(naziv,cena,vreme,this.id)
                }).then(s=>{
                    if(s.ok){
                       
                        this.popuniListuTretmana();
                    }
                
                    else{
                    alert("greska!");
                    }
                })
                labNaziv.style.display="none";
                inputNaziv.style.display="none";
                labCena.style.display="none";
                inputCena.style.display="none";
                labVreme.style.display="none";
                inputVreme.style.display="none";
                
                btnOtkaziT.style.display="none";
                btnSacuvajT.style.display="none";
            }

            let btnOtkaziT=document.createElement("button");
            btnOtkaziT.innerHTML="Otkazi";
            btnOtkaziT.className="btn";
            btnOtkaziT.style.display="none";
            glavno.appendChild(btnOtkaziT);

            btnOtkaziT.onclick=(ev)=>{
                labNaziv.style.display="none";
                inputNaziv.style.display="none";
                labCena.style.display="none";
                inputCena.style.display="none";
                labVreme.style.display="none";
                inputVreme.style.display="none";
                
                btnOtkaziT.style.display="none";
                btnSacuvajT.style.display="none";
            }



        }
       crtajEdukacije(host){

       var url="https://localhost:5001/Termin/Termini/";
        fetch(url,{
            method:"GET",
            headers:{
                'Content-Type':'application/json'
            }
        }).then(s=>{
            if(s.ok){
                s.json().then(data=>{
                

           let edukacijaForma=document.createElement("div");
            edukacijaForma.className="edukacijaForma";
            host.appendChild(edukacijaForma);


            var red=document.createElement("div");
            red.className="edukacijaZaglavlje";
            var labela=document.createElement("label");
            labela.className="lbnaziv";
            labela.innerHTML="Izaberite dan: ";
            red.appendChild(labela);

            var se=document.createElement("select");
            se.className="comboBox";


            data.forEach(p=>{
                var op=document.createElement("option");
                op.innerHTML=p.dan;
                op.value=p.id;
               
                se.appendChild(op);

            })
            red.appendChild(se);
            

            var btnPretrazi=document.createElement("button");
            btnPretrazi.className="btn";
            btnPretrazi.onclick=(ev)=>  this.crtaj(edukacijaForma);
            btnPretrazi.innerHTML="Pretrazi:";
            red.appendChild(btnPretrazi);
            edukacijaForma.appendChild(red);

           

                });
            }
        });
    }

       crtaj(host)
       { 
           
           let termin=host.querySelector(".comboBox");
           let idtermin=termin.options[termin.selectedIndex].value;
          


           var url="https://localhost:5001/Edukacija/PrikaziEdukacije/"+idtermin+"/"+this.id;
           fetch(url,{
                method:"GET",
            headers: {
                'Content-Type':'application/json'
            }
           }).then(s=>{
               if(s.ok){

                   s.json().then(data=>
                    {
                        var tab=this.napraviTab(host);
                     
                        data.forEach(edukacija=>{
                            console.log(edukacija);
                            let p=new Edukacija(edukacija.id,edukacija.naziv,edukacija.mesta,edukacija.vreme,edukacija.ime+" "+edukacija.prezime,edukacija.salonid);   
                             p.dodajUTab(tab);
                            
                        });
                    });
               }
           });

          
                 
       }
    

       napraviTab(host) {
        var teloTabele = host.querySelector(".TabelaPodaci");

        if (teloTabele !== null) {
            var roditelj = teloTabele.parentNode;
            roditelj.removeChild(teloTabele);
        }


        teloTabele = document.createElement("tbody");
        teloTabele.className = "TabelaPodaci";
        host.appendChild(teloTabele);


        var tr = document.createElement("tr");
        var zag = ["NAZIV", "MESTA", "VREME","RADNIK"];
        zag.forEach(el => {
            var th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })

        teloTabele.appendChild(tr);



        return teloTabele;
    }
    
  

    

        popuniListuRadnika(){
            fetch("https://localhost:5001/Radnik/VratiRadnika/"+this.id,
            {
                method:"PUT",
                headers:{
                    "Content-Type": "application/json"
                },
                body:JSON.stringify(this.id)
            }).then(s=>{
                if(s.ok){
                    var teloTab = this.popuni();
                    s.json().then(data=>{
                        var i=0;
                        data.forEach(el=>{
                            let radnik=new Radnik(el.id,el.jmbg,el.ime,el.prezime,el.pol,el.godineRada,el.plata,this.id);
                            console.log(radnik);
                            radnik.crtajRadnika(teloTab,i++);
                        })
                    })
                }
            })
        }
      
        popuniListuTretmana(){
            fetch("https://localhost:5001/Tretman/VratiTretman/"+this.id,
            {
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify(this.id)
            }).then(s=>{
                if(s.ok){
                    var teloTab=this.obrisi2();
                    s.json().then(data=>{
                        var i=0;
                        data.forEach(el=>{
                            
                            let tretman=new Tretman(el.id,el.naziv,el.cena,el.vreme,el.salonid);
                            
                            tretman.crtajTretman(teloTab,i++);  
                                                      
                          
                           
                        });
                    })
                }
            })
        }

      
        popuni(){
            var teloTab=document.querySelector(".tabRadnika");
            var rod=teloTab.parentNode;
            rod.removeChild(teloTab);
            
            teloTab=document.createElement("tbody");
            teloTab.className="tabRadnika";
            rod.appendChild(teloTab);
            return teloTab;
        }

        obrisi2(){
            var teloTab=document.querySelector(".tabTretman");
            var rod=teloTab.parentNode;
            rod.removeChild(teloTab);

            teloTab=document.createElement("tbody");
            teloTab.className="tabTretman";
            rod.appendChild(teloTab);
            return teloTab;
        }
      

        
  



        

















    
}