/////////////////////////////////////////////////////////////////
//
// DevelopeR: Alimohammad Eghbaldar
// https://eghbaldar.ir
//
// Features:
//----> 1: Warning Style Functions [change style when somethings happens at the client side]
//---------> Sample:
//---------> KingWarningStyle("#txtAttachmentTitle", 0);
//---------> KingWarningStyleOff("#txtAttachmentTitle", 0);
//
//----> 2: Check the validation a link [change the entered link in a way of checking two things: 1) the validation of own link struction 2) to comply the link with a parameter by the name of 'domain']
//---------> KingIsUrlValidWithDomain & KingIsUrlValidWithoutDomain
//---------> Sample:
//---------> 
//
/////////////////////////////////////////////////////////////////

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
function KingIsUrlValidWithDomain(link, domain) {
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
function KingIsUrlValidWithoutDomain(link) {
    var res = link.match(/(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@@:%_\+.~#?&//=]*)/g);
    if (res != null) {
        return true;
    }
    return false;
};