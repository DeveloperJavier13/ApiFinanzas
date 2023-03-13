var btnSuma = document.querySelector('#btnSuma');

btnSuma.addEventListener('click', () => {
    mostrarSuma();
});

async function mostrarSuma(){
    const mosEgr = await api.get('/suma/total')
    .then((respuesta) =>{
        console.log(respuesta.data);
        document.getElementById("valueInputSuma").innerHTML = respuesta.data;
    });
}