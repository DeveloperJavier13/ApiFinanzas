console.log('holamundo')

const URL = 'http://localhost:5030/api/ingreso/mostrar';
fetch(URL)
    .then (res => res.json())
    .then(data => {
        console.log(data[0].ingresoID);
    });