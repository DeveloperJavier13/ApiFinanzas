var btnConsultarAreas = document.querySelector('#btnConsultarTabla');
console.log('entra al metodo');
btnConsultarAreas.addEventListener('click', () => {
    fetch(URL)
        .then(res => res.json())
        .then(data => {
            let dataSetEgresos =[];
                console.log({data});
            data.forEach(registro => {
                dataSetEgresos.push(Object.values(registro));
            });

            let tablasArea = $('#areas-table').DataTable({
                data: dataSetEgresos,
                columns: [
                    {title: "EgresoID"},
                    {title: "Concepto"},
                ],
                "bDestroy": true,
            });
        });
});