$(document).ready(function () {
    
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-pdsa-action"));

        if ($("#EventCommand").val() == "salvar") {
           $("#modal").modal('hide');
        }
      
        $("form").submit();

    });
});