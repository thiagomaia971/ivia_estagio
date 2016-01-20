$(document).ready(function () {

    $("[data-row-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-row-action"));

        switch ($("#EventCommand").val()) {
           
            case "cancelar":
                var protocolo = $(this).attr("data-row-protocol");
                var data = $(this).attr("data-row-date");

                alert(protocolo + " " + data);
                $('#CancelAgendamento_Paciente_Protocolo').val(protocolo);
                $('#CancelAgendamento_DiaDoAgendamentos').val(data);
                //alert($(this).attr("data-row-agendamento"))
                break;

        }

        $("form").submit();

    });

});