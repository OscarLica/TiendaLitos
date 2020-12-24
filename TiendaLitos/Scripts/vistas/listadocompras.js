$(function () {
    var compras = [];
    GetListaCompras();
    function GetListaCompras() {
        HttpClient.Get("ListadoCompras.aspx/ConsultarCompras").then((response) => {
            compras = response.d;
            CargarListaCompras(compras);
        });
    }

    $(document).on("keyup", "input[data-search]", function () {
        var filtro = this.value;
        var result = compras.filter((c) => {
            return c.NoFactura.includes(filtro) || c.Fecha.includes(filtro) || c.Moneda.includes(filtro)|| c.Iva.toString().includes(filtro) || c.SubTotal.toString().includes(filtro) || c.Total.toString().includes(filtro)
                || c.Proveedor.includes(filtro);
        });
        if (!filtro)
            result = compras;
        CargarListaCompras(result);
    });
    function CargarListaCompras(listado) {
        var row = "";
        $.each(listado, function (i, item) {
            row += "<tr>";
            row += "<td>" + item.NoFactura + "</td>";
            row += "<td>" + item.Fecha + "</td>";
            row += "<td>" + item.Moneda + "</td>";
            row += "<td>% " + item.Iva + "</td>";
            row += "<td>C$ " + item.SubTotal + "</td>";
            row += "<td>C$ " + item.SubTotalLocal + "</td>";
            row += "<td>C$ " + item.Total + "</td>";
            row += "<td>C$ " + item.TotalLocal + "</td>";
            row += "<td>" + item.Proveedor + "</td>";
            row += "<td><button type='button' class='btn btn-warning' data-accion-view=" + item.IdCompra + ">" + Utilidades.IconView() + "</button></td> ";
            row += "</tr>";
        });
        $("#result").html("");
        $("#result").html(row);

    }
    $(document).on("click", "button[data-accion-view]", function () {

        var detalleCompra = compras.find((c) => c.IdCompra === $(this).data("accionView"));
        $("#resultDetalle").html("");
        $("#detalleCompra").modal("show");
        $("#tituloDetallCompra").html("Detalle compra " + detalleCompra.NoFactura + " fecha " + detalleCompra.Fecha);

        var row = "";
        $.each(detalleCompra.detalle, function (i, det) {
            row += "<tr><td>" + det.Articulo + "</td><td>" + det.Color + "</td><td>" + det.Marca + "</td><td>" + det.Medida + "</td><td>" + det.Talla + "</td><td>" + det.Cantidad + "</td><td>C$ " + det.Precio + "</td><td>% " + det.Descuento + "</td><td>C$ " + det.SubTotalArticulo + "</td><td>C$ " + det.SubTotalArticuloLocal +"</td></tr>";
        });
        $("#resultDetalle").html(row);
    });
});