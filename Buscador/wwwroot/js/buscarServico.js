var $inputPesquisa = $("#inputPesquisa");
var urlPesquisa = $inputPesquisa.data("url");
var $listaDePesquisas = $("#resultadoDaPesquisa");
var urlNova = urlAction;

$inputPesquisa.keyup(function () {
    var $self = $(this);
    $listaDePesquisas.html("");

    if ($self.val().length >= 3) {
        var $texto = $self.val();
        var dados = {
            search: $texto
        }

        $.getJSON(urlPesquisa, dados)
            .then(function (data) {
                var retorno = "";

                for (var busca in data) {
                    retorno +=
                        "<li class='list-group-item'><a href='" + urlNova + "?id=" + data[busca].value + "' data-id='" +
                        data[busca].value +
                        "'>" +
                        data[busca].text +
                        "</a></li>";
                }

                $listaDePesquisas.html(retorno);
            })
    }
});

$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});

$("#inputPesquisa").on("keydown", function search(e) {
    if (e.keyCode == 13) {
        if ($("#inputPesquisa").val().length >= 3) {
            $("#formularioBusca").submit();
        }
       
    }
});