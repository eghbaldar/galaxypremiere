var ROOT = '@Url.Content("~")' + '/waitMe/img.svg';
// BUTTON LOADING
function run_waitMe(el, num, effect) {
    text = 'Please wait...';
    fontSize = '';
    switch (num) {
        case 1:
            maxSize = '';
            textPos = 'vertical';
            break;
        case 2:
            text = '';
            maxSize = 30;
            textPos = 'vertical';
            break;
        case 3:
            maxSize = 30;
            textPos = 'horizontal';
            fontSize = '18px';
            break;
    }
    el.waitMe({
        effect: effect,
        text: text,
        bg: 'rgba(255,255,255,0.7)',
        color: 'blue',
        maxSize: maxSize,
        waitTime: -1,
        source: ROOT,
        textPos: textPos,
        fontSize: fontSize,
        onClose: function (el) { }
    });
}
function btnWaitMe_Start(e) {
    $('#' + e).attr('disabled', 'disabled'); // disable submit button temporary
    run_waitMe($('#' + e), 2, 'pulse');
}
function btnWaitMe_Stop(e) {
    $('#' + e).attr('disabled', false); // enable submit button
    $('.containerBlock > form').waitMe('hide');
    $('#' + e).waitMe('hide');
}
// LOADING PAGE AFTER FUNCTION CALLING
function pageWaitMe(effect) {

    $('body').addClass('waitMe_body');
    var img = '';
    var text = '';
    if (effect == 'img') {
        img = 'background:url(' + ROOT + ')';
    } else if (effect == 'text') {
        text = 'Loading...';
    }
    var elem = $('<div class="waitMe_container ' + effect + '"><div style="' + img + '">' + text + '</div></div>');
    $('body').prepend(elem);

}
function pageWaitMeRemove() {
    $('body.waitMe_body').find('.waitMe_container:not([data-waitme_id])').remove();
    $('body.waitMe_body').removeClass('waitMe_body hideMe');
}
// After each _PostBack
$(document).ready(function () {
pageWaitMe("progress");
});
