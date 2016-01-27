$(document).ready(function () {
    $("#novo-agendamento-container").hide();
    
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-pdsa-action"));
        
        
        switch ($("#EventCommand").val()) {
            
            case "novoAgendamento":
                //novo_agendamento();
                break;

            case "listar":
                $("#novo-agendamento-container").hide();
                $("#list-container").show();
                break;

            case "imprimir":

                break;
            default:
                break;
        }

        $("#form0").submit();
      

    });

    function novo_agendamento() {
        var now = new Date();
        var day = now.getDate();
        var month = now.getMonth() + 1;
        var year = now.getFullYear();

        //alert(day + "/" + month + "/" + year);

        if ($("#SearchEntity_DiaDoAgendamento").val() == "" || $("#NameOrProtocol").val() == "") {
            //modal data ou nome ou protocolo invalido.
        } else {
            var dateAgendamento = new Date($("#SearchEntity_DiaDoAgendamento").val());
            
            //if (dateAgendamento.getFullYear <= year && (dateAgendamento.getMonth + 1) <= month ) {
            //    //modal
            //    alert("a");
            //}
            ////&& dateAgendamento.getDate() <= day

            if (dateAgendamento.getDate < day && (dateAgendamento.getMonth + 1) < month && dateAgendamento.getFullYear < year) {
                alert("a");                   
            }
        }
    }

});