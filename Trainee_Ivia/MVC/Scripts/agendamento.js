$(document).ready(function () {
    
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-pdsa-action"));
        $("form").submit();
    });

    $("[data-modal-service]").on("click", function (e) {
        $("#EventCommand").val($(this).attr("data-modal-service"));

        if ($("#EventCommand").val() == "opcao") {
            alert("opcao");
            $("#NovoAgendamento_Paciente_Protocolo").val($(this).find("td.protocolo").text());
        }

        
        var dataModal = $(this).attr("data-modal-service");
        switch (dataModal) {
            case "opcao":
                $("#modal").modal('show');
                $("#modal-opcaoAgendamento").show();
                $("#modal-reagendamento").hide();
                break;

            case "reagendamento":
                $("#modal-opcaoAgendamento").hide();
                $("#modal-reagendamento").show();
                break;

            case "voltar":
                $("#modal-opcaoAgendamento").show();
                $("#modal-reagendamento").hide();
                break;
        }

        //$("form").submit();
    });
   
});