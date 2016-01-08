﻿$(document).ready(function () {
    var event = $("#EventCommand").val($(this).attr("data-pdsa-action"));
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val($(this).attr("data-pdsa-action"));
        $("form").submit();
    });

    $(".reagendar").on("click", function () {
        $("#EventCommand").val("reagendamento");
        $('#modalReagendamento').modal('show');
        event;
    });
    $('.reagendar').on('shown.bs.modal', function () {
        $('#modalOpcaoPaciente').focus();
    });

    $(".modal-row").on("click", function () {
        $("#EventCommand").val("opcao");
        $('#modalOpcaoPaciente').modal('show');
        $('#handleRequest');
    });
    $('#modalOpcaoPaciente').on('shown.bs.modal', function () {
        $('#modalOpcaoPaciente').focus();
    });
});