$(function () {
    var detalleCompra = [];
    var compra = {};
    var articulos = [];
    var today = new Date();
    var esEdicion = false;

    var anio = today.getFullYear();
    var month = today.getMonth();
    var day = today.getDay();
    $("#FechaCompra").val(anio + "/" + month + "/" + day);
    GetAllArticulos();
    GetAllBodega();
    GetAllMedida();
    GetAllMarca();
    GetAllColor();
    GetAllTalla();
    GetAllProveedores();
    function GetAllArticulos() {
        HttpClient.Get("Articulo.aspx/GetAllArticulos").then((response) => {
            articulos = response.d;
            var cmbArticulo = $("#IdArticulo");
            $(cmbArticulo).empty();
            $(cmbArticulo).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                if (item.Estado) {
                    $(cmbArticulo).append("<option value=" + item.IdArticulo + ">" + item.NombreArticulo + "</option>");
                }
            });
            
            $(cmbArticulo).selectpicker();
        });
    }

    function GetAllProveedores() {
        HttpClient.Get("Compras.aspx/GetAllProveedores").then((response) => {
            var cmbProveedor = $("#IdProveedor");
            $(cmbProveedor).empty();
            $(cmbProveedor).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                    $(cmbProveedor).append("<option value=" + item.IdProveedor + ">" + item.Nombre + "</option>");
            });
            $(cmbProveedor).selectpicker();
        });
    }
    function GetAllBodega() {
        HttpClient.Get("Bodega.aspx/GetAllBodega").then((response) => {
            var cmb = $("#IdBodega");
            $(cmb).empty();
            $(cmb).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                
                $(cmb).append("<option value=" + item.IdBodega + ">" + item.Nombre + "</option>");
                
            });
            $(cmb).selectpicker();
        });
    }
    function GetAllMedida() {
        HttpClient.Get("Medida.aspx/GetAllMedidas").then((response) => {
            var cmb = $("#IdMedida");
            $(cmb).empty();
            $(cmb).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                    $(cmb).append("<option value=" + item.IdMedida + ">" + item.NombreMedida + "</option>");
                
            });
            $(cmb).selectpicker();
        });
    }
    function GetAllMarca() {
        HttpClient.Get("Marca.aspx/GetAllMarcas").then((response) => {
            var cmb = $("#IdMarca");
            $(cmb).empty();
            $(cmb).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                if (item.Estado) {
                    $(cmb).append("<option value=" + item.IdMarca + ">" + item.NombreMarca + "</option>");
                }
            });
            $(cmb).selectpicker();
        });
    }
    function GetAllColor() {
        HttpClient.Get("Color.aspx/GetAllColor").then((response) => {
            var cmb = $("#IdColor");
            $(cmb).empty();
            $(cmb).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                if (item.Estado) {
                    $(cmb).append("<option value=" + item.IdColor + ">" + item.NombreColor + "</option>");
                }
            });
            $(cmb).selectpicker();
        });
    }
    function GetAllTalla() {
        HttpClient.Get("Talla.aspx/GetAllTallas").then((response) => {
            var cmb = $("#IdTalla");
            $(cmb).empty();
            $(cmb).append("<option value=''>[Seleccione una opción]</option>");
            $.each(response.d, function (i, item) {
                if (item.Estado) {
                    $(cmb).append("<option value=" + item.IdTalla + ">" + item.NombreTalla + "</option>");
                }
            });
            $(cmb).selectpicker();
        });
    }

    $(document).on("keypress", "input[data-only-number]", function () {
    });
    $(document).on("keyup", "input[data-calculate]", function () {

        var cantidad = +$("#Cantidad").val();
        var precio = +$("#Precio").val();
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
    function CalculateTotalCompra() {

        var subtotal = 0;
        $.each(detalleCompra, function (i, item) {
            subtotal += +item.SubTotalArticulo;
        });

        $("#SubTotalCompra").val(subtotal);
        var iva = +$("#Iva").val();
        var ivaplus = subtotal * (iva / 100);
        $("#TotalCompra").val(subtotal + ivaplus);

    }

    $(document).on("click", "button[data-comprar]", function () {
        var controles = $("input[data-detalle], select[data-detalle]");
        var valido = ValidarForm(controles);
        if (!valido) {
            toastr.error("Debe completar todos los campos para agregar el árticulo.");
            return;
        }

        $("span").prop("hidden", true);
        var detalle = {};

        $.each(controles, function (i, item) {
            detalle[$(item).attr("id")] = $(item).val();
            $(item).val("");
        });
        detalle.Descuento = !detalle.Descuento ? 0 : detalle.Descuento;
        var articulo = detalleCompra.filter((det) => { return det.IdArticulo === detalle.IdArticulo });
        if (esEdicion) {
            if (articulo.length && articulo.length > 1) {
                toastr.error('El árticulo ya ha sido agregado al detalle.');
                RefreshControl();
                return;
            }
        }
        else {
            if (articulo.length) {
                toastr.error('El árticulo ya ha sido agregado al detalle.');
                RefreshControl();
                return;
            }
        }
        
        if (+detalle.IdDetalle) {
            detalleCompra = detalleCompra.filter(function (de) { return de.IdDetalle !== +detalle.IdDetalle; });
            detalle.IdDetalle = detalleCompra.length + 1;
        }
        else {
            detalle.IdDetalle = detalleCompra.length + 1;
        }
        detalleCompra.push(detalle);

        toastr.success('Árticulo agregado exitosamente.');
        LlenarDetalleCompra();
        CalculateTotalCompra();
        esEdicion = false;
        RefreshControl();
    });

    function RefreshControl() {
        $("#IdArticulo").selectpicker("refresh");
        $("#IdBodega").selectpicker("refresh");
        $("#IdMedida").selectpicker("refresh");
        $("#IdMarca").selectpicker("refresh");
        $("#IdColor").selectpicker("refresh");
        $("#IdTalla").selectpicker("refresh");
    }
    $(document).on("click", "button[data-save-comprar]", function () {

        var controlCompra = $("input[data-compra], select[data-compra]");
        var compravalida = ValidarForm(controlCompra);
        if (!compravalida) {
            toastr.error('Debe completar los datos requeridos para finalizar la compra.');
            return;
        }

        if (!detalleCompra.length) {
            toastr.error('Debe agregar articulos a la compra');
            return;
        }

        Comprar();

    });

    function LlenarDetalleCompra() {
        var row = "";
        $.each(detalleCompra, function (i, item) {
            var articulo = articulos.find((art) => art.IdArticulo === + item.IdArticulo);
            row += "<tr><td>" + articulo.NombreArticulo + "</td><td>" + item.Cantidad + "</td><td>C$ " + item.Precio + "</td><td>% " + item.Descuento + "</td><td>C$ " + item.SubTotalArticulo + "</td><td><button type='button' class='btn btn-primary' data-accion-editar='" + item.IdDetalle + "'>" + Utilidades.IconEdit() + "</button> &nbsp; <button type='button' class='btn btn-danger' data-accion-eliminar='" + item.IdDetalle + "'>" + Utilidades.IconTrash() + "</button></td> </tr>";
        });
        $("#result").html(row);
    }
    

    function Comprar() {

        var CompraArticulos = {};
        compra.Iva = $("#Iva").val();
        compra.SubTotalCompra = $("#SubTotalCompra").val();
        compra.TotalCompra = $("#TotalCompra").val();
        compra.IdProveedor = $("#IdProveedor").val();

        CompraArticulos.Compra = compra;
        CompraArticulos.DetalleCompra = detalleCompra;
        $("#IdProveedor").selectpicker("refresh");
        HttpClient.Post("Compras.aspx/Comprar", JSON.stringify({ compraRequest : CompraArticulos})).then((response) => {

            toastr.success('Compra realizada exitosamente.');
            setTimeout(reload, 3000);
        });

    }

    function reload() {
        window.location.href = "/Pages/ListadoCompras";
    }

    $(document).on("click", "button[data-accion-editar]", function () {
        var IdDetalle = +$(this).data("accionEditar");
        var detalle = detalleCompra.find((det) => { return +det.IdDetalle === IdDetalle; });
        var controles = $("input[data-detalle], select[data-detalle]");
        esEdicion = true;
        $.each(controles, function (i, item) {
            $(item).val(detalle[$(item).attr("Id")]);
        });
        RefreshControl();
    });
    $(document).on("click", "button[data-accion-eliminar]", function () {
        var IdDetalle = +$(this).data("accionEliminar");
        detalleCompra = detalleCompra.filter((det) => { return det.IdDetalle !== IdDetalle; });
        LlenarDetalleCompra();
        CalculateTotalCompra();
        toastr.success('Árticulo eliminado exitosamente.');

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
});