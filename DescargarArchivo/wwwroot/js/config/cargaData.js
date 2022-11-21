const cargarDatos = async (url) => {
    var tableContent = "";
    var tbody = document.getElementById("tableBody");

    fetch(url)
        .then(response => {
            return response.json();
        })
        .then((json) => {
            var cabecera = json.header;
            var tra = $("<tr>");
            var destino = $("<th>" + cabecera.etiqueta1 + "</th>").addClass("title-card");
            var fecha = $("<th>" + cabecera.etiqueta2 + "</th>").addClass("title-card");
            var monto = $("<th>" + cabecera.etiqueta3 + "</th>").addClass("title-card");
            var trc = ("</tr>");
            $("#tableHeader").append(tra).append(destino).append(fecha).append(monto).append(trc);
            var datos = json.data;
            for (var i = 0; i <= datos.length - 1; i++) {
                tableContent = $("<tr><td>" + datos[i].destino + "</td>" + "<td>" + datos[i].fecha + "</td>" + "<td>" + datos[i].monto + "</td>" + "</tr>");
                $(tbody).append(tableContent);
            }

            console.log(json);
        })
}



const crearObjeto = function (arreglo, colunmas) {
    var modelo = {
        header: {},
        data: []
    }
    modelo.header.etiqueta1 = "Destino";
    modelo.header.etiqueta2 = "Fecha";
    modelo.header.etiqueta3 = "Monto";

    for (var i = 0; i < arreglo.length; i = i + colunmas) {
        var objeto = {
            destino: arreglo[i],
            fecha: arreglo[i + 1],
            monto: arreglo[i + 2]
        }
        modelo.data.push(objeto);
    }
    return modelo;
}
