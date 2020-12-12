$(function () {

    GetCategorias();
    function GetCategorias() {
        HttpClient.Get("Categoria.aspx/GetCategorias").then((response) => {
            var row = "";
            $.each(response.d, function (i, item) {
                var IndEstado = item.Estado ? Utilidades.IconCheck() : Utilidades.IconDashCircle();
                row += "<tr><td>" + item.NombreCategoria + "</td><td>" + IndEstado + "</td><td><button type='button' class='btn btn-primary' data-accion-editar='" + item.IdCategoria + "'>" + Utilidades.IconEdit() + "</button></td> </tr>";
            });
            $("#result").html(row);
        });
    }

    $(document).on("click", "button[data-accion-editar]", function () {
        var params = "{IdCategoria : '" + $(this).data("accionEditar") + "'}";
        HttpClient.GetBy("Categoria.aspx/ObtenerCategoria", params).then((response) => {
            var categoria = response.d;

            CleanForm();
            $("#modal-categoria").modal("show");
            $("#titulo").html("Actualice los datos de la categoria");
            $("#IdCategoria").val(categoria.IdCategoria);
            $("#Nombre").val(categoria.NombreCategoria);
            $("#Estado").prop("checked", categoria.Estado);
        });

    });

    $(document).on("click", "button[data-accion-crear]", function () {
        CleanForm();
        $("#titulo").html("Crea una nueva categoria");
        $("#modal-categoria").modal("show");
    });

    $(document).on("click", "button[data-accion-guardar]", function () {
        var valido = ValidarForm();
        if (!valido) return;

        var params = {
            IdCategoria: $("#IdCategoria").val() ? $("#IdCategoria").val() : 0 ,
            NombreCategoria: $("#Nombre").val(),
            Estado: $("#Estado")[0].checked
        };

        var endPoint = params.IdCategoria === 0 ? "CreateCategoria" : "UpdateCategoria";
        HttpClient.Post("Categoria.aspx/" + endPoint, JSON.stringify({ categoria: params })).then((response) => {
            if (response.d.SuccesFull) {
                toastr.success(response.d.Message);
            }
            else {
                toastr.error(response.d.Message);
            }
            $("#modal-categoria").modal("hide");
            GetCategorias();
        });

    });

    function CleanForm() {
        $("#IdCategoria").val("");
        $("#Nombre").val("");
        $("#Estado").prop("checked", false);
    }

    function ValidarForm() {
        var valido = true;
        var elementsForm = $("input, textarea, select");
        $.each(elementsForm, function (i, element) {

            if ($(element).prop("required")) {
                var value = $(element).val();
                if (!value.trim()) {
                    $("#span-" + $(element).prop("id")).html("El campo " + $(element).prop("id") + " es requerido");
                    $("#span-" + $(element).prop("id")).removeAttr("hidden");
                    valido = false;
                }
            }
        });

        return valido;
    }
});