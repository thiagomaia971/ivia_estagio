$(document).ready(function () {
    var protocolo;
    var data;
    var statusAgendamento;

    $("[data-row-action]").on("click", function (e) {
        e.preventDefault();

        var EventCommand = $("#EventCommand").val($(this).attr("data-row-action")).val();

        switch (EventCommand) {
            case "reagendar":
                $("#modal-cancelar-agendamento").hide();
                $("#modal-reagendar-agendamento").show();

                protocolo = $(this).attr("data-row-protocol");
                data = $(this).attr("data-row-date");
                statusAgendamento = 1;

                $("#modal-confirmation").modal('show');
                break;

            case "cancelar":
                $("#modal-reagendar-agendamento").hide();
                $("#modal-cancelar-agendamento").show();

                protocolo = $(this).attr("data-row-protocol");
                data = $(this).attr("data-row-date");
                statusAgendamento = 2;

                $("#modal-confirmation").modal('show');

                break;

            case "realizado":
                break;

                default:
                    $("form").submit();
                    break;
        }


    });
    $("[data-confirmation]").on("click", function (e) {
        $("#statusAtualizarAgendamento").val(statusAgendamento);
        $('#AtualizarAgendamento_Paciente_Protocolo').val(protocolo);
        $('#AtualizarAgendamento_DiaDoAgendamento').val(data);
        

        $("#modal-confirmation").modal('hide');

        $("form").submit();
    });
    

});