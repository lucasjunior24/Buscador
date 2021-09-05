$(window).on('load', function () {
    if ($(".paginacomswiper").length) {
        /* swiper slider carousel */
        var swiper = new Swiper('.icon-slide', {
            slidesPerView: 'auto',
            spaceBetween: 0,
        });
        console.log(swiper.slidesPerView);
        swiper = new Swiper('.offer-slide', {
            slidesPerView: 'auto',
            spaceBetween: 0,
        });
        console.log(swiper.slidesPerView);
        swiper = new Swiper('.two-slide', {
            slidesPerView: 2,
            spaceBetween: 0,
            pagination: {
                el: '.swiper-pagination',
            },
        });
        console.log(swiper.slidesPerView);
        swiper = new Swiper('.news-slide', {
            slidesPerView: 5,
            spaceBetween: 0,
            pagination: {
                el: '.swiper-pagination',
            },
            breakpoints: {
                1024: {
                    slidesPerView: 4,
                    spaceBetween: 0,
                },
                768: {
                    slidesPerView: 3,
                    spaceBetween: 0,
                },
                640: {
                    slidesPerView: 2,
                    spaceBetween: 0,
                },
                320: {
                    slidesPerView: 2,
                    spaceBetween: 0,
                }
            }
        });
        console.log(swiper.slidesPerView);

        /* notification view and hide */
        setTimeout(function () {
            $('.notification').addClass('active');
            setTimeout(function () {
                $('.notification').removeClass('active');
            }, 3500);
        }, 500);
        $('.closenotification').on('click', function () {
            $(this).closest('.notification').removeClass('active')
        });
    }
});