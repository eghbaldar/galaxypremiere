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
// give a data and get the time ago based on the following structure
function KingGetTimeAgo(date) {
    var currentDate = new Date();
    var timeDiff = currentDate.getTime() - date.getTime();
    var seconds = Math.floor(timeDiff / 1000);
    var minutes = Math.floor(seconds / 60);
    var hours = Math.floor(minutes / 60);
    var days = Math.floor(hours / 24);
    var weeks = Math.floor(days / 7);
    var months = Math.floor(days / 30);
    var years = Math.floor(days / 365);

    if (seconds < 60) {
        return seconds + " sec ago";
    } else if (minutes < 60) {
        return minutes + " min ago";
    } else if (hours < 24) {
        return hours + " hour ago";
    } else if (days < 7) {
        return days + " day ago";
    } else if (weeks < 4) {
        return weeks + " week ago";
    } else if (months < 12) {
        return months + " month ago";
    } else {
        return years + " year ago";
    }
}
// return only time or date from datetime: for example '2022-03-15T12:30:45'
function KingSeparateOnlyTimeFromDatetime(datetimeString) {
    var d = (datetimeString.split(' ')[1]).split(':');
    return d[0] + ':' + d[1];
}
function KingSeparateOnlyDateFromDatetime(datetimeString) {
    return (datetimeString.split(' ')[0]);
}
