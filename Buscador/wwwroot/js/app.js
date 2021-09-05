$(document).ready(function () {
    /* float label checking input is not empty */
    $('.float-label .form-control').on('blur', function () {
        if ($(this).val() || $(this).val().length != 0) {
            $(this).closest('.float-label').addClass('active');
        } else {
            $(this).closest('.float-label').removeClass('active');
        }
    })

    /* menu open close wrapper screen click close menu */
    $('.menu-btn').on('click', function (e) {
        e.stopPropagation();
        if ($('body').hasClass('sidemenu-open') == true) {
            $('body, html').removeClass('sidemenu-open');
            setTimeout(function () {
                $('body, html').removeClass('menuactive');
            }, 500);
        } else {
            $('body, html').addClass('sidemenu-open menuactive');
        }
    });
    $('.wrapper, .closesidemenu').on('click', function () {

        if ($('body').hasClass('sidemenu-open') == true) {

            $('body, html').removeClass('sidemenu-open');
            setTimeout(function () {
                $('body, html').removeClass('menuactive');
            }, 500);
        }
    });

    /* filter click open filter */
    if ($('body').hasClass('filtermenu-open') == true) {
        $('.filter-btn').find('i').html('close');
    }
    $('.filter-btn').on('click', function () {
        if ($('body').hasClass('filtermenu-open') == true) {
            $('body').removeClass('filtermenu-open');
            $(this).find('i').html('filter_list')

        } else {
            $('body').addClass('filtermenu-open');
            $(this).find('i').html('close')
        }
    });

    /* background image to cover */
    $('.background').each(function () {
        var imagewrap = $(this);
        var imagecurrent = $(this).find('img').attr('src');
        imagewrap.css('background-image', 'url("' + imagecurrent + '")');
        $(this).find('img').remove();
    });

    if ($.cookie("theme-color-layout") === 'theme-dark') {
        $('html').addClass($.cookie("theme-color-layout"));
    }

    $('#theme-dark').click(function () {
        if ($.cookie("theme-color-layout") === 'theme-light' || $.cookie("theme-color-layout") == undefined) {
            $('html').removeClass('theme-light');
            $('html').removeClass($.cookie("theme-color-layout"));
            document.cookie = ("theme-color-layout=theme-dark" + "; Path=/");
            //$.cookie("theme-color-layout", 'theme-dark', {});
            $('html').addClass($.cookie("theme-color-layout"));
        }
        else {
            $('html').removeClass('theme-dark');
            $('html').removeClass($.cookie("theme-color-layout"));
            document.cookie = ("theme-color-layout=theme-light" + "; Path=/");
            //$.cookie("theme-color-layout", 'theme-light', {});
            $('html').addClass($.cookie("theme-color-layout"));
        }

    });

});

$(window).on('resize', function () {
    /* login row */
    $('.login-row').css('min-height', ($(window).height() - 80));
});


