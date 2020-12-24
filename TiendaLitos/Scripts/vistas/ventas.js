$(function () {
    var tasaCambio = 0;
    var today = new Date();
    var anio = today.getFullYear();
    var month = today.getMonth();
    var day = today.getDay();
    $("#FechaVenta").val(anio + "/" + month + "/" + day);
    var detalleVenta = [];
    var venta = {};
    var articulos = [];
    var esEdicion = false;
    GetAllArticulos();
    GetAllTipoMoneda();
    function GetAllArticulos() {
        HttpClient.Get("ArticuloBodega.aspx/GetAllArticulosBodega").then((response) => {
            articulos = response.d;
            var cmbArticulo = $("#IdArticulo");
            $(cmbArticulo).empty();
            $(cmbArticulo).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                if (item.Estado) {

                    $(cmbArticulo).append("<option value=" + item.IdArticuloBodega + ">" + item.Articulo + ", <b>Color</b> : " + item.Color + " Marca : " + item.Marca + " Talla : " + item.Talla+" Precio : " + item.PrecioPorUnida+"</option > ");
                }
            });

            $(cmbArticulo).selectpicker();
        });
    }
    function GetAllTipoMoneda() {
        HttpClient.Get("TipoMoneda.aspx/GetAllTipoMoneda").then((response) => {
            var cmb = $("#IdTipoMoneda");
            $(cmb).empty();
            $(cmb).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                if (item.Activo) {
                    $(cmb).append("<option value=" + item.IdTipoMoneda + ">" + item.TMoneda + "</option>");
                }
            });

            $(cmb).selectpicker();
        });
    }
    $(document).on("change", "#IdArticulo", function () {
        var Id = +this.value;
        var articulo = articulos.find((r) => { return r.IdArticuloBodega === Id; });
        var controles = $("input[data-inf]");
        $.each(controles, function (i, item) {
            if (!articulo) {
                $(item).val("");
            }
            else {
                $(item).val(articulo[$(item).attr("id")]);
            }
        });
    });
    $(document).on("change", "#IdTipoMoneda", function () {
        var params = "{IdTipoMoneda : '" + (+this.value) + "'}";
        HttpClient.GetBy("TipoMoneda.aspx/GetTipoMonedaById", params).then((response) => {
            var data = response.d;
            tasaCambio = data.TasaCambio;
        });

    });
    $(document).on("click", "button[data-vender]", function () {
        var controles = $("input[data-detalle], select[data-detalle]");
        var valido = ValidarForm(controles);
        if (!valido) {
            toastr.error("Debe completar todos los campos para agregar el articulo.");
            return;
        }

        var pago = +$("#Pago").val();
        var subtotal = +$("#SubTotalArticulo").val();
        if (pago < subtotal) {
            toastr.error("El monto de pago debe ser mayor al valor a pagar.");
            return;
        }

        $("span").prop("hidden", true);
        var detalle = {};

        $.each(controles, function (i, item) {
            detalle[$(item).attr("id")] = $(item).val();
            $(item).val("");
        });
        detalle.Descuento = !detalle.Descuento ? 0 : detalle.Descuento;
        var articulo = detalleVenta.filter((det) => { return det.IdArticulo === detalle.IdArticulo });
        if (esEdicion) {
            if (articulo.length && articulo.length > 1) {
                toastr.error('El articulo ya ha sido agregado al detalle.');
                $("#IdArticulo").selectpicker("refresh").change();
                return;
            }
        }
        else {
            if (articulo.length) {
                toastr.error('El articulo ya ha sido agregado al detalle.');
                $("#IdArticulo").selectpicker("refresh").change();
                return;
            }
        }

        if (+detalle.IdDetalle) {
            detalleVenta = detalleVenta.filter(function (de) { return de.IdDetalle !== +detalle.IdDetalle; });
            detalle.IdDetalle = detalleVenta.length + 1;
        }
        else {
            detalle.IdDetalle = detalleVenta.length + 1;
        }
        detalleVenta.push(detalle);

        toastr.success('Articulo agregado exitosamente.');
        LlenarDetalleVenta();
        CalculateTotalVenta();
        $("#IdArticulo").selectpicker("refresh").change();
        esEdicion = false;
    });

    $(document).on("click", "button[data-accion-editar]", function () {
        var IdDetalle = +$(this).data("accionEditar");
        var detalle = detalleVenta.find((det) => { return +det.IdDetalle === IdDetalle; });
        var controles = $("input[data-detalle], select[data-detalle]");
        esEdicion = true;
        $.each(controles, function (i, item) {
            $(item).val(detalle[$(item).attr("Id")]);
        });
        $("#IdArticulo").selectpicker("refresh").change();
    });

    $(document).on("click", "button[data-accion-eliminar]", function () {
        var IdDetalle = +$(this).data("accionEliminar");
        detalleVenta = detalleVenta.filter((det) => { return det.IdDetalle !== IdDetalle; });
        LlenarDetalleVenta();
        CalculateTotalVenta();
        toastr.success('Articulo eliminado exitosamente.');

    });
    function ValidarForm(controles) {
        var valido = true;
        $.each(controles, function (i, element) {

            if ($(element).prop("required")) {
                var value = $(element).val();
                if (!value || !value.trim()) {
                    $("#span-" + $(element).prop("id")).html($(element).data("required"));
                    $("#span-" + $(element).prop("id")).removeAttr("hidden");
                    valido = false;
                }
                else {
                    $("#span-" + $(element).prop("id")).attr("hidden", true);
                }
            }
        });

        return valido;
    }

    $(document).on("keyup", "input[data-calculate]", function () {

        var cantidad = +$("#Cantidad").val();
        var precio = +$("#PrecioVenta").val();
        var descuento = +$("#Descuento").val();
        var subtotal = +$("#SubTotalArticulo").val();
        if (!cantidad || !precio) $("#SubTotalArticulo").val(0);

        var des = descuento / 100;
        var sub = cantidad * precio;

        if (des) {
            des = sub * des;
            sub = sub - des;
        }

        $("#SubTotalArticulo").val(sub);

    });

    $(document).on("change", "input[data-calculat-cambio]", function () {

        var pago = +this.value;
        var subtotal = +$("#SubTotalArticulo").val();
        if (pago < subtotal) {
            toastr.error("El monto de pago debe ser mayor al valor a pagar.");
            return;
        }
        var cambio = pago - subtotal;
        $("#Cambio").val(cambio);

    });

    function CalculateTotalVenta() {

        var subtotal = 0;
        $.each(detalleVenta, function (i, item) {
            subtotal += +item.SubTotalArticulo;
        });

        $("#SubTotalVenta").val(subtotal);
        var iva = +$("#Iva").val();
        var ivaplus = subtotal * (iva / 100);
        $("#TotalVenta").val(subtotal + ivaplus);

    }

    $(document).on("click", "button[data-save-vender]", function () {

        var controlVenta = $("input[data-venta], select[data-venta]");
        var ventavalida = ValidarForm(controlVenta);
        if (!ventavalida) {
            toastr.error('Debe completar los datos requeridos para finalizar la venta.');
            return;
        }

        if (!detalleVenta.length) {
            toastr.error('Debe agregar articulos a la venta');
            return;
        }

        Vender();

    });

    function Vender() {

        var VentaArticulos = {};
        venta.Iva = $("#Iva").val();
        venta.SubTotalVenta = $("#SubTotalVenta").val();
        venta.TotalVenta = $("#TotalVenta").val();
        venta.Cliente = $("#Cliente").val();
        venta.IdTipoMoneda = $("#IdTipoMoneda").val();
        VentaArticulos.Venta = venta;
        VentaArticulos.DetalleVenta = detalleVenta;

        HttpClient.Post("Ventas.aspx/Vender", JSON.stringify({ ventaRequest: VentaArticulos })).then((response) => {

            toastr.success('Venta realizada exitosamente.');
            setTimeout(reload, 3000);
        });

    }

    function reload() {
        window.location.href = "/Pages/ListadoVentas";
    }
    function LlenarDetalleVenta() {
        var row = "";
        $.each(detalleVenta, function (i, item) {
            var articulo = articulos.find((art) => art.IdArticuloBodega === + item.IdArticulo);
            row += "<tr><td>" + articulo.Articulo + "</td><td>" + item.Cantidad + "</td><td>C$ " + item.PrecioVenta + "</td><td>% " + item.Descuento + "</td><td>C$ " + item.SubTotalArticulo + "</td><td>C$ " + item.SubTotalArticulo * (tasaCambio === 0 ? 1 : tasaCambio) + "</td><td><button type='button' class='btn btn-primary' data-accion-editar='" + item.IdDetalle + "'>" + Utilidades.IconEdit() + "</button> &nbsp; <button type='button' class='btn btn-danger' data-accion-eliminar='" + item.IdDetalle + "'>" + Utilidades.IconTrash() + "</button></td> </tr>";
        });
        $("#result").html(row);
    }
});