$(function () {

    GetTipoMoneda();
    function GetTipoMoneda() {
        HttpClient.Get("TipoMoneda.aspx/GetAllTipoMoneda").then((response) => {
            var row = "";
            $.each(response.d, function (i, item) {
                var IndEstado = item.Activo ? Utilidades.IconCheck() : Utilidades.IconDashCircle();
                row += "<tr><td>" + item.TMoneda + "</td><td>" + item.TasaCambio + "</td><td>" + IndEstado + "</td><td><button type='button' class='btn btn-primary' data-accion-editar='" + item.IdTipoMoneda + "'>" + Utilidades.IconEdit() + "</button></td> </tr>";
            });
            $("#result").html(row);
        });
    }

    $(document).on("click", "button[data-accion-editar]", function () {
        var params = "{IdTipoMoneda : '" + $(this).data("accionEditar") + "'}";
        HttpClient.GetBy("TipoMoneda.aspx/GetTipoMonedaById", params).then((response) => {
            var moneda = response.d;

            CleanForm();
            $("#modal-tipo-moneda").modal("show");
            $("#titulo").html("Actualice los datos del tipo de moneda");
            $("#IdTipoMoneda").val(moneda.IdTipoMoneda);
            $("#TMoneda").val(moneda.TMoneda);
            $("#TasaCambio").val(moneda.TasaCambio);
            $("#Activo").prop("checked", moneda.Activo);
        });

    });

    $(document).on("click", "button[data-accion-crear]", function () {
        CleanForm();
        $("#titulo").html("Crea un nuevo tipo de moneda");
        $("#modal-tipo-moneda").modal("show");
    });

    $(document).on("click", "button[data-accion-guardar]", function () {
        var valido = ValidarForm();
        if (!valido) return;

        var params = {
            IdTipoMoneda: $("#IdTipoMoneda").val() ? $("#IdTipoMoneda").val() : 0,
            TMoneda: $("#TMoneda").val(),
            TasaCambio: $("#TasaCambio").val(),
            Activo: $("#Activo")[0].checked
        };

        var endPoint = params.IdTipoMoneda === 0 ? "CreateTipoMoneda" : "UpdateTipoMoneda";
        HttpClient.Post("TipoMoneda.aspx/" + endPoint, JSON.stringify({ tIPOMONEDA: params })).then((response) => {
            if (response.d.SuccesFull) {
                toastr.success(response.d.Message);
            }
            else {
                toastr.error(response.d.Message);
            }
            $("#modal-tipo-moneda").modal("hide");
            GetTipoMoneda();
        });

    });

    function CleanForm() {
        $("#IdTipoMoneda").val("");
        $("#TMoneda").val("");
        $("#TasaCambio").val("");
        $("#Activo").prop("checked", false);
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