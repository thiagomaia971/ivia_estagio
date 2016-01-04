$(document).ready(function () {
    $(document).ready(function () {

        $("[data-pdsa-action]").on("click", function (e) {
            e.preventDefault();

            $("#EventCommand").val($(this).attr("data-pdsa-action"));

            $("form").submit();

        });
    });
});