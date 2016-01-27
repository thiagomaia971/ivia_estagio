$(document).ready(function () {

    $("#NovoAgendamento_DiaDoAgendamento").val($("#SearchEntity_DiaDoAgendamento").val());

    $("#SearchEntity_DiaDoAgendamento").change(function () {
        $("#NovoAgendamento_DiaDoAgendamento").val($("#SearchEntity_DiaDoAgendamento").val());
    });

    $("#NovoAgendamento_DiaDoAgendamento").change(function () {
        $("#SearchEntity_DiaDoAgendamento").val($("#NovoAgendamento_DiaDoAgendamento").val());
    });


    $("[data-na-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-na-action"));

        //if($(this).attr("data-na-action")

        $("#novoAgendamentoForm").submit();
    });
});


