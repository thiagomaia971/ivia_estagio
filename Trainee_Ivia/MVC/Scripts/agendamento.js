$(document).ready(function () {
    
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-pdsa-action"));

        if ($("#EventCommand").val() == "salvar") {
            if ($("#isValid").val()) {
                $("modal-errors").show();
            }
              //$("#modal").modal('hide');
        }
      
        $("form").submit();

    });

    $("[data-modal-service]").on("click", function (e) {
        //e.preventDefault();
        $("#EventCommand").val($(this).attr("data-modal-service"));

        if ($("#EventCommand").val() == "opcao") {
            $("#NovoAgendamento_Paciente_Protocolo").val($(this).find("td.protocolo").text());
        }

        
        var dataModal = $(this).attr("data-modal-service");
        switch (dataModal) {
            case "voltar":
            case "opcao":
                $("#modal").modal('show');
                $("#modal-reagendamento").hide();
                $("#modal-opcaoAgendamento").show();
                break;

            case "reagendamento":
                $("#modal-opcaoAgendamento").hide();
                $("#NovoAgendamento_DiaDoAgendamento").val("");
                $("#NovoAgendamento_TipoDeTratamento").val(0);
                $("#modal-reagendamento").show();
                break;
        }

    });
   
});