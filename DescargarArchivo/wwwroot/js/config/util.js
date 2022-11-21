const obtenerUrl = () => window.location.href;

const concatenarUrl = function (url, valor1, valor2) {
    if (validarNullEmptyUndefined(url))
        return url;

    if (validarNullEmptyUndefined(valor1))
        return valor1;

    if (validarNullEmptyUndefined(valor2)) {
        return url + valor1;
    } else {
        return url + valor1 + valor2;
    }
}

const validarNullEmptyUndefined = function (cadena) {
    cadena = cadena.trim();
    if (cadena === "")
        return true;

    if (cadena === null)
        return true;

    if (cadena === undefined)
        return true;
    return false;
}

const obtenerDatosTabla = function (nombreTabla) {
    var array = [];
    var oTable = document.getElementById(nombreTabla);
    var rowLength = oTable.rows.length;
    for (i = 1; i < rowLength; i++) {
        var oCells = oTable.rows.item(i).cells;
        var cellLength = oCells.length;
        for (var j = 0; j < cellLength; j++) {
            var cellVal = oCells.item(j).innerHTML;
            array.push(cellVal);
        }
    }
    return array;
}