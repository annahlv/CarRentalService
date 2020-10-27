//var nextButton = $("#right-btn");
//var backButton = $("#left-btn");
//var con = $("#cont");
//var sliderCont = $("#slider-container");

//var sldElm = $(".item-image-wrapper img");
//var i = 0;
//while (i < sldElm.length) {
//    sldElm[i].setAttribute("draggable", false);
//    i++;
//}

//var mL = 0, maxX = 200, diff = 0;

//function slide() {
//    mL -= 100;
//    if (mL < -maxX) { mL = 0; }
//    sliderCont.animate({ "margin-left": mL + "%" }, 800);
//}

//function slideBack() {
//    mL += 100;
//    if (mL > 0) { mL = -200; }
//    sliderCont.animate({ "margin-left": mL + "%" }, 800);
//}

//nextButton.click(slide);
//backButton.click(slideBack);

//$(document).on("mousedown touchstart", con, function (e) {

//    var startX = e.pageX || e.originalEvent.touches[0].pageX;
//    diff = 0;
//});