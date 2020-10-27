

function HideDivByScroll() {
    if (window.pageYOffset || document.documentElement.scrollTop) {
        $(".greybox").hide();
    }
    if (window.scrollY === 0) {
        $(".greybox").show();
    }
    $('main').css('margin-top', $('header').height() - 2);
}

function VisibilityProfileMenu() {
    if ($(document).width() > 576 && $(document).width() < 992) {
        $('.userSideMenu').css('width', '0');
        $('.userSideMenu').css('top', $('header').height());
    }
}

$.InitDatePickers = function () {
    for (var i = 0; i < arguments.length; i++) {
        $(arguments[i]).datetimepicker({
            locale: navigator.languages[0],
            format: 'L'
        });
    }
};

function Togglebox() {
    if ($(document).width() < 1200) {
        $('.switchbox').hide();
        $('.topmenuinside').hide();
    }
}

function ToggleBoxBehevior(el) {
    var menuId = $(el).data('target');
    if ($(document).width() < 1200) {

        $(menuId).toggle();
    }
}

function animate(element) {
    if ($(document).width() < 576) {
        transition.begin(element, {
            property: "width",
            from: "0",
            to: "80px",
            duration: "500ms",
            timingFunction: "linear"
        });
    }
    if ($(document).width() > 992) {
        transition.begin(element, {
            property: "width",
            from: "1px",
            to: "10rem",
            duration: "500ms",
            timingFunction: "linear"
        });
    }
    else {
        transition.begin(element, {
            property: "width",
            from: "1px",
            to: "20rem",
            duration: "500ms",
            timingFunction: "linear"

        });
    }
}

function ModelStep(el) {
    $('.startpage .mytimeline li').removeClass('active');
    $('.startpage .buisness_model img').prop('hidden', true);
    $('.startpage .model_description div:not(:last-child)').prop('hidden', true);
    $('.' + $(el).data('btn')).prop('hidden', false);
    $(el).addClass('active');

}

function ActivatePagination(el) {
    $('.pagination a').removeClass('active');
    $(el).addClass('active');
}

function AddFlagIcons() {
    $('.lang option').each(function () {
        switch ($(this).val()) {
            case 'en-US':
                $(this).attr('data-icon', 'lang-icon icon-en-US');
                break;
            case 'it':
                $(this).attr('data-icon', 'lang-icon icon-it');
                break;
            case 'de':
                $(this).attr('data-icon', 'lang-icon icon-de');
                break;
            case 'es':
                $(this).attr('data-icon', 'lang-icon icon-es');
                break;
            case 'fr':
                $(this).attr('data-icon', 'lang-icon icon-fr');
                break;
            case 'ro':
                $(this).attr('data-icon', 'lang-icon icon-ro');
                break;
            case 'sl':
                $(this).attr('data-icon', 'lang-icon icon-sl');
                break;
            case 'ru':
                $(this).attr('data-icon', 'lang-icon icon-ru');
                break;
            default:
                $(this).attr('data-icon', 'lang-icon icon-en');
        }
    });
}

function openBoxFunction() {
    if ($(document).width() < 768) {
        openBoxMobile(event);
    }
    else {
        openBox(event);
    }
}

function openBox(event) {
    // Declare all variables
    var i, tabcontentId, tablinksId;
    $('.tabcontent').hide();
    $('.tablinks').removeClass('active');
    $(event.currentTarget).addClass('active');
    tablinksId = $(event.currentTarget).attr('id');
    $('.tabcontent' + '#' + tablinksId).show();
}

function openBoxMobile(event) {
    // Declare all variables
    var i, tabcontentId, activeId;
    $('.tabcontent').hide();
    $('.tablinks').removeClass('active');
    $(event.currentTarget).addClass('active');
    activeId = $(event.currentTarget).attr('id');
    $('.tabcontent' + '#' + activeId).show();
    $('.tablinks').hide();
}

function openBoxMobileReverse(event) {
    // Declare all variables
    var i, tabcontentId, activeId;
    $('.tabcontent').removeClass('active');
    activeId = $(event.currentTarget).attr('id');
    $('.tablinks' + '#' + activeId).addClass('active');
    $('.tablinks').show();
    $('.tabcontent').hide();
}


$('.tabcontent').on('click', function (event) {
    if ($(document).width() < 768) {
        openBoxMobileReverse(event);
    }
});


const menu = $('#profileMenu');
var adminmenu = $('.adminSideMenu');
const userCloseBtn = $('.profile-menu .closebtn');
const userMenuOuther = $('.userSideMenu > div');
const userMenuInner = $('#profileMenu.userSideMenu');
const admintrigBtn = $('#menuTiggBtn');
const sextionoutherbox = $('.adminProfile > div');

function OpenCloseNav() {
    if (menu.width() > 0) {
        menu.width(0);
        userCloseBtn.hide();
    }
    else {
        userMenuOuther.width(272);
        userMenuInner.width('100%');
        userMenuInner.height('100%');
        userMenuInner.css('background-color', 'rgba(0,0,0,0.8)');
        userCloseBtn.show();
    }
}

function TrigBtnActive() {
    if (admintrigBtn.hasClass('active')) {
        admintrigBtn.removeClass('active');
    }
    else {
        admintrigBtn.addClass('active');
    }
    adminSectionWidth();
}

function adminSectionWidth() {
    var tmpWidth = 72;
    if (admintrigBtn.hasClass('active')) {
        tmpWidth = 72;
        $('.adminSideMenu li > a').css('padding-left', '50px')
    }
    else {
        tmpWidth = 200;
        $('.adminSideMenu li > a').css('padding-left', '32px')
    };
    adminmenu.width(tmpWidth);
    $('.adminProfile section').css('margin-left', tmpWidth);
}



function BackResize() {
    var datawidth;

    if ($(window).width() >= 989) {
        datawidth = $('.responiveback').data('img-1920');
    }
    if ($(window).width() < 989 && $(window).width() >= 480) {
        datawidth = $('.responiveback').data('img-989');
    }
    if ($(window).width() < 480) {
        datawidth = $('.responiveback').data('img-767');
    }
    $('.responiveback').css('background-image', 'url(' + datawidth + ')');
}

function SupprtSwipesVisibility() {
    if ($(window).width() > 480)
        $('[data-toggle=tooltip]').tooltip();
}

function setNavigation() {
    var path = window.location.pathname;
    $('.adminSideMenu li a').each(function () {
        if ($(this).attr('href') === path) {
            $(this).addClass('active');
            $(this).parent().addClass('active');
        }
    })
}




$(document).ready(function () {
    BackResize();
    SupprtSwipesVisibility();

    $(window).resize(function () {
        BackResize();
        SupprtSwipesVisibility();
        VisibilityProfileMenu();

    });

    VisibilityProfileMenu();

    $('.attfilebtn').on('click', function (e) {
        var filebox = $(e.currentTarget).parent('.usermsg');
        var placeholders = $(filebox).find('.attachment');
        var num = placeholders.length;
        var numt = 0;
        if (num > 0) {
            numt = $(placeholders[num - 1]).data('rownum') + 1;
        }
        var inputId = Date.now();
        $(`<div class ="attachment d-flex flex-row justify-content-start align-items-center mx-2 w-100" data-rownum="${numt}"><input type="file" id="${inputId}" name="Documents[${numt}].DocId" hidden ></div>`).appendTo(filebox);

        $('#' + inputId).click();

        $('#' + inputId).on('change', function (e) {
            var filename = $(this).val();
            var parentbox = $(e.currentTarget).parent();
            if (filename.length > 0) {
                $(`<span class ="pathname d-flex"></span><a class="closebutton m-2" ><i class="fa fa-times" aria-hidden="true"></i></a>`).appendTo(parentbox);
                $(parentbox).find('.pathname').html($(this).val().replace('C:\\fakepath\\', ''));
                $(parentbox).find('.closebutton').on('click', function (e) {
                    $(e.currentTarget).parent().remove();
                });
            } else {
                $(parentbox).remove();
            }
        });
    });

    AddFlagIcons();

    $('.selectpicker').selectpicker({ 'iconBase': 'fas'/*, 'width': '220px'*/ });

    $('.profile-orders .closebtn').hide();

    window.onscroll = HideDivByScroll;

    Togglebox();

    $(".js-range-slider").ionRangeSlider({
        type: "double",
        min: 0,
        max: 2000,
        from: 10,
        to: 2000,
        grid: false
    });

    $(" .js-range-slider-1").ionRangeSlider({
        min: 500,
        max: 200000,
        drag_interval: true,
        min_interval: null,
        max_interval: null
    });

    $(" .js-range-slider-2").ionRangeSlider({
        min: 0,
        max: 12,
        from: 0,
        min_interval: null,
        max_interval: null
    });

    $(" .js-range-slider-3").ionRangeSlider({
        min: 0,
        from: 550,
        min_interval: null,
        max_interval: null
    });

    $('.staticmenu .dropdownButton').on('click', function (e) {
        ToggleBoxBehevior(e.target);
    });

    $('.menu .dropdownButton').on('click', function (e) {
        ToggleBoxBehevior(e.target);
    });

    $('.buisness_model .carousel').carousel('pause');

    if ($(document).width() > 992) {
        $('.nav-search-btn').on('click', function () {
            $(".search").addClass("border-bottom");
            animate($(".search-form-input")[0]);
            $(".search-form-input").attr('placeholder', 'Search...');
            $('.search-form-input').focus();
        });

        $('.search-form-input').on('blur', function () {
            animate_contrary($(".search-form-input")[0]);
            $(".search").removeClass("border-bottom");
        });
    }
    else {
        $('.nav-search-btn').on('click', function () {
            $(".search-form-input").addClass("border");
            animate($(".search-form-input")[1]);
            $(".search-form-input").attr('placeholder', 'Search...');
            $('.search-form-input').focus();
        });

        $('.search-form-input').on('blur', function () {
            animate_contrary($(".search-form-input")[1]);
            $(".search-form-input").removeClass("border");
        });
    }

    $('form input[name="email"]').blur(function () {
        var email = $(this).val();
        var re = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/igm;
        if (re.test(email)) {
            $('.mail .msg').hide();
            $('.allsendbuttons button[type="submit"]').attr('disabled', false);
        } else {
            $('.mail .msg').hide();
            $('.mail .error').show();
            $(' button.allsendbuttons[type="submit"]').attr('disabled', true);
        }
    });

    $('.name input').blur(function () {
        var name = $(this).val();
        var re = /^[A-Za-z\s]+$/igm;
        if (re.test(name)) {
            $(this).siblings('.msg').hide();
        } else {
            $(this).siblings('.msg').hide();
            $(this).siblings('.msg').show();
            $('.registration button[type="submit"]').attr('disabled', true);
        }

    });

    $('form input[name="currentpass"]').blur(function () {
        var pass = $(this).val();
        var re = /(?=.*[A-Z].*[A-Z])(?=.*[!@#$ &*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,}/igm;
        if (re.test(pass)) {
            $('.pass .msg').hide();
        } else {
            $('.pass .msg.grey').hide();
            $('.pass .msg.error').show();
            $('.registration button[type="submit"]').attr('disabled', true);
        }
    });

    $('.registration .step_2').hide();

    $('.dropdown button').on('click', function () {
        var src = $(this).parent().children("img").attr('src');
        if (src === '/svg/righticon.svg') {
            $(this).parent().children("img").attr('src', '/svg/downicon.svg');
        }
        else {
            $(this).parent().children("img").attr('src', '/svg/righticon.svg');
        }
    });

    $('.responsive').slick({
        dots: false,
        infinite: true,
        variableWidth: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        prevArrow: false,
        nextArrow: false,
        autoplay: true,
        responsive: [

            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: false,
                    variableWidth: true,
                    prevArrow: false,
                    nextArrow: false,
                    autoplay: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    variableWidth: true
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }

            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });


    $(".pagination a").on('click', function (e) {
        ActivatePagination(e.target);
    });

    $(".card.transactionBtn").on('click', function (e) {
        ActivateToggleBtn(e.currentTarget);
    });

    var acc = document.getElementsByClassName("accordion");

    for (var i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            this.classList.toggle("active");


            var panel = this.nextElementSibling;
            if (panel.style.display === "block") {
                this.innerHTML = "View details";
                panel.style.display = "none";


            } else {
                panel.style.display = "block";
                this.innerHTML = "Hide details";
            }

        });
    }

    function ActivateToggleBtn(el) {
        $('.card.transactionBtn').removeClass('activetransBtn');
        $(el).addClass('activetransBtn');
    }

    $("input:checkbox").on('click', function () {
        var $box = $(this);
        if ($box.is(":checked")) {
            var group = "input:checkbox[name='" + $box.attr("name") + "']";
            $(group).prop("checked", false);
            $box.prop("checked", true);
        } else {
            $box.prop("checked", false);
        }
    });


    //admin menu
    setNavigation();

    adminmenu.on({
        mouseenter: function () {
            if (admintrigBtn.hasClass('active')) {
                $(this).width(200);
            }
        },
        mouseleave: function () {
            if (admintrigBtn.hasClass('active')) {
                $(this).width(72);
            }
        }
    });

    adminSectionWidth();
    if ($(document).width() <= 768) {
        admintrigBtn.click();
    }
});

