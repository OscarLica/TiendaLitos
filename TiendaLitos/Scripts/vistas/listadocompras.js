$(function () {
    var compras = [];
    HttpClient.Get("ListadoCompras.aspx/ConsultarCompras").then((response) => {
        var row = "";
        compras = response.d;
        $.each(response.d, function (i, item) {
            row += "<tr>";
            row += "<td>" + item.NoFactura + "</td>";
            row += "<td>" + item.Fecha + "</td>";
            row += "<td>% " + item.Iva + "</td>";
            row += "<td>C$ " + item.SubTotal + "</td>";
            row += "<td>C$ " + item.Total + "</td>";
            row += "<td>" + item.Proveedor + "</td>";
            row += "<td><button type='button' class='btn btn-warning' data-accion-view=" + item.IdCompra + ">" + Utilidades.IconView() + "</button></td> ";
            row += "</tr>";
        });
        $("#result").html(row);
    });
    $(document).on("click", "button[data-accion-view]", function () {

        var detalleCompra = compras.find((c) => c.IdCompra === $(this).data("accionView"));
        $("#resultDetalle").html("");
        $("#detalleCompra").modal("show");
        $("#tituloDetallCompra").html("Detalle compra " + detalleCompra.NoFactura + " fecha " + detalleCompra.Fecha);

        var row = "";
        $.each(detalleCompra.detalle, function (i, det) {
            row += "<tr><td>" + det.Articulo + "</td><td>" + det.Cantidad + "</td><td>C$ " + det.Precio+ "</td><td>% " + det.Descuento + "</td><td>C$ " + det.SubTotalArticulo +"</td></tr>";
        });
        $("#resultDetalle").html(row);
    });
});