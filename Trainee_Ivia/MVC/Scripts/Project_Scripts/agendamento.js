$(document).ready(function () {
    
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-pdsa-action"));

        switch ($("#EventCommand").val()) {
            case "salvar":
                $("#modal").modal('hide');
                break;
            case "cancel":
                cancel_button($(this).attr("data-row-protocol"),$(this).attr("data-row-date"));
                break;

        }
      
        $("form").submit();

    });

    function cancel_button(protocolo, data) {
        alert(protocolo + " " + data);
        $('#CancelAgendamento_Paciente_Protocolo').val(protocolo);
        $('#CancelAgendamento_DiaDoAgendamentos').val(data);
    }
});