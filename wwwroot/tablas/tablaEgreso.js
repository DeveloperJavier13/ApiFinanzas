var btnConsultarAreas = document.querySelector('#btnConsultarTablaEgreso');
var btnIngresarEgreso = document.querySelector('#btnIngresarEgreso');
var btnActualizarEgreso = document.querySelector('#btnActualizarEgreso');
var btnEliminarEgreso = document.querySelector('#btnEliminarEgreso');

console.log('entra al metodo egreso');

var egreso = document.querySelector('#txtEgreso');
var conceptoEgr = document.querySelector('#txtConEgreso');

//Actualizar
var actEgrID = document.querySelector('#txtActEgrID');
var txtactEgr = document.querySelector('#txtActEgr');
var actConEgr = document.querySelector('#txtActConEgr');

//Elimnar
var delEgrID = document.querySelector('#txtDelEgrID');

btnConsultarAreas.addEventListener('click', () => {
    mostrarEgreso();
});

btnIngresarEgreso.addEventListener('click', ()=>{
    registrarDatoEgr();
});

btnActualizarEgreso.addEventListener('click', () =>{
    actualizarDatoEgr();
});

btnEliminarEgreso.addEventListener('click', () =>{
    eliminarRegistroEgr();
});

async function mostrarEgreso(){
    const mosEgr = await fetch(URL_EGRESO);
    const data = await mosEgr.json();
            let dataSetEgresos =[];
            data.forEach(registro => {
                dataSetEgresos.push(Object.values(registro));
            });

            let tablasArea = $('#areas-table').DataTable({
                data: dataSetEgresos,
                columns: [
                    {title: "EgresoID"},
                    {title: "Concepto"},
                    {title: "Egreso"}
                ],
                "bDestroy": true,
            });
}

async function registrarDatoEgr(){
    var egrID = String(egreso.value);
    var conEgr = String(conceptoEgr.value);
    const {mosIng,status} = await api.post('/egreso/crear',{
            egreso: egrID,
            conceptoEgr: conEgr,
    });
    console.log(egrID);

    if(status !== 200){
        console.log('Error al registrar el registro');
    }else{
        console.log('Registro registrado con éxito');
    }
    let inputValue = egrID.values; 
    document.getElementById("valueInputEgr").innerHTML = inputValue;
}

async function actualizarDatoEgr(){
    var egrID = String(actEgrID.value);
    var egr = String(txtactEgr.value);
    var conEgr = String(actConEgr.value);
    const {data, status} = await api.put('/egreso/actualizar/' + egrID,{
            egreso: egr,
            conceptoEgr: conEgr,
    });
    console.log(egrID);
   
    if(status !== 200){
        console.log('Error al modificar el registro');
    }else{
        console.log('Registro modificado con éxito');
    }
}

async function eliminarRegistroEgr(){
    var egrID = String(delEgrID.value);

    const {mosEgr, status} = await api.delete('/egreso/borrar/' + egrID,);
    if(status !== 200){
        console.log('Error al eliminar el registro');
    }else{
        console.log('Registro eliminado con éxito');
    }
}
