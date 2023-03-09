
btnConsultarAreas.addEventListener('click', () => {
    fetch('URL', {
    method: "GET",
    headers: {"Content-type": ""}
    })
        .then(response => response.json()) 
        .then(json => console.log(json))
        .catch(err => console.log(err));
})
