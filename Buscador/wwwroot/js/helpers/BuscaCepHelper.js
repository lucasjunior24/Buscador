var $CepConsultado = false;
var $ValorDeCepConsultado = "";

if ($('#Cep').val() !== "" && $('#Cep').val() != null) {
    buscarCep($('#Cep'));
}
$('#Cep').keyup(function () {
    if ($(this).val().length > 8) {
        buscarCep($(this));
    }
});

function buscarCep(el) {
    let cep = el.val().replace(/\D/g, '');
    let vm = this;

    //Verifica se o elemento esta vazio
    if (cep !== "") {
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {
            //Consulta o webservice viacep.com.br/
            $.getJSON("/MinhasInformacoes/BuscarCep", { cep },
                function (resultado) {
                    if (resultado.type == "success") {
                        //Atualiza os campos com os valores da consulta.
                        $(".Rua").val(resultado.dados.logradouro);
                        $(".Bairro").val(resultado.dados.bairro);
                        $(".Municipio").val(resultado.dados.localidade);
                        $(".Uf").val(resultado.dados.uf);
                        habilitarForm();
                        //Exibe o resto do Formulário
                        $CepConsultado = true;
                        $ValorDeCepConsultado = cep;
                    }
                    else {
                        //CEP pesquisado não foi encontrado.
                        vm.limpaFormCep();
                        Swal.fire({
                            type: 'warning',
                            title: 'Atenção',
                            text: 'CEP não encontrado!'
                        })
                        desabilitarForm();
                    }
                })
                    .fail(function () {
                    console.log("error");
                    vm.limpaFormCep();
                    Swal.fire({
                        type: 'warning',
                        title: 'Atenção',
                        text: 'Não foi possível buscar o endereço. Entre em contato com a AGEVISA'
                    })
                    desabilitarForm();
                })

                ;
        } else {
            //CEP é inválido.
            vm.limpaFormCep();
            Swal.fire({
                type: 'warning',
                title: 'Atenção',
                text: 'Formato de CEP inválido!'
            })
            desabilitarForm();
        }
    } else {
        //CEP sem valor, limpa formulário.
        vm.limpaFormCep();
        desabilitarForm();
        return false;
    }
}

function limpaFormCep() {
    //Limpa valores do formulário de CEP.
    $(".Rua").val('');
    $(".Bairro").val('');
    $(".Municipio").val('');
    $(".Uf").val('');
    $("#Numero").val('');
    $("#Complemento").val('');
}

function habilitarForm() {
    $('#Endereco').addClass("show");
    $('#submit').attr("disabled", false);
}

function desabilitarForm() {
    $('#Endereco').removeClass('show');
    $('#submit').attr("disabled", true);
}

$('#btnBuscarCep').on('click', function () {
    var el = $(".Cep");
    let cep = el.val().replace(/\D/g, '');
    if (cep !== "") {
        buscarCep(el);
    }
});

$(".Cep").on('keyup keypress', function (e) {
    var keyCode = e.keyCode || e.which;
    if (keyCode === 13) {
        var el = $(".Cep");
        let cep = el.val().replace(/\D/g, '');
        if (cep !== "") {
            e.preventDefault();
            buscarCep(el);
        }
        else {
            e.preventDefault();
        }
    }
});