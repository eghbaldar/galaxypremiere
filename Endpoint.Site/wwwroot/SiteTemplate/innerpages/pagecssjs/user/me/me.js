function UpdateInfoAccount() {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateAccount'); // Loading Button Start

    var firstname = $('#txtFirstname').val();
    var middlename = $('#txtMiddlename').val();
    var surname = $('#txtSurname').val();
    var genderId = $('#selectGender').val();
    var languageId = $('#selectLanguage').val();
    var birthday = $('#datepickerBirthday').val();
    var birthcity = $('#txtBirthcity').val();
    var currentCity = $('#txtCurrentCity').val();

    var postData = {
        'Firstname': firstname,
        'MiddleName': middlename,
        'Surname': surname,
        'Gender': genderId,
        'LanguageId': languageId,
        'BirthDay': birthday,
        'BirthCity': birthcity,
        'CurrentCity': currentCity,
    }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeAccount',
        success: function (data) {
            if (data.isSuccess) KingSweetAlert(true, null);
            else KingSweetAlert(false, null);
        },
        error: function (request, status, error) {
            KingSweetAlert(false, null);
        }
    }).always(function () {
        btnWaitMe_Stop('btnUpdateAccount'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    });
}
function UpdateInfoContact() {
    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateContact'); // Loading Button Start

    var address1 = $('#txtAddress1').val();
    var address2 = $('#txtAddress2').val();
    var city = $('#txtCity').val();
    var state = $('#txtState').val();
    var postalCode = $('#txtPostalCode').val();
    var countryId = $('#selectCountry').val();
    var phone = $('#txtPhone').val();
    var recoveryEmail = $('#txtRecoveryEmail').val();
    var website = $('#txtWebsite').val();
    var facebook = $('#txtFacebook').val();
    var instagram = $('#txtInstagram').val();
    var twitter = $('#txtTwitter').val();
    var stage32 = $('#txtStage32').val();
    var youtube = $('#txtYoutube').val();
    var linkden = $('#txtLinkden').val();
    var vimeo = $('#txtVimeo').val();
    var imdb = $('#txtIMDb').val();

    var postData = {
        'Address1': address1,
        'Address2': address2,
        'City': city,
        'State': state,
        'PostalCode': postalCode,
        'CountryId': countryId,
        'Phone': phone,
        'RecoveryEmail': recoveryEmail,
        'Website': website,
        'Facebook': facebook,
        'Instagram': instagram,
        'Twitter': twitter,
        'Stage32': stage32,
        'Youtube': youtube,
        'Linkden': linkden,
        'Vimeo': vimeo,
        'Imdb': imdb,
    }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeContact',
        success: function (data) {
            if (data.isSuccess) KingSweetAlert(true, null);
            else KingSweetAlert(false, null);
        },
        error: function (req, status, err) {
            KingSweetAlert(false, null);
        }
    }).always(function () {
        btnWaitMe_Stop('btnUpdateContact'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    });
}
function UpdateInfoPrivacy(e, privacy) {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnPrivacy0'); // Loading Button Start
    btnWaitMe_Start('btnPrivacy1'); // Loading Button Start
    btnWaitMe_Start('btnPrivacy2'); // Loading Button Start

    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: { 'Privacy': privacy },
        url: 'MePrivacy',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(true, null);
                // change styles of buttons
                $("#btnPrivacy0").addClass('btn cur-p btn-light');
                $("#btnPrivacy1").addClass('btn cur-p btn-light');
                $("#btnPrivacy2").addClass('btn cur-p btn-light');
                $(e).removeClass();
                $(e).addClass('btn cur-p btn-primary');
                // end
            }
            else {
                KingSweetAlert(false, null);
            }
        },
        error: function (request, status, error) {
            KingSweetAlert(false, null);
        }
    }).always(function () {
        btnWaitMe_Stop('btnPrivacy0'); // Loading Button Stops
        btnWaitMe_Stop('btnPrivacy1'); // Loading Button Stops
        btnWaitMe_Stop('btnPrivacy2'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    });
}
function UpdateInfoUsername() {

    var username = $("#txtUsername").val().trim();
    if (!CheckValidUsername(username)) return false;
    /// why is not the following part placed in CheckValidUsername function?
    /// because if a client enters less than 5 characters, the system is keeping to notify error to him!
    if (username.toString().length < 5) {
        KingSweetAlert(false, "The username lenght must be more than 5 characters.");
        return false;
    }

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateUsername'); // Loading Button Start

    var postData = { 'username': username, };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeUsername',
        success: function (data) {
            if (data.isSuccess) {
                KingSweetAlert(true, null);
                UsernameStatus(false);
                $("#txtUsername").attr('data-firstValue', username);
            }
            else {
                var check = data.data.status;
                switch (check) {
                    case 0:
                        //duplicated!
                        KingSweetAlert(false, data.message);
                        break;
                    case 2:
                        //user did not find
                        KingSweetAlert(false, data.message);
                        break;
                }
            }
        },
        error: function (request, status, error) {
            KingSweetAlert(false, null);
        }
    }).always(function () {
        btnWaitMe_Stop('btnUpdateUsername'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    });
}
function ChangeRuntimeUsername(e) {

    var input = $("#txtUsername").val();
    if (!CheckValidUsername(input)) {
        $("#iconCurrentUsername").removeClass();
        $("#iconCurrentUsername").addClass("fa-solid fa-circle-xmark colorRed");
        return false;
    }
    $("#spanCurrentUsername").html("<a target='_blank' href='https://galaxypremiere.com/" + input + "'>www.galaxypremiere.com/" + input + "</a>");

    var postData = { 'Username': input, };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeUsernameRuntime',
        success: function (data) {
            if (!data) {
                $("#iconCurrentUsername").removeClass();
                $("#iconCurrentUsername").addClass("fa-solid fa-check-double colorGreen");
            } else {
                $("#iconCurrentUsername").removeClass();
                $("#iconCurrentUsername").addClass("fa-solid fa-circle-xmark colorRed");
            }
        },
        error: function (request, status, error) {
            KingSweetAlert(false, null);
        }
    });
}
function CheckValidUsername(username) {

    // All the following code are simulated as C# in 
    var firstValueUsername = $("#txtUsername").attr("data-firstValue");

    if (username == null || username.toString().trim() == '') {
        UsernameStatus(false);
        $("#spanCurrentUsername").html("<a target='_blank' href='https://galaxypremiere.com/'>www.galaxypremiere.com/</a>");
        return false;
    }

    if (firstValueUsername != $("#txtUsername").val())
        UsernameStatus(true);
    else {
        UsernameStatus(false);
        return false;
    }

    if (username.toString().trim().indexOf(' ') != -1) {
        KingSweetAlert(false, "A blank found.");
        UsernameStatus(false);
        return false;
    }

    if ('qwertyuiopasdfghjklzxcvbnm'.indexOf(username.trim().substring(0, 1).toLowerCase().toString()) == -1) {
        KingSweetAlert(false, "The username must be starting with an alphabet character.");
        UsernameStatus(false);
        return false;
    }

    var characterExceptAlphabets = /[^\w\s]/gi;
    if (characterExceptAlphabets.test(username)) {
        KingSweetAlert(false, "Invalid character(s) found. Only the alphabet and number would be Okay.");
        UsernameStatus(false);
        return false;
    }

    UsernameStatus(true);
    return true;
}
function UsernameStatus(flag) {
    if (flag) {
        $("#btnUpdateUsername").removeClass();
        $("#btnUpdateUsername").addClass("btn btn-primary mb-2");
        $("#btnUpdateUsername").attr('disabled', false);
    } else {
        $("#btnUpdateUsername").removeClass();
        $("#btnUpdateUsername").addClass("btn btn-light mb-2");
        $("#btnUpdateUsername").attr('disabled', 'disabled');
    }
}
function UpdateInfoPassword(pass, rePass, span) {

    var password = $(pass).val();
    if (checkPassMatchRePass(pass, rePass, span)) {

        if (password == null || password.toString().trim() == '') return false;
        pageWaitMe("progress"); // loading process starts
        btnWaitMe_Start('btnUpdatePassword'); // Loading Button Start

        $.ajax({
            contentType: 'application/x-www-form-urlencoded',
            dataType: 'json',
            type: 'POST',
            data: { 'Password': password },
            url: 'MePassword',
            success: function (data) {
                if (data.isSuccess) KingSweetAlert(true, null)
                else KingSweetAlert(false, null);
            },
            error: function (request, status, error) {
                KingSweetAlert(false, null);
            }
        }).always(function () {
            btnWaitMe_Stop('btnUpdatePassword'); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        });
    }
    else {
        KingSweetAlert(false, "Check the password strength and password matches.");
    }

}
function UpdateInfoAccountType(e, type) {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnAccountType0'); // Loading Button Start
    btnWaitMe_Start('btnAccountType1'); // Loading Button Start
    btnWaitMe_Start('btnAccountType2'); // Loading Button Start
    btnWaitMe_Start('btnAccountType3'); // Loading Button Start

    var typeCode;
    switch (type) { //AccountTypeConstants
        case 'FILMMAKER':
            typeCode = 0;
            break;
        case 'DISTRIBUTION':
            typeCode = 1;
            break;
        case 'FESTIVAL':
            typeCode = 2;
            break;
        case 'COMPANY':
            typeCode = 3;
            break;
    }

    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: { 'AccountType': typeCode },
        url: 'MeAccountType',
        success: function (data) {

            if (data.isSuccess) {
                KingSweetAlert(true, null);
                // change styles of buttons
                $("#btnAccountType0").addClass('btn cur-p btn-light');
                $("#btnAccountType0").text('Enable');
                $("#btnAccountType1").addClass('btn cur-p btn-light');
                $("#btnAccountType1").text('Enable');
                $("#btnAccountType2").addClass('btn cur-p btn-light');
                $("#btnAccountType2").text('Enable');
                $("#btnAccountType3").addClass('btn cur-p btn-light');
                $("#btnAccountType3").text('Enable');
                $(e).removeClass();
                $(e).addClass('btn cur-p btn-primary');
                $(e).text('Enabled');
                // end
            }
            else {
                KingSweetAlert(false, null);
            }
        },
        error: function (request, status, error) {
            KingSweetAlert(false, null);
        }
    }).always(function () {
        btnWaitMe_Stop('btnAccountType0'); // Loading Button Stops
        btnWaitMe_Stop('btnAccountType1'); // Loading Button Stops
        btnWaitMe_Stop('btnAccountType2'); // Loading Button Stops
        btnWaitMe_Stop('btnAccountType3'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    });
}
function UpdateInfoBIO() {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateBIO'); // Loading Button Start

    var intro = $("#txtIntroduction").val();
    var bio = $("#txtBIO").val();
    var note = $("#txtNote").val();

    var position = getSelectedItems().toString();
    // lib/kingFuncs/taggers/sellect.js
    // toString() is converting array to string, unless you will be able to get the first item of array

    var postData = {
        'Introduction': intro,
        'BIO': bio,
        'Note': note,
        'Position': position,
    }

    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeBIO',
        success: function (data) {
            if (data.isSuccess) KingSweetAlert(true, null);
            else KingSweetAlert(false, null);
        },
        error: function (request, status, error) {
            KingSweetAlert(false, null);
        }
    }).always(function () {
        btnWaitMe_Stop('btnUpdateBIO'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    });
}
/*@* Upload Js *@*/
var dropzoneavatar = $("#dropzoneAvatar");
var dropzoneheader = $("#dropzoneHeader");
var inputavatar = dropzoneavatar.find('input');
var inputheader = dropzoneheader.find('input');
dropzoneavatar.on({
    dragenter: draginavatar,
    dragleave: dragoutavatar
});
dropzoneheader.on({
    dragenter: dragindropzoneheader,
    dragleave: dragoutdropzoneheader
});
inputavatar.on('change', dropavatar);
inputheader.on('change', dropheader);
// show or hide [CHANGE] label while hovering
$(dropzoneavatar).hover(
    function () {
        $("#HeadshotChangePhoto").css("display", "inline");
        dropzoneavatar.css("opacity", "0.5")
    }, function () {
        $(this).find("#HeadshotChangePhoto").css("display", "none");
        dropzoneavatar.css("opacity", "1")
    }
);
$(dropzoneheader).hover(
    function () {
        $("#HeaderChangePhoto").css("display", "inline");
        dropzoneheader.css("opacity", "0.5")
    }, function () {
        $(this).find("#HeaderChangePhoto").css("display", "none");
        dropzoneheader.css("opacity", "1")
    }
);
function draginavatar(e) { //function for drag into element, just turns the bix X white
    $(dropzoneavatar).addClass('hover');
    $("#HeadshotChangePhoto").css("display", "inline");
    dropzoneavatar.css("opacity", "0.5")
}
function dragindropzoneheader(e) { //function for drag into element, just turns the bix X white
    $(dropzoneheader).addClass('hover');
    $("#HeaderChangePhoto").css("display", "inline");
    dropzoneheader.css("opacity", "0.5")
}

function dragoutavatar(e) { //function for dragging out of element
    $(dropzoneavatar).removeClass('hover');
    $(this).find("#HeadshotChangePhoto").css("display", "none");
    dropzoneavatar.css("opacity", "1")
}
function dragoutdropzoneheader(e) { //function for dragging out of element
    $(dropzoneheader).removeClass('hover');
    $(this).find("#HeaderChangePhoto").css("display", "none");
    dropzoneheader.css("opacity", "1")
}
function dropavatar(e) {
    var file = this.files[0];
    // the following functions uses (fileextensionsize.js)
    if (KingCheckSizeExtension(file, ["jpg", "png", "bmp", "jpeg"], "2097152", true)) { // => 2 Mb // NOTE: If you want to change this value you will have to change the same value in (UpdateUsersInformationHeadshotService.cs) and (UploadSmallFilesService.cs)
        // ////////////////////////// Loaders
        $("#HeadshotLoader").css("display", "table-cell"); // circle loading on photo
        $("#dropzoneAvatar *").attr("disabled", "disabled").off('click'); // disable clickable 
        $("#dropzoneAvatar *").css({ // clear ...
            cursor: "wait",
            opacity: "0.6",
        });
        $("#filedropzoneAvatar").css("opacity", "0");
        pageWaitMe("progress"); // loading process starts
        //////////////////////////////
        // upload file here
        var postData = new FormData();
        postData.append("File", file);
        $.ajax({
            contentType: false,
            processData: false,
            type: 'POST',
            data: postData,
            url: 'MeHeadshot',
            success: function (data) {
                //////////////////////////// Loaders
                $("#HeadshotLoader").css("display", "none"); // circle loading on photo
                $("#dropzoneAvatar *").attr("disabled", false).off('click'); // enable clickable                 
                $("#dropzoneAvatar *").css({ // clear ...
                    opacity: "1",
                    cursor: "pointer",
                });
                $("#filedropzoneAvatar").css("opacity", "0");
                //////////////////////////////
                $('#dropzoneAvatar').removeClass('hover').addClass('dropped').find('img').remove();
                $('#filedropzoneAvatar').val('');
                $("#dropzoneAvatar").css("background-image", "none");
                showfileavatar(file); // showing file for demonstration ...
                if (data.isSuccess) KingSweetAlert(true, null);
                else KingSweetAlert(false, null);
            },
            error: function (req, res, err) {
                KingSweetAlert(false, null);
            }
        }).always(function () {
            pageWaitMeRemove(); // loading process stops
        });
    }
}
function dropheader(e) {
    var file = this.files[0];
    // the following functions uses (fileextensionsize.js)
    if (KingCheckSizeExtension(file, ["jpg", "png", "bmp", "jpeg"], "5242880", true)) { // => 5 Mb // NOTE: If you want to change this value you will have to change the same value in (UpdateUsersInformationHeadertService.cs) and (UploadSmallFilesService.cs)
        // ////////////////////////// Loaders
        $("#HeaderLoader").css("display", "table-cell"); // circle loading on photo
        $("#dropzoneHeader *").attr("disabled", "disabled").off('click'); // disable clickable 
        $("#dropzoneHeader *").css({ // clear ...
            cursor: "wait",
            opacity: "0.6",
        });
        $("#filedropzoneHeader").css("opacity", "0");
        pageWaitMe("progress"); // loading process starts
        //////////////////////////////
        // upload file here
        var postData = new FormData();
        postData.append("File", file);
        $.ajax({
            contentType: false,
            processData: false,
            type: 'POST',
            data: postData,
            url: 'MeHeader',
            success: function (data) {
                //////////////////////////// Loaders
                $("#HeaderLoader").css("display", "none"); // circle loading on photo
                $("#dropzoneHeader *").attr("disabled", false).off('click'); // enable clickable 
                $("#dropzoneHeader *").css({ // clear ...
                    opacity: "1",
                    cursor: "pointer",
                });
                $("#filedropzoneHeader").css("opacity", "0");
                //////////////////////////////
                $('#dropzoneHeader').removeClass('hover').addClass('dropped').find('img').remove();
                showfileheader(file); // showing file for demonstration ...
                if (data.isSuccess) KingSweetAlert(true, null);
                else KingSweetAlert(false, null);
            },
            error: function (req, res, err) {
                KingSweetAlert(false, null);
            }
        }).always(function () {
            pageWaitMeRemove(); // loading process stops
        });
    }
}
function showfileavatar(file) {
    var reader = new FileReader(file);
    reader.readAsDataURL(file);
    reader.onload = function (e) {
        $('#dropzoneAvatar div:not(#HeadshotLoader):not(#HeadshotChangePhoto)').html($('<img />').attr('src', e.target.result).fadeIn());
    }
}
function showfileheader(file) {
    $("#dropzoneHeader").css("background", "url('" + URL.createObjectURL(file) + "') center/cover");
}
// End of Upload Js
function openDialougePostPosition() {
    Swal.fire({
        title: "Enter your suggested position title:",
        input: "text",
        inputAttributes: {
            autocapitalize: "off"
        },
        showCancelButton: true,
        confirmButtonText: "Suggest",
        showLoaderOnConfirm: true,
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            pageWaitMe("progress"); // loading process starts
            var postData = { 'Position': result.value };
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: 'POST',
                data: postData,
                url: 'MePositions',
                success: function (data) {
                    if (data.isSuccess) KingSweetAlert(true, null);
                    else KingSweetAlert(false, data.message);
                },
                error: function (res, req, err) {
                    KingSweetAlert(false, null);
                }
            }).always(function () {
                pageWaitMeRemove(); // loading process stops
            });
        }
    });
}
$(document).ready(function () {
    // set stored value of timezone & currency
    var timezone = $('#select_timezone').attr("data-seletedItem");
    var currency = $('#select_currency').attr("data-seletedItem");
    $('#select_timezone').val(timezone);
    $('#select_currency').val(currency);
    // set default value of iconCurrentUsername
    var input = $("#txtUsername").val();
    if (input == '') {
        $("#iconCurrentUsername").removeClass();
        $("#iconCurrentUsername").addClass("fa-solid fa-hourglass colorGray");
    } else {
        $("#iconCurrentUsername").removeClass();
        $("#iconCurrentUsername").addClass("fa-solid fa-check-double colorGreen");
        $("#btnUpdateUsername").attr('disabled', 'disabled');
    }
    // Triggers
    //--------------- Account Section    
    $('body').on('keypress', '#txtFirstname', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateAccount").trigger("click");
    });
    $('body').on('keypress', '#txtMiddlename', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateAccount").trigger("click");
    });
    $('body').on('keypress', '#txtSurname', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateAccount").trigger("click");
    });
    $('body').on('keypress', '#txtBirthcity', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateAccount").trigger("click");
    });
    $('body').on('keypress', '#txtCurrentCity', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateAccount").trigger("click");
    });
    //--------------- Contact Section
    $('body').on('keypress', '#txtAddress1', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtAddress2', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtCity', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtState', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtPostalCode', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtPhone', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtRecoveryEmail', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtWebsite', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtFacebook', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtInstagram', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtTwitter', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtStage32', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtYoutube', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtLinkden', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtVimeo', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    $('body').on('keypress', '#txtIMDb', function (evn) {
        if (evn.keyCode == 13)
            $("#btnUpdateContact").trigger("click");
    });
    //End Triggers    
    // when the user does not have a unique unsername and tries to open www.galaxypremiere.com/username
    var queryString = window.location.search; // Get the query string from the current URL Process
    var params = new URLSearchParams(queryString);
    var parameterValue = params.get('tour');
    if (parameterValue == "username") {
        tabNavigationByTabName('TabUserPrivacy', 4);
        $(".bubble").css("display", "block");
    }
    // end
});
function UpdateOther() {
    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateOther'); // Loading Button Start    
    var timezone = $("#select_timezone").val();
    var currency = $("#select_currency").val();
    var postData = {
        'TimeZoneId': timezone,
        'CurrencyId': currency
    }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeOther',
        success: function (data) {
            if (data.isSuccess) KingSweetAlert(true, null);
            else KingSweetAlert(false, null);
        },
        error: function (request, status, error) {
            KingSweetAlert(false, null);
        }
    }).always(function () {
        btnWaitMe_Stop('btnUpdateOther'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    });
}
// SWEET ALERT FUNCTION
function KingSweetAlert(type, message) {

    if (type) { // success
        if (message == null) message = "Information Has Been Updated Successfully."
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });
        Toast.fire({
            icon: "success",
            title: message
        });
    } else { // error
        if (message == null) message = "Something Went Wrong."
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 5000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });
        Toast.fire({
            icon: "error",
            title: message
        });
    }
}
// Close the bubble is supposed to be shown on the "username" field
function closeBubble() {
    var bubble = document.getElementById("bubble");
    bubble.style.display = "none";
}