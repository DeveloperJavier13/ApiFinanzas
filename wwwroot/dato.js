
var btnPruebaEgr = document.querySelector('#btnPruebaEgr');
var btnPruebaIng = document.querySelector('#btnPrueba');
var btnPruebaAct = document.querySelector('#btnPruebaAct');
var btnSuma = document.querySelector('#btnSuma');

let txtEgreso = document.querySelector('#txtEgreso');
let txtIngreso = document.querySelector('#txtIngreso');
let txtActualizarIng = document.querySelector('#txtActIng');

//const URL_CREAR = 'http://localhost:5030/api/ingreso/crear';
//const URL_DATOS = 'http://localhost:5030/api/egreso/crear';

btnPruebaEgr.addEventListener('click', () => {
    mostrarEgr();
});

btnPruebaIng.addEventListener('click', () => {
    mostrarIng();
});

btnPruebaAct.addEventListener('click', () => {
    actIng();
});
function mostrarEgr(){
    let inputValue = txtEgreso.value; 
    document.getElementById("valueInputEgr").innerHTML = inputValue; 
}

function mostrarIng(){
    let inputValue = txtIngreso.value; 
    document.getElementById("valueInput").innerHTML = inputValue; 
}

function actIng(){
    let inputValue = txtActualizarIng.value; 
    console.log(inputValue);
    document.getElementById("valueInputAct").innerHTML = inputValue; 
}