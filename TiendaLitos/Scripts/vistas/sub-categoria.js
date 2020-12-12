$(function () {

    GetSubCategorias();
    function GetCategorias() {
        return new Promise((resolve, reject) => {

            resolve(HttpClient.Get("Categoria.aspx/GetCategorias").then((response) => {
                    var combo = $("#Categoria");
                    $(combo).empty();
                    $(combo).append("<option value=''>[Seleccione una opción]</option>");
                $.each(response.d, function (i, item) {
                    if (item.Estado) {
                        $(combo).append("<option value=" + item.IdCategoria + ">" + item.NombreCategoria + "</option>");
                    }
                    });
            }));
        });
    }

    function GetSubCategorias() {
        HttpClient.Get("SubCategoria.aspx/GetAllSubCategorias").then((response) => {
            var row = "";
            $.each(response.d, function (i, item) {
                var IndEstado = item.Estado ? Utilidades.IconCheck() : Utilidades.IconDashCircle();
                row += "<tr><td>" + item.NombreCategoria + "</td><td>" + item.Descripcion + "</td><td>" + IndEstado + "</td><td><button type='button' class='btn btn-primary' data-accion-editar='" + item.IdSubCategoria + "'>" + Utilidades.IconEdit() + "</button></td> </tr>";
            });
            $("#result").html(row);
        });
    }

    $(document).on("click", "button[data-accion-editar]", function () {
        var params = { IdSubCategoria: $(this).data("accionEditar") };
        HttpClient.GetBy("SubCategoria.aspx/ObtenerSubCategoria", JSON.stringify(params)).then((response) => {
            var subcategoria = response.d;
            CleanForm();
            GetCategorias().then((res) => {
                $("#modal-sub-categoria").modal("show");
                $("#titulo").html("Actualice los datos de la sub categoria");
                $("#IdSubCategoria").val(subcategoria.IdSubCategoria);
                $("#Descripcion").val(subcategoria.Descripción);
                $("#Categoria").val(subcategoria.IdCategoria);
                $("#Estado").prop("checked", subcategoria.Estado);
            });
            
        });

    });

    $(document).on("click", "button[data-accion-crear]", function () {
        CleanForm();
        GetCategorias().then((r) => {
            $("#titulo").html("Crea una nueva sub categoria");
            $("#modal-sub-categoria").modal("show");
        });
        
    });

    $(document).on("click", "button[data-accion-guardar]", function () {
        var valido = ValidarForm();
        if (!valido) return;

        var params = {
            IdSubCategoria: $("#IdSubCategoria").val() ? $("#IdSubCategoria").val() : 0,
            IdCategoria: $("#Categoria").val(),
            Descripción: $("#Descripcion").val(),
            Estado: $("#Estado")[0].checked
        };

        var endPoint = params.IdSubCategoria === 0 ? "CreateSubCategoria" : "UpdateSubCategoria";
        HttpClient.Post("SubCategoria.aspx/" + endPoint, JSON.stringify({ subCategoria: params })).then((response) => {
            $("#modal-sub-categoria").modal("hide");
            GetSubCategorias();
        });

    });

    function CleanForm() {
        $("#IdSubCategoria").val("");
        $("#Categoria").val("");
        $("#Descripcion").val("");
        $("#Estado").prop("checked", false);
    }

    function ValidarForm() {
        var valido = true;
        var elementsForm = $("input, textarea, select");
        $.each(elementsForm, function (i, element) {

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