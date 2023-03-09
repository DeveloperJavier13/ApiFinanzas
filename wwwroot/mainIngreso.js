console.log('holamundo')

const URL2 = 'http://localhost:5030/api/ingreso/mostrar';
fetch(URL2)
    .then (res => res.json())
    .then(data => {
        console.log(data[0].ingresoID);
    });