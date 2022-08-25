
/*
 calc_digitos_posicoes
 
 Multiplica dígitos vezes posições
 
 @param string digitos Os digitos desejados
 @param string posicoes A posição que vai iniciar a regressão
 @param string soma_digitos A soma das multiplicações entre posições e dígitos
 @return string Os dígitos enviados concatenados com o último dígito
*/
function calc_digitos_posicoes(digitos, posicoes = 10, soma_digitos = 0) {

    // Garante que o valor é uma string
    digitos = digitos.toString();

    // Faz a soma dos dígitos com a posição
    // Ex. para 10 posições:
    //   0    2    5    4    6    2    8    8   4
    // x10   x9   x8   x7   x6   x5   x4   x3  x2
    //   0 + 18 + 40 + 28 + 36 + 10 + 32 + 24 + 8 = 196
    for (let digito of digitos) {
        // Preenche a soma com o dígito vezes a posição
        soma_digitos = soma_digitos + (digito * posicoes);

        // Subtrai 1 da posição
        posicoes--;

        // Parte específica para CNPJ
        // Ex.: 5-4-3-2-9-8-7-6-5-4-3-2
        if (posicoes < 2) {
            // Retorno a posição para 9
            posicoes = 9;
        }
    }

    // Captura o resto da divisão entre soma_digitos dividido por 11
    // Ex.: 196 % 11 = 9
    soma_digitos = soma_digitos % 11;

    // Verifica se soma_digitos é menor que 2
    if (soma_digitos < 2) {
        // soma_digitos agora será zero
        soma_digitos = 0;
    } else {
        // Se for maior que 2, o resultado é 11 menos soma_digitos
        // Ex.: 11 - 9 = 2
        // Nosso dígito procurado é 2
        soma_digitos = 11 - soma_digitos;
    }

    // Concatena mais um dígito aos primeiro nove dígitos
    // Ex.: 025462884 + 2 = 0254628842
    let cpf = digitos + soma_digitos;

    // Retorna
    return cpf;

}

/*
 Valida CPF
 
 @param  string cpf O CPF com ou sem pontos e traço
 @return bool True para CPF correto - False para CPF incorreto
*/
function valida_cpf(valor) {

    // Garante que o valor é uma string
    // Remove caracteres inválidos do valor
    valor = valor.replace(/([^\d])+/gim, '');
    if (valor.length != 11 ||
        valor == "00000000000" ||
        valor == "11111111111" ||
        valor == "22222222222" ||
        valor == "33333333333" ||
        valor == "44444444444" ||
        valor == "55555555555" ||
        valor == "66666666666" ||
        valor == "77777777777" ||
        valor == "88888888888" ||
        valor == "99999999999")
        return false;
    // Captura os 9 primeiros dígitos do CPF
    // Ex.: 02546288423 = 025462884
    let digitos = valor.substr(0, 9);

    // Faz o cálculo dos 9 primeiros dígitos do CPF para obter o primeiro dígito
    let novo_cpf = calc_digitos_posicoes(digitos);

    // Faz o cálculo dos 10 dígitos do CPF para obter o último dígito
     novo_cpf = calc_digitos_posicoes(novo_cpf, 11);

    // Verifica se o novo CPF gerado é idêntico ao CPF enviado
    return novo_cpf === valor ? true : false;

} 

$(function () {

    // ## EXEMPLO 2
    // Aciona a validação ao sair do input
    $('#Cpf').blur(function () {

        // O CPF ou CNPJ
        let cpf_cnpj = $(this).val();
        cpf_cnpj.toString();
        // Testa a validação
        if (valida_cpf(cpf_cnpj)) {
            $("#validaCpfSpan").text("")
        } else {
            $("#btnAgendar").addClass("disabled")
            $("#validaCpfSpan").text("Cpf inválido")
        }

    });

});