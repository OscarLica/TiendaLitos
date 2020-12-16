$(function () {
    var ventas = [];
    HttpClient.Get("ListadoVentas.aspx/ConsultarVentas").then((response) => {
        var row = "";
        ventas = response.d;
        $.each(response.d, function (i, item) {
            row += "<tr>";
            row += "<td>" + item.Fecha + "</td>";
            row += "<td>% " + item.Iva + "</td>";
            row += "<td>C$ " + item.SubTotal + "</td>";
            row += "<td>C$ " + item.Total + "</td>";
            row += "<td>" + item.Cliente + "</td>";
            row += "<td><button type='button' class='btn btn-warning' data-accion-view=" + item.IdVenta + ">" + Utilidades.IconView() + "</button></td> ";
            row += "</tr>";
        });
        $("#result").html(row);
    });
    $(document).on("click", "button[data-accion-view]", function () {

        var detalleVenta = ventas.find((c) => c.IdVenta === $(this).data("accionView"));
        $("#resultDetalle").html("");
        $("#detalleVenta").modal("show");
        $("#tituloDetalleVenta").html("Detalle venta " + detalleVenta.IdVenta + " fecha " + detalleVenta.Fecha);

        var row = "";
        $.each(detalleVenta.detalle, function (i, det) {
            row += "<tr><td>" + det.Articulo + "</td><td>" + det.Cantidad + "</td><td>" + det.Color + "</td><td>" + det.Medida + "</td><td>" + det.Marca + "</td><td>" + det.Talla + "</td><td>C$" + det.Precio + "</td><td>%" + det.Descuento + "</td><td> C$" + det.SubTotal + "</td></tr>";
        });
        $("#resultDetalle").html(row);
    });
});