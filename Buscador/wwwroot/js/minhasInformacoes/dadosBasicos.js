$(document).ready(function () {
    if (jQuery().mask) {
        $('.mask-cep').mask('00000-000');
        $('.mask-data').mask('00/00/0000');

        var SPMaskBehavior = function (val) {
            return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
        },
            spOptions = {
                onKeyPress: function (val, e, field, options) {
                    field.mask(SPMaskBehavior.apply({}, arguments), options);
                }
            };
        $('.mask-telefone').mask(SPMaskBehavior, spOptions);
    }
});