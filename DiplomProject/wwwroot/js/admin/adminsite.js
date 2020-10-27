var adminmenu = $('.adminSideMenu');
const menu = $('#profileMenu');
const admintrigBtn = $('#menuTiggBtn');

function DoPostBack() {
    var select = document.getElementById("state");
    var option = select.options[select.selectedIndex];
    if (option.value != "Please select") {
        document.form1.action = "/Admin/Order/ChangeState";
        document.form1.submit();
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


function setNavigationAdmin() {
    var path = window.location.pathname;
    path = path.replace(/\/$/, '');
    path = decodeURIComponent(path);
    var xxx = path.split('/');
    if (path !== '') {
        var hrefs = $('.adminSideMenu li a[href*="/' + xxx[1] + '"]');
        if (hrefs.length > 1) {
            var hrefs2 = $('.adminSideMenu li a[href*="/' + xxx[1] + '/' + xxx[2] + '"]');
            $(hrefs2[0]).addClass('active');
            $(hrefs2[0]).parent().addClass('active');
           
        }
        else {
            $(hrefs[0]).addClass('active');
            $(hrefs2[0]).parent().addClass('active');
           
        }
    }
}







$(document).ready(function () {
    //setNavigation();
    //setAdminCustomerMenuNavigation();
    setNavigationAdmin();

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
    
    AddFlagIcons()


});



