$(document).ready(function () {
   

    $('.modal').modal();
    $('select').material_select();

     $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15, // Creates a dropdown of 15 years to control year,
        today: 'Hoje',
        clear: 'Limpar',
        close: 'Pronto',
        closeOnSelect: false, // Close upon selecting a date,
        monthsFull: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthsShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        weekdaysFull: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sabádo'],
        weekdaysShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],        
        labelMonthNext: 'Próximo mês',
        labelMonthPrev: 'Mês anterior',
        labelMonthSelect: 'Selecione um mês',
        labelYearSelect: 'Selecione um ano',
        weekdaysLetter: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S']
        
     });

    requisicaoAjaxExcluirLivro();
    requisicaoAjaxExcluirAutor();
    requisicaoAjaxExcluirCategoria();
    requisicaoAjaxExcluirCliente();
    requisicaoAjaxExcluirEmprestimo();





});


function requisicaoAjaxExcluirLivro() {
    var livroId;
    $('.excluirLivro').click(function () {

        livroId = $(this).attr('data-id');
        $('#modalExcluir').modal('open');
        console.log("PASSOU");

    });

    $('#btnConfirmarExclusao').click(function () {

        var form = $('#_AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerficationToken"]', form).val();

        $.ajax({

            url: "Delete",
            type: "post",
            data: {
                __RequestVerficationToken: token,
                id: livroId


            },
            success: function () {
                return window.location.reload();
            }



        });

    });
}

function requisicaoAjaxExcluirAutor() {
    var autorId;
    $('.excluirAutor').click(function () {

        autorId = $(this).attr('data-id');
        $('#modalExcluirAutor').modal('open');
        console.log("PASSOU AUTOR");

    });

    $('#btnConfirmarExclusaoAutor').click(function () {

        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerficationToken"]', form).val();

        $.ajax({

            url: "Delete",
            type: "post",
            data: {
                __RequestVerficationToken: token,
                id: autorId


            },
            success: function () {
                return window.location.reload();
            }



        });

    });

}

function requisicaoAjaxExcluirCategoria() {
    var categoriaId;
    $('.excluirCategoria').click(function () {

        categoriaId = $(this).attr('data-id');
        $('#modalExcluirCategoria').modal('open');
        console.log("PASSOU CATEGORIA");

    });

    $('#btnConfirmarExclusaoCategoria').click(function () {

        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerficationToken"]', form).val();

        $.ajax({

            url: "Delete",
            type: "post",
            data: {
                __RequestVerficationToken: token,
                id: categoriaId


            },
            success: function () {
                return window.location.reload();
            }



        });

    });

}

function requisicaoAjaxExcluirCliente() {
    var clienteId;
    $('.excluirCliente').click(function () {

        clienteId = $(this).attr('data-id');
        $('#modalExcluirCliente').modal('open');
        console.log("PASSOU CLIENTE");

    });

    $('#btnConfirmarExclusaoCliente').click(function () {

        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerficationToken"]', form).val();

        $.ajax({

            url: "Delete",
            type: "post",
            data: {
                __RequestVerficationToken: token,
                id: clienteId


            },
            success: function () {
                return window.location.reload();
            }



        });

    });

}

function requisicaoAjaxExcluirEmprestimo() {
    var emprestimoId;
    $('.excluirEmprestimo').click(function () {

        emprestimoId = $(this).attr('data-id');
        $('#modalExcluirEmprestimo').modal('open');
        console.log("PASSOU EMPRESTIMO");

    });

    $('#btnConfirmarExclusaoEmprestimo').click(function () {

        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerficationToken"]', form).val();

        $.ajax({

            url: "Delete",
            type: "post",
            data: {
                __RequestVerficationToken: token,
                id: emprestimoId


            },
            success: function () {
                return window.location.reload();
            }



        });

    });

}