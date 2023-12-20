
function UpdateInfoAccount() {
    var firstname = $('#txtFirstname').val();
    var middlename = $('#txtMiddlename').val();
    var surname = $('#txtSurname').val();
    var genderId = $('#selectGender').val();
    var countryId = $('#selectCountry').val();
    var languageId = $('#selectLanguage').val();
    var birthday = $('#datepickerBirthday').val();
    var birthcity = $('#txtBirthcity').val();
    var currentCity = $('#txtCurrentCity').val();

    var postData = {
        'Firstname': firstname,
        'MiddleName': middlename,
        'Surname': surname,
        'Gender': genderId,
        'CountryId': countryId,
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
            Swal.fire(data.message);
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function UpdateInfoContact() {
    var address1 = $('#txtAddress1').val();
    var address2 = $('#txtAddress2').val();
    var city = $('#txtCity').val();
    var state = $('#txtState').val();
    var postalCode = $('#txtPostalCode').val();
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
            Swal.fire(data.message);
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function UpdateInfoPrivacy(e, privacy) {
    var postData = {
        'Privacy': privacy
    }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MePrivacy',
        success: function (data) {

            // change styles of buttons
            $("#btnPrivacy0").addClass('btn cur-p btn-light');
            $("#btnPrivacy1").addClass('btn cur-p btn-light');
            $("#btnPrivacy2").addClass('btn cur-p btn-light');
            $(e).removeClass();
            $(e).addClass('btn cur-p btn-primary');
            // end

            Swal.fire(data.message);
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function UpdateInfoUsername() {
    var username = $("#txtUsername").val();
    var postData = {
        'username': username,
    };
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeUsername',
        success: function (data) {
            if (data.isSuccess) {
                Swal.fire(data.message);
            } else {
                var check = data.data.status;
                switch (check) {
                    case 0:
                        //duplicated!
                        Swal.fire(data.message);
                        break;
                    case 2:
                        //user did not find
                        Swal.fire(data.message);
                        break;
                }
            }
        },
        error: function (request, status, error) {
            alert('err: ' + request.responseText);
        }
    });
}
function ChangeRuntimeUsername(e) {

    var input = $("#txtUsername").val();
    $("#spanCurrentUsername").html("<a target='_blank' href='https://galaxypremiere.com/" + input + "'>www.galaxypremiere.com/" + input + "</a>");

    var postData = {
        'Username': input,
    };
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
            alert('err: ' + request.responseText);
        }
    });
}
function UpdateInfoPassword() {

    var password = $("#txtPassword").val();
    var postData = {
        'Password': password
    }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MePassword',
        success: function (data) {
            Swal.fire(data.message);
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function UpdateInfoAccountType(e, type) {

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
    }
    var postData = {
        'AccountType': typeCode,
    }

    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'MeAccountType',
        success: function (data) {

            // change styles of buttons
            $("#btnAccountType0").addClass('btn cur-p btn-light');
            $("#btnAccountType0").text('Enable');
            $("#btnAccountType1").addClass('btn cur-p btn-light');
            $("#btnAccountType1").text('Enable');
            $("#btnAccountType2").addClass('btn cur-p btn-light');
            $("#btnAccountType2").text('Enable');
            $(e).removeClass();
            $(e).addClass('btn cur-p btn-primary');
            $(e).text('Enabled');
            // end

            Swal.fire(data.message);
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
function UpdateInfoBIO() {

    var intro = $("#txtIntroduction").val();
    var bio = $("#txtBIO").val();
    var note = $("#txtNote").val();
    var position = getSelectedItems().toString(); // toString() is converting array to string, unless you will be able to get the first item of array

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
            Swal.fire(data.message);
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}
// set default value of iconCurrentUsername
$(document).ready(function () {
    var input = $("#txtUsername").val();
    if (input == '') {
        $("#iconCurrentUsername").removeClass();
        $("#iconCurrentUsername").addClass("fa-solid fa-hourglass colorGray");
    } else {
        $("#iconCurrentUsername").removeClass();
        $("#iconCurrentUsername").addClass("fa-solid fa-check-double colorGreen");
    }
});
/*@* Tabs *@*/
function userAccountNavigation(evt, tabName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("TabUserTabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(tabName).style.display = "block";
    //alert(evt.currentTarget.className);
    evt.currentTarget.className += " active";
}
document.getElementById("TabUserAccountDefaultOpen").click();
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
        dropzoneavatar.css("opacity","0.5")
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
}
function dragindropzoneheader(e) { //function for drag into element, just turns the bix X white
    $(dropzoneheader).addClass('hover');
}

function dragoutavatar(e) { //function for dragging out of element
    $(dropzoneavatar).removeClass('hover');
}
function dragoutdropzoneheader(e) { //function for dragging out of element
    $(dropzoneheader).removeClass('hover');
}

function dropavatar(e) {
    var file = this.files[0];
    // the following functions uses (fileextensionsize.js)
    if (checkSizeExtension(file, ["jpg", "png", "bmp", "jpeg"], "2097152")) { // => 2 Mb // NOTE: If you want to change this value you will have to change the same value in (UpdateUsersInformationHeadshotService.cs) and (UploadSmallFilesService.cs)
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
                pageWaitMeRemove(); // loading process stops
                //////////////////////////////
                $('#dropzoneAvatar').removeClass('hover').addClass('dropped').find('img').remove();
                $('#filedropzoneAvatar').val('');
                $("#dropzoneAvatar").css("background-image", "none");
                showfileavatar(file); // showing file for demonstration ...
                Swal.fire(data.message);
            },
            error: function (req, res, err) {
                alert('req' + req.responseText + 'res:' + res + 'err:' + err);
            }
        });
    }
}

function dropheader(e) {
    var file = this.files[0];
    // the following functions uses (fileextensionsize.js)
    if (checkSizeExtension(file, ["jpg", "png", "bmp", "jpeg"], "5242880")) { // => 5 Mb // NOTE: If you want to change this value you will have to change the same value in (UpdateUsersInformationHeadertService.cs) and (UploadSmallFilesService.cs)
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
                pageWaitMeRemove(); // loading process stops
                //////////////////////////////
                $('#dropzoneHeader').removeClass('hover').addClass('dropped').find('img').remove();
                showfileheader(file); // showing file for demonstration ...
                Swal.fire(data.message);
            },
            error: function (req, res, err) {
                alert('req' + req.responseText + 'res:' + res + 'err:' + err);
            }
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
