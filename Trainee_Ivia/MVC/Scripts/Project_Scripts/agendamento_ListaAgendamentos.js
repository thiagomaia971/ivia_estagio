$(document).ready(function () {
    var protocolo;
    var data;
    $("[data-row-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-row-action"));

        switch ($("#EventCommand").val()) {
           
            case "cancelar":
                
                protocolo = $(this).attr("data-row-protocol");
                data = $(this).attr("data-row-date");

                $("#modal-confirmation").modal('show');

                break;
            case "reinserir":

                break;

                default:
                    $("form").submit();
        }


    });
    $("[data-confirmation]").on("click", function (e) {

        $('#CancelAgendamento_Paciente_Protocolo').val(protocolo);
        $('#CancelAgendamento_DiaDoAgendamento').val(data);

        $("#modal-confirmation").modal('hide');

        $("form").submit();
    });
    

});