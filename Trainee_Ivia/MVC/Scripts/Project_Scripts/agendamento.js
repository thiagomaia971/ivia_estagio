$(document).ready(function () {
    $("#novo-agendamento-container").hide();
    
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-pdsa-action"));
        
        
        switch ($("#EventCommand").val()) {
            
            case "novoAgendamento":
                novo_agendamento();
                break;

            
            default:
                $("#form0").submit();
                break;
        }

      

    });

    function novo_agendamento() {
        var now = new Date();

        if ($("#SearchEntity_DiaDoAgendamento").val() == "") {

            $("#textoModal").text("Preencha a data!");
            $("#modal-aviso").modal('show');

        } else if ($("#NameOrProtocol").val() == "") {

            $("#textoModal").text("Preencha um nome ou protocolo!");
            $("#modal-aviso").modal('show');

        }else {
            var dataAgendamento = new Date($("#SearchEntity_DiaDoAgendamento").val());
            dataAgendamento.setDate(dataAgendamento.getDate() + 1);

            if (now < dataAgendamento) {
                $("#form0").submit();
            } else {                
                $("#textoModal").text("Não insira uma data passada!");
                $("#modal-aviso").modal('show');
            }
        }
    }

});