var btnConsultarAreas = document.querySelector('#btnConsultarTablaIngreso');
console.log('entra al metodo ingreso');
btnConsultarAreas.addEventListener('click', () => {
    fetch(URL2)
        .then(res => res.json())
        .then(data => {
            let dataSetEgresos =[];
                console.log({data});
            data.forEach(registro => {
                dataSetEgresos.push(Object.values(registro));
            });

            let tablasArea = $('#areas-tableIngreso').DataTable({
                data: dataSetEgresos,
                columns: [
                    {title: "Egreso"},
                    {title: "Concepto"},
                ],
                "bDestroy": true,
            });
        });
});