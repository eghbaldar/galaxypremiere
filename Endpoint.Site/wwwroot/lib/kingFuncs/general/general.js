// Warning Style
function KingWarningStyle(controlId, type) {
    switch (type) {
        case 0: // border-bottom
            $(controlId).css("border-bottom", "2px dashed #ff8585");
            break;
    }
}
function KingWarningStyleOff(controlId, type) {
    switch (type) {
        case 0: // border-bottom
            $(controlId).css("border-bottom", "1px solid #dee2e6");
            break;
    }
}
// Check the validation a link
function KingIsUrlValid(link, domain) {
    var res = link.match(/(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@@:%_\+.~#?&//=]*)/g);
    if (res != null) {
        var length = domain.length;
        var hostname = link.substring(0, length);
        if (hostname == domain)
            return true;
        else
            return false;
    }
    return false;
};