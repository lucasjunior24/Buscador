﻿function AjaxModal() {

    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({ keyboard: true }, 'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#EnderecoTarget').load(result.url);
                        } else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });
}

//function BuscaCep() {
//    $(document).ready(function () {
//        function limpa_formulario_cep() {
//            // Limpa valores do formulario do cep
//            $("#Endereco_Logradouro").val("");
//            $("#Endereco_Bairro").val("");
//            $("#Endereco_Cidade").val("");
//            $("#Endereco_Estado").val("");
//        }
//        // Quando o campo cep perde o foco
//        $("#Endereco_Cep").blur(function () {

//            // Nova variavel "cep" somente com dígitos
//            var cep = $(this).val().replace(/\D/g, '');

//            // Verifica se campo cep possui valor informado
//            if (cep != "") {

//                // Expressão regular para validar cep
//                var validacep = /^[0=9]{8}$/;

//                // Valida o formato do cep
//                if (validacep.test(cep)) {
//                    // Preenche os campos com "..." enquanto consulta webservice
//                    $("#Endereco_Logradouro").val("");
//                    $("#Endereco_Bairro").val("");
//                    $("#Endereco_Cidade").val("");
//                    $("#Endereco_Estado").val("");

//                    // Consulta o webservice viacep.com.br/
//                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
//                        function (dados) {

//                            if (!("erro" in dados)) {
//                                // Atualiza os campos com valores da consulta
//                                $("#Endereco_Logradouro").val(dados.logradouro);
//                                $("#Endereco_Bairro").val(dados.bairro);
//                                $("#Endereco_Cidade").val(dados.cidade);
//                                $("#Endereco_Estado").val(dados.estado);
//                            } else {
//                                // Cep não encontrado
//                                limpa_formulario_cep();
//                                alert("Cep não encontrado");
//                            }
//                        }
//                    );
//                } else {
//                    // Cep não invalido
//                    limpa_formulario_cep();
//                    alert("Cep invalido");
//                }
//            } else {
//                // cep sem valor
//                limpa_formulario_cep();
//            }
//        });

//    });

//}

//$(document).ready(function () {
//    $("#msg_box").fadeOut(2500);
//});