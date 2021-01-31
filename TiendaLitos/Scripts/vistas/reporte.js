$(function () {
    $(document).on("click", "button[data-generar-reporte]", function () {
        var TipoReporte = $("#TipoReporte").val();
        var FInicio = $("#FInicio").val();
        var FFinal = $("#FFinal").val();
        var filtro = { TipoReporte: TipoReporte, FInicio: FInicio, FFinal: FFinal };

        if (filtro.FFinal && !filtro.FInicio) {
            toastr.error("La busqueda por rango de fecha debe contener fecha inicial y final.");
            return;
        }
        switch (+filtro.TipoReporte) {
            case 1:
                reporteVentas(filtro);
                break;
            case 2:
                reporteCompras(filtro);
                break;
            case 3:
                reporteArtBodega(filtro);
                break;
            case 4:
                reporteProductosMasVendidos(filtro);
                break;
        }
        
    });

    

    function reporteVentas(filtro) {
        HttpClient.Post("ListadoVentas.aspx/ReporteVentas", JSON.stringify({ reporteRequest: filtro })).then((response) => {
            var byte = response.d.replace(/['"]+/g, '');

            var src = "data:application/pdf;base64," + byte;

            var embed = $("#embedReporte");

            document.getElementById("embedReporte").src = src;

            $(embed).show();
            $("#reporte-avance-procesos").show();
        });
    }
    function reporteProductosMasVendidos(filtro) {
        HttpClient.Post("ListadoVentas.aspx/ReporteProductosMasVendidosPdf", JSON.stringify({ reporteRequest: filtro })).then((response) => {
            var byte = response.d.replace(/['"]+/g, '');

            var src = "data:application/pdf;base64," + byte;

            var embed = $("#embedReporte");

            document.getElementById("embedReporte").src = src;

            $(embed).show();
            $("#reporte-avance-procesos").show();
        });
    }

    function reporteArtBodega(filtro) {
        HttpClient.Post("ArticuloBodega.aspx/ReporteArticuloBodega", JSON.stringify({ reporteRequest: filtro })).then((response) => {
            var byte = response.d.replace(/['"]+/g, '');

            var src = "data:application/pdf;base64," + byte;

            var embed = $("#embedReporte");

            document.getElementById("embedReporte").src = src;

            $(embed).show();
            $("#reporte-avance-procesos").show();
        });
    }

    function reporteCompras(filtro) {
        HttpClient.Post("ListadoCompras.aspx/ReporteCompras", JSON.stringify({ reporteRequest: filtro })).then((response) => {
            var byte = response.d.replace(/['"]+/g, '');

            var src = "data:application/pdf;base64," + byte;

            var embed = $("#embedReporte");

            document.getElementById("embedReporte").src = src;

            $(embed).show();
            $("#reporte-avance-procesos").show();
        });
    }
   

});