function VisibilityProfileMenu() {
    if ($(document).width() > 576 && $(document).width() < 992) {
        $('.userSideMenu').css('width', '0');
        $('.userSideMenu').css('top', $('header').height());
    }
}

const menu = $('#profileMenu');
const userCloseBtn = $('.profile-menu .closebtn');
const userMenuOuther = $('.userSideMenu > div');
const userMenuInner = $('#profileMenu.userSideMenu');
//const sextionoutherbox = $('.adminProfile > div');

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



$(document).ready(function () {
    
    VisibilityProfileMenu();
    $('.profile-orders .closebtn').hide();

    $(window).resize(function () {
        
        VisibilityProfileMenu();

    });



});

