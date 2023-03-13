console.log('holamundo');
const api = axios.create({
    baseURL:"http://localhost:5030/api/"
});
  const URL_INGRESO = 'http://localhost:5030/api/ingreso/mostrar';
/*const URL_CREAR_INGRESO = 'http://localhost:5030/api/ingreso/crear';
const URL_ACTUALIZAR_INGRESO = 'http://localhost:5030/api/ingreso/actualizar/{id}';

fetch(URL_INGRESO)
    .then (res => res.json())
    .then(data => {
        console.log(data[0].ingresoID);
        console.log(URL_INGRESO);
        console.log(URL_CREAR_INGRESO);
        console.log(URL_ACTUALIZAR_INGRESO);
    }); */