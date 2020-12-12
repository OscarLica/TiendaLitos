$(function () {

    HttpClient.Get("ArticuloBodega.aspx/GetArticulosBodega").then((response) => {

        var row = "";
        $.each(response.d, function (i, item) {

            row += "<tr><td>" + item.Bodega + "</td>";

            if (item.ArticuloBodega.length) {
                row += "<td>";
                row += "<table class='table table-stripped table-hover'>";
                row += "<thead>";
                row += "<tr><th>Articulo</th><th>Precio compra</th><th>Precio venta</th><th>Descuento</th><th>Descuento maximo</th></tr>";
                row += "</thead>";
                row += "<tbody>";

                $.each(item.ArticuloBodega, function (j, articulo) {
                    row += GenerateRow(articulo);
                });

                row += "</tbody>";
                row += "<tfood>";
                row += "<tr><th>Total</th><th>C$ " + item.TotalPCompra + "</th><th>C$ " + item.TotalPVenta + "</th><th>% " + item.TotalDescuento + "</th><th>% "+item.TotalDescuentoMaximo+"</th></tr>";
                row += "</tfood>";

                row += "</table>";
                row += "</td>";
            }

            row += "</tr>";
        });

        $("#result").html(row);
    });

    function GenerateRow(articulo) {

        var row = "<tr><td> " + articulo.Articulo + "</td><td>C$ " + articulo.PCompra + "</td><td>C$ " + articulo.PVenta + "</td><td>% " + articulo.Descuento + "</td><td>% " + articulo.DescuentoMaximo + "</td></tr>";
        return row;
    }
});