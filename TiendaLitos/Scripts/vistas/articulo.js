$(function () {

    GetAllArticulos();
    function GetAllArticulos() {
        HttpClient.Get("Articulo.aspx/GetAllArticulos").then((response) => {
            var row = "";
            $.each(response.d, function (i, item) {
                var IndEstado = item.Estado ? Utilidades.IconCheck() : Utilidades.IconDashCircle();
                row += "<tr><td>" + item.NombreArticulo + "</td><td>" + item.NombreSubCategoria + "</td><td>" + IndEstado + "</td><td><button type='button' class='btn btn-primary' data-accion-editar='" + item.IdArticulo + "'>" + Utilidades.IconEdit() + "</button></td> </tr>";
            });
            $("#result").html(row);
        });
    }
    function GeSubCategorias() {
        return new Promise((resolve, reject) => {

            resolve(HttpClient.Get("SubCategoria.aspx/GetAllSubCategorias").then((response) => {
                var combo = $("#Subcategoria");
                    $(combo).empty();
                    $(combo).append("<option value=''>[Seleccione una opción]</option>");
                $.each(response.d, function (i, item) {
                    if (item.Estado) {
                        $(combo).append("<option value=" + item.IdSubCategoria + ">" + item.Descripcion + "</option>");
                    }
                    });
            }));
        });
    }

    function GetControles() {
        return {
            IdArticulo : $("#IdArticulo"),
            Nombre :  $("#Nombre"),
            Descripcion : $("#Descripcion"),
            IdSubCategoria: $("#Subcategoria"),
            Estado : $("#Estado")
        };
    }
    $(document).on("click", "button[data-accion-editar]", function () {
        var params = { IdArticulo: $(this).data("accionEditar") };
        HttpClient.GetBy("Articulo.aspx/GetArticuloById", JSON.stringify(params)).then((response) => {
            var articulo = response.d;
            CleanForm();
            GeSubCategorias().then((res) => {
                $("#modal-articulo").modal("show");
                $("#titulo").html("Actualice los datos del articulo");
                var controles = GetControles();

                controles.IdArticulo.val(articulo.IdArticulo);
                controles.Nombre.val(articulo.NombreArticulo);
                controles.Descripcion.val(articulo.Descripción);
                controles.IdSubCategoria.val(articulo.IdSubCategoria);
                controles.Estado.prop("checked", articulo.Estado);
            });
            
        });

    });

    $(document).on("click", "button[data-accion-crear]", function () {
        CleanForm();
        GeSubCategorias().then((r) => {
            $("#titulo").html("Crea un nuevo articulo");
            $("#modal-articulo").modal("show");
        });
        
    });

    $(document).on("click", "button[data-accion-guardar]", function () {
        var valido = ValidarForm();
        if (!valido) return;

        var params = {
            IdArticulo: $("#IdArticulo").val() ? $("#IdArticulo").val() : 0,
            NombreArticulo: $("#Nombre").val(),
            Descripción: $("#Descripcion").val(),
            IdSubCategoria : $("#Subcategoria").val(),
            Estado: $("#Estado")[0].checked
        };

        var endPoint = params.IdArticulo === 0 ? "CreateArticulo" : "UpdateArticulo";
        HttpClient.Post("Articulo.aspx/" + endPoint, JSON.stringify({ articulo: params })).then((response) => {
            if (response.d.SuccesFull) {
                toastr.success(response.d.Message);
            }
            else {
                toastr.error(response.d.Message);
            }
            $("#modal-articulo").modal("hide");
            GetAllArticulos();
        });

    });

    function CleanForm() {
        var controles = GetControles();
        controles.IdArticulo.val("");
        controles.Nombre.val("");
        controles.Descripcion.val("");
        controles.IdSubCategoria.val("");
        controles.Estado.prop("checked", false);
    }

    function ValidarForm() {
        var valido = true;
        $.each(GetControles(), function (i, element) {

            if ($(element).prop("required")) {
                var value = $(element).val();
                if (!value.trim()) {
                    $("#span-" + $(element).prop("id")).html($(element).data("required"));
                    $("#span-" + $(element).prop("id")).removeAttr("hidden");
                    valido = false;
                }
            }
        });

        return valido;
    }
});