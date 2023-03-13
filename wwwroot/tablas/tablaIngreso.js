var btnConsultarAreas = document.querySelector('#btnConsultarTablaIngreso');
var btnIngresarIngreso = document.querySelector('#btnIngresarIngreso');
var btnActualizarIngreso = document.querySelector('#btnActualizarIngreso');
var btnEliminarIngreso = document.querySelector('#btnEliminarIngreso');

var ingreso = document.querySelector('#txtIngreso');
var conceptoIng = document.querySelector('#txtConIngreso');

//Actualizar
var actIngID = document.querySelector('#txtActIngID');
var txtactIng = document.querySelector('#txtActIng');
var actConIng = document.querySelector('#txtActConIng');

//Elimnar
var delIngID = document.querySelector('#txtDelIngID');

console.log('entra al metodo ingreso');

//botones
btnConsultarAreas.addEventListener('click', () => {
    mostrarIngreso();
    
});
btnIngresarIngreso.addEventListener('click', ()=>{
    registrarDatoIng();
})

btnActualizarIngreso.addEventListener('click', () =>{
    actualizarDatoIng();
});

btnEliminarIngreso.addEventListener('click', () =>{
    eliminarRegistroIng();
});

//funciones
async function mostrarIngreso(){
    const mosIng = await fetch(URL_INGRESO);
    const data = await mosIng.json();
    
            let dataSetIngresos =[];
            data.forEach(registro => {
                dataSetIngresos.push(Object.values(registro));
            });

            let tablasArea = $('#areas-tableIngreso').DataTable({
                data: dataSetIngresos,
                columns: [
                    {title: "IngresoID"},
                    {title: "Concepto"},
                    {title: "Ingreso"},
                ],
                "bDestroy": true,
            });
}

async function registrarDatoIng(){
    var ingID = String(ingreso.value);
    var conIng = String(conceptoIng.value);
    const {mosIng,status} = await api.post('/ingreso/crear',{
            ingreso: ingID,
            conceptoIng: conIng,
    });
    if(status !== 200){
        console.log('Error al registrar el registro');
    }else{
        console.log('Registro registrar con éxito');
    }
}

async function actualizarDatoIng(){
    var ingID = String(actIngID.value);
    var ing = String(txtactIng.value);
    var conIng = String(actConIng.value);
    console.log({ingID}); 
    console.log(isNaN(ing));
    console.log(ing);
    console.log(conIng);
    const {data, status} = await api.put('/ingreso/actualizar/' + ingID,{
            ingreso: ing,
            conceptoIng: conIng,
    });
    console.log(ingID);
   
    if(status !== 200){
        console.log('Error al modificar el registro');
    }else{
        console.log('Registro modificado con éxito');
    }
}

async function eliminarRegistroIng(){
    var ingID = String(delIngID.value);

    const {mosIng,status} = await api.delete('/ingreso/borrar/' + ingID,);
    if(status !== 200){
        console.log('Error al eliminar el registro');
    }else{
        console.log('Registro eliminado con éxito');
    }
}
    