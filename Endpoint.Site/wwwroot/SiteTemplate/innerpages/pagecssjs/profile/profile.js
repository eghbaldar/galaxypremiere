// Educations
function GetProfileEducationElements() {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateProfileEducations'); // Loading Button Start

    var Id;
    var hiddenId;
    var schoolName;
    var fieldlName;
    var dateFrom;
    var dateTo;
    var postData = [];
    var success = true;

    var inputValues = $('.form_field_outer :input').map(function () {

        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id");

        if (type == "hidden") {
            if (id.indexOf("hiddenEducationalCase") == 0) Id = value;
            hiddenId = id;
        }
        if (type == "text") {
            if (value.trim() == '') {
                KingWarningStyle("#" + id, 0);
                success = false;
            }
            else
                KingWarningStyleOff("#" + id, 0);
            if (id.indexOf("txtSchoolName") == 0) schoolName = value;
            if (id.indexOf("txtField") == 0) fieldlName = value;
            if (id.indexOf("datepickerFrom") == 0) dateFrom = value;
            if (id.indexOf("datepickerTo") == 0) dateTo = value;
        }

        if (type == "button" && id.indexOf("btnRemoveNodeBtnFrmField") == 0) {
            postData.push(Id + "|" + schoolName + "|" + fieldlName + "|" + dateFrom + "|" + dateTo + "|" + hiddenId);
        }
    });

    if (success) {
        PostProfileEducation(postData)
    }
    else {
        btnWaitMe_Stop('btnUpdateProfileEducations'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    }
}
function PostProfileEducation(data) {
    var postData = { 'info': data, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileEducationPost',
        success: function (data) {
            if (data.isSuccess) {
                // set VALUE of HIDDEN CONTROLS with new value from database (value = ID of new record after inserting)
                // the new ID is stored in "data.message"
                // why must we set the new value for HIDDEN CONTROL?
                // because otherwise in the way of adding dynamic form, the system can not recognize the record ID to delete it.
                var flag = true;
                var arr = data.message.split(/\r?\n/);
                for (let i = 0; i < arr.length; i++) {
                    if (arr[i].length != 0) {
                        var arr2 = arr[i].replace('[', '').replace(']', '').split(',');
                        $('#' + arr2[0]).val(arr2[1]);
                    }
                }
                // setting process is done!
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
                    title: "Information Has Been Updated Successfully."
                });
                btnWaitMe_Stop('btnUpdateProfileEducations'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
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
                    title: data.message
                });
                btnWaitMe_Stop('btnUpdateProfileEducations'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            });
            btnWaitMe_Stop('btnUpdateProfileEducations'); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
function DeleteProfileEducation(e) {
    pageWaitMe("progress"); // loading process starts
    // find ID of hiddenControl based on ID of DeleteControl
    var SplitedId = e.id.split('_');
    var ID_FOR_DELETE;
    var inputValues = $('.form_field_outer :input').map(function () {
        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id").split('_');
        if (type == "hidden") {
            if (id[1] == SplitedId[1]) {
                ID_FOR_DELETE = $("#hiddenEducationalCase_" + id[1]).val();
            }
        }
    });

    var postData = { 'Id': ID_FOR_DELETE, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileEducationDelete',
        success: function (data) {
            if (data.isSuccess) {
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
                    title: "Information Has Been Deleted Successfully."
                });
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            });
            btnWaitMe_Stop(e.id); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
// Favorite Movies
function GetProfileFavoriteMoviesElements() {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateProfileFavoriteMovies'); // Loading Button Start

    var Id;
    var IMDbLink;
    var hiddenId;
    var postData = [];
    var success = true;

    var inputValues = $('.form_field_outer_favoriteMovie :input').map(function () {

        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id");

        if (type == "hidden") {
            if (id.indexOf("hiddenFavoriteMovie") == 0) Id = value;
            hiddenId = id;
        }
        if (type == "text") {
            if (value.trim() == '') {
                KingWarningStyle("#" + id, 0);
                success = false;
            }
            else
                KingWarningStyleOff("#" + id, 0);

            //CHECL THE VALIDATION OF LINK
            if (id.indexOf("txtMovieLink") == 0)
                if (KingIsUrlValidWithDomain(value, "https://www.imdb.com/")) {
                    IMDbLink = value;
                }
                else {
                    KingWarningStyle("#" + id, 0);
                    success = false;
                }

        }
        if (type == "button" && id.indexOf("btnRemoveNodeBtnFrmFieldFavoriteMovie") == 0) {
            postData.push(Id + "|" + IMDbLink + "|" + hiddenId);
        }
    });
    if (success) {
        Swal.fire({
            title: 'Please Wait !',
            html: 'Given your number of links, it may take a long time!',
            allowEscapeKey: false,
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading()
            }
        });
        PostProfileFavoriteMovies(postData);
    }
    else {
        btnWaitMe_Stop('btnUpdateProfileFavoriteMovies'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    }
}
function PostProfileFavoriteMovies(data) {
    var postData = { 'info': data, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileFavoriteMoviesPost',
        success: function (data) {
            if (data.isSuccess) {
                // set VALUE of HIDDEN CONTROLS with new value from database (value = ID of new record after inserting)
                // the new ID is stored in "data.message"
                // why must we set the new value for HIDDEN CONTROL?
                // because otherwise in the way of adding dynamic form, the system can not recognize the record ID to delete it.
                var flag = true;
                var arr = data.message.split(/\r?\n/);
                for (let i = 0; i < arr.length; i++) {
                    if (arr[i].length != 0) {
                        var arr2 = arr[i].replace('[', '').replace(']', '').split(',');
                        if (arr2[1].trim() != "false") {
                            $('#' + arr2[0]).val(arr2[1]);
                        }
                        else {
                            KingWarningStyle('#txtMovieLink_' + arr2[0].trim(), 0);
                            flag = false;
                        }
                    }
                }
                // setting process is done!
                if (flag) {
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
                        title: "Information Has Been Updated Successfully."
                    });
                }
                else {
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
                        title: "There is no movie in the link, check your link out.",
                    });
                }
                btnWaitMe_Stop('btnUpdateProfileFavoriteMovies'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
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
                    title: data.message
                });
                btnWaitMe_Stop('btnUpdateProfileFavoriteMovies'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            });
            btnWaitMe_Stop('btnUpdateProfileFavoriteMovies'); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });

}
function DeleteProfileFavoriteMovies(e) {
    pageWaitMe("progress"); // loading process starts
    // find ID of hiddenControl based on ID of DeleteControl
    var SplitedId = e.id.split('_');
    var ID_FOR_DELETE;
    var inputValues = $('.form_field_outer_favoriteMovie :input').map(function () {
        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id").split('_');
        if (type == "hidden") {
            if (id[1] == SplitedId[1]) {
                ID_FOR_DELETE = $("#hiddenFavoriteMovie_" + id[1]).val();
            }
        }
    });

    var postData = { 'Id': ID_FOR_DELETE, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileFavoriteMovieDelete',
        success: function (data) {
            if (data.isSuccess) {
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
                    title: "Information Has Been Deleted Successfully."
                });
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
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
                    title: data.message,
                });
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            });
            btnWaitMe_Stop(e.id); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
function checkRuntimeValidationUrlIMDb(e) {
    if (KingIsUrlValidWithDomain($(e).val(), "https://www.imdb.com/")) {
        KingWarningStyleOff("#" + e.id, 0);
        return true;
    } else {
        pageWaitMeRemove(); // loading process stops
        KingWarningStyle("#" + e.id, 0);
        return false;
    }
}
function CheckTheLink(e, link) {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start(e.id); // Loading Button Start
    var postData = { 'info': link, }
    link = $('#' + link).val();
    ///////////////// CHECL THE VALIDATION OF LINK
    var SeparateID = e.id.split('_');
    if ($("#txtMovieLink_" + SeparateID[1]).val() == null || $("#txtMovieLink_" + SeparateID[1]).val() == '') {
        btnWaitMe_Stop(e.id); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
        KingWarningStyle("#txtMovieLink_" + SeparateID[1], 0);
        return;
    }
    if (!KingIsUrlValidWithDomain(link, "https://www.imdb.com/")) { // if the link does not match with the exact hostname=> "https://www.imdb.com/"
        KingWarningStyle("#txtMovieLink_" + SeparateID[1], 0);
        btnWaitMe_Stop(e.id); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
        return;
    }
    ///////////////// End
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        data: { 'link': link },
        type: 'GET',
        url: 'GetMetaInfo',
        success: function (data) {

            if (data.isSuccess) {
                var doc = new DOMParser().parseFromString(data.message, 'text/html');

                var meta_img = doc.querySelector('meta[property="og:image"]');
                var value_img = meta_img && meta_img.getAttribute('content');

                var meta_title = doc.querySelector('meta[property="og:title"]');
                var value_title = meta_title && meta_title.getAttribute('content');

                Swal.fire({
                    title: "<strong>" + value_title + "</strong>",
                    html: "<strong>" + "<img src='" + value_img + "' width='100%;'/>" + "</u></strong>",
                    showCloseButton: false,
                    showCancelButton: false,
                    focusConfirm: false,
                    confirmButtonText: '<i class="fa fa-thumbs-up"></i>' + 'Yes, Thats Correct!'
                });
                KingWarningStyleOff("#txtMovieLink_" + SeparateID[1], 0);
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops

                return true;
            } else {
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
                    title: data.message
                });
                KingWarningStyle("#txtMovieLink_" + SeparateID[1], 0);
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops

                return false;
            }

        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            });
            btnWaitMe_Stop(e.id); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
            return false;
        }
    });

}
// Companies
function GetProfileCompanyElements() {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateProfileCompanies'); // Loading Button Start

    var Id, hiddenId;

    var countryId, Name, Position, dateFrom, dateTo, Address1, Address2, City, State, PostalCode;
    var Phone, RecoveryEmail, Website, Facebook, Instagram, Twitter, Stage32, Youtube, Linkden, Vimeo, Imdb;

    var postData = [];
    var successCompanyCountryId = 0,countCompanyCountry = 0;
    var successCompanyName = 0, countCompanyName = 0;
    var successCompanyPosition = 0, countCompanyPosition = 0;
    var successCompanyFrom = 0, countCompanyFrom = 0;
    var successCompanyTo = 0, countCompanyTo = 0;

    var inputValues = $('.form_field_outer_companies :input').map(function () {
        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id");

        if (type == "hidden") {
            if (id.indexOf("hiddenCompany") == 0) {
                Id = value;
                hiddenId = id;
            }
        }
        if (type == "select-one") {
            countCompanyCountry += 1;
            if (value == 'Choose...') {
                KingWarningStyle("#" + id, 0);
                successCompanyCountryId -= 1;
            }
            else {
                KingWarningStyleOff("#" + id, 0);
                countryId = value;
                successCompanyCountryId += 1;
            }
        }
        if (type == "text") {

            if ((id.indexOf("txtCompanyName") == 0)) {
                countCompanyName += 1;
                if (value.trim() == '') {
                    KingWarningStyle("#" + id, 0);
                    successCompanyName -= 1;
                } else {
                    Name = value;
                    KingWarningStyleOff("#" + id, 0);
                    successCompanyName += 1;
                }
            }
            if ((id.indexOf("txtCompanyPosition") == 0)) {
                countCompanyPosition += 1;
                if (value.trim() == '') {
                    KingWarningStyle("#" + id, 0);
                    successCompanyPosition -= 1;
                } else {
                    Position = value;
                    KingWarningStyleOff("#" + id, 0);
                    successCompanyPosition += 1;
                }
            }
            if ((id.indexOf("datepickerCompanyFrom") == 0)) {
                countCompanyFrom += 1;
                if (value.trim() == '') {
                    KingWarningStyle("#" + id, 0);
                    successCompanyFrom -= 1;
                } else {
                    dateFrom = value;
                    KingWarningStyleOff("#" + id, 0);
                    successCompanyFrom += 1;
                }
            }
            if ((id.indexOf("datepickerCompanyTo") == 0)) {
                countCompanyTo += 1;
                if (value.trim() == '') {
                    KingWarningStyle("#" + id, 0);
                    successCompanyTo -= 1;
                } else {
                    dateTo = value;
                    KingWarningStyleOff("#" + id, 0);
                    successCompanyTo += 1;
                }
            }

            if (id.indexOf("txtCompanyAddress1") == 0) Address1 = value;
            if (id.indexOf("txtCompanyAddress2") == 0) Address2 = value;
            if (id.indexOf("txtCompanyCity") == 0) City = value;
            if (id.indexOf("txtCompanyState") == 0) State = value;
            if (id.indexOf("txtCompanyPostCode") == 0) PostalCode = value;
            if (id.indexOf("txtCompanyPhone") == 0) Phone = value;
            if (id.indexOf("txtCompanyEmail") == 0) RecoveryEmail = value;
            if (id.indexOf("txtCompanyWebsite") == 0) Website = value;
            if (id.indexOf("txtCompanyFacebook") == 0) Facebook = value;
            if (id.indexOf("txtCompanyInstagram") == 0) Instagram = value;
            if (id.indexOf("txtCompanyTwitter") == 0) Twitter = value;
            if (id.indexOf("txtCompanyStage32") == 0) Stage32 = value;
            if (id.indexOf("txtCompanyYoutube") == 0) Youtube = value;
            if (id.indexOf("txtCompanyLinkden") == 0) Linkden = value;
            if (id.indexOf("txtCompanyVimeo") == 0) Vimeo = value;
            if (id.indexOf("txtCompanyIMDb") == 0) Imdb = value;
        }
        if (type == "button" && id.indexOf("btnRemoveNodeBtnFrmFieldCompany") == 0) {
            postData.push(Id + "|" + countryId + "|" + Name + "|" + Position + "|" + dateFrom + "|" + dateTo + "|" + Address1 + "|" + Address2 + "|" + City + "|" + State + "|" + PostalCode + "|" + Phone + "|" + RecoveryEmail + "|" + Website + "|" + Facebook + "|" + Instagram + "|" + Twitter + "|" + Stage32 + "|" + Youtube + "|" + Linkden + "|" + Vimeo + "|" + Imdb + "|" + hiddenId);
        }
    });

    if ((successCompanyCountryId == countCompanyCountry) &&
        (successCompanyName == countCompanyName) &&
        (successCompanyPosition == countCompanyPosition) &&
        (successCompanyFrom == countCompanyFrom) &&
        (successCompanyTo == countCompanyTo)) {
        Swal.fire({
            title: 'Please Wait !',
            html: 'Given your number of cases, it may take a long time!',
            allowEscapeKey: false,
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading()
            }
        });
        PostProfileCompany(postData)
    }
    else {
        btnWaitMe_Stop('btnUpdateProfileCompanies'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    }
}
function PostProfileCompany(data) {
    var postData = { 'info': data, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileCompanyPost',
        success: function (data) {
            if (data.isSuccess) {
                // set VALUE of HIDDEN CONTROLS with new value from database (value = ID of new record after inserting)
                // the new ID is stored in "data.message"
                // why must we set the new value for HIDDEN CONTROL?
                // because otherwise in the way of adding dynamic form, the system can not recognize the record ID to delete it.
                var flag = true;
                var arr = data.message.split(/\r?\n/);
                for (let i = 0; i < arr.length; i++) {
                    if (arr[i].length != 0) {
                        var arr2 = arr[i].replace('[', '').replace(']', '').split(',');
                        $('#' + arr2[0]).val(arr2[1]);
                    }
                }
                // setting process is done!
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
                    title: "Information Has Been Updated Successfully."
                });
                btnWaitMe_Stop('btnUpdateProfileCompanies'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
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
                    title: data.message,
                });
                btnWaitMe_Stop('btnUpdateProfileCompanies'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            }); 
            btnWaitMe_Stop('btnUpdateProfileCompanies'); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
function DeleteProfileCompany(e) {
    pageWaitMe("progress"); // loading process starts
    //find ID of hiddenControl based on ID of DeleteControl
    var SplitedId = e.id.split('_');
    var ID_FOR_DELETE;
    var inputValues = $('.form_field_outer_companies :input').map(function () {
        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id").split('_');
        if (type == "hidden") {
            if (id[1] == SplitedId[1]) {
                ID_FOR_DELETE = $("#hiddenCompany_" + id[1]).val();
            }
        }
    });
    var postData = { 'Id': ID_FOR_DELETE, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileCompanyDelete',
        success: function (data) {
            if (data.isSuccess) {
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
                    title: "Information Has Been Deleted Successfully."
                });
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            });
            btnWaitMe_Stop(e.id); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
$(document).keydown(function (event) {
    // close all companies MODAL by hitting escape key
    if (event.keyCode == 27) {
        $('.modal').modal('hide');
    }
});
// News
function GetProfileNewsElements() {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateProfileNews'); // Loading Button Start

    var Id;
    var hiddenId;
    var title;
    var reference;
    var link;
    var date;
    var postData = [];
    var success = true;

    var inputValues = $('.form_field_outer_news :input').map(function () {

        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id");

        if (type == "hidden") {
            if (id.indexOf("hiddenNews") == 0) Id = value;
            hiddenId = id;
        }
        if (type == "text") {
            if (value.trim() == '') {
                KingWarningStyle("#" + id, 0);
                success = false;
            }
            else
                KingWarningStyleOff("#" + id, 0);
            if (id.indexOf("txtNewsTitle") == 0) title = value;
            if (id.indexOf("txtNewsReference") == 0) reference = value;

            if (id.indexOf("txtNewsLink") == 0) {
                if (KingIsUrlValidWithoutDomain(value)) {
                    link = value;
                }
                else {
                    KingWarningStyle("#" + id, 0);
                    success = false;
                }
            }

            if (id.indexOf("datepickerNewsDate") == 0) date = value;
        }

        if (type == "button" && id.indexOf("btnRemoveNodeBtnFrmFieldNews") == 0) {
            postData.push(Id + "|" + title + "|" + reference + "|" + link + "|" + date + "|" + hiddenId);
        }
    });

    if (success) {
        PostProfileNews(postData)
    }
    else {
        btnWaitMe_Stop('btnUpdateProfileNews'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    }
}
function PostProfileNews(data) {
    var postData = { 'info': data, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileNewsPost',
        success: function (data) {
            if (data.isSuccess) {
                // set VALUE of HIDDEN CONTROLS with new value from database (value = ID of new record after inserting)
                // the new ID is stored in "data.message"
                // why must we set the new value for HIDDEN CONTROL?
                // because otherwise in the way of adding dynamic form, the system can not recognize the record ID to delete it.
                var flag = true;
                var arr = data.message.split(/\r?\n/);
                for (let i = 0; i < arr.length; i++) {
                    if (arr[i].length != 0) {
                        var arr2 = arr[i].replace('[', '').replace(']', '').split(',');
                        $('#' + arr2[0]).val(arr2[1]);
                    }
                }
                // setting process is done!
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
                    title: "Information Has Been Updated Successfully."
                });
                btnWaitMe_Stop('btnUpdateProfileNews'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
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
                    title: "Something Went Wrong."
                }); 
                btnWaitMe_Stop('btnUpdateProfileNews'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            }); 
            btnWaitMe_Stop('btnUpdateProfileNews'); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
function DeleteProfileNews(e) {
    pageWaitMe("progress"); // loading process starts
    // find ID of hiddenControl based on ID of DeleteControl
    var SplitedId = e.id.split('_');
    var ID_FOR_DELETE;
    var inputValues = $('.form_field_outer_news :input').map(function () {
        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id").split('_');
        if (type == "hidden") {
            if (id[1] == SplitedId[1]) {
                ID_FOR_DELETE = $("#hiddenNews_" + id[1]).val();
            }
        }
    });
    var postData = { 'Id': ID_FOR_DELETE, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileNewsDelete',
        success: function (data) {
            if (data.isSuccess) {
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
                    title: "Information Has Been Deleted Successfully."
                });
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            }); 
            btnWaitMe_Stop(e.id); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
// Link
function GetProfileLinksElements() {

    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start('btnUpdateProfileLinks'); // Loading Button Start

    var Id;
    var hiddenId;
    var title;
    var link;
    var postData = [];
    var success = true;

    var inputValues = $('.form_field_outer_links :input').map(function () {

        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id");

        if (type == "hidden") {
            if (id.indexOf("hiddenLinks") == 0) Id = value;
            hiddenId = id;
        }
        if (type == "text") {
            if (value.trim() == '') {
                KingWarningStyle("#" + id, 0);
                success = false;
            }
            else
                KingWarningStyleOff("#" + id, 0);

            if (id.indexOf("txtLinkTitle") == 0) title = value;
            if (id.indexOf("txtLinkLink") == 0) {
                if (KingIsUrlValidWithoutDomain(value)) {
                    link = value;
                }
                else {
                    KingWarningStyle("#" + id, 0);
                    success = false;
                }
            }
        }
        if (type == "button" && id.indexOf("btnRemoveNodeBtnFrmFieldLinks") == 0) {
            postData.push(Id + "|" + title + "|" + link + "|" + hiddenId);
        }
    });

    if (success) {
        PostProfileLinks(postData)
    }
    else {
        btnWaitMe_Stop('btnUpdateProfileLinks'); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
    }
}
function PostProfileLinks(data) {
    var postData = { 'info': data, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileLinksPost',
        success: function (data) {
            if (data.isSuccess) {
                // set VALUE of HIDDEN CONTROLS with new value from database (value = ID of new record after inserting)
                // the new ID is stored in "data.message"
                // why must we set the new value for HIDDEN CONTROL?
                // because otherwise in the way of adding dynamic form, the system can not recognize the record ID to delete it.
                var flag = true;
                var arr = data.message.split(/\r?\n/);
                for (let i = 0; i < arr.length; i++) {
                    if (arr[i].length != 0) {
                        var arr2 = arr[i].replace('[', '').replace(']', '').split(',');
                        $('#' + arr2[0]).val(arr2[1]);
                    }
                }
                // setting process is done!
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
                    title: "Information Has Been Updated Successfully."
                });
                btnWaitMe_Stop('btnUpdateProfileLinks'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
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
                    title: "Something Went Wrong."
                }); 
                btnWaitMe_Stop('btnUpdateProfileLinks'); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            }); 
            btnWaitMe_Stop('btnUpdateProfileLinks'); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
function DeleteProfileLinks(e) {
    pageWaitMe("progress"); // loading process starts
    // find ID of hiddenControl based on ID of DeleteControl
    var SplitedId = e.id.split('_');
    var ID_FOR_DELETE;
    var inputValues = $('.form_field_outer_links :input').map(function () {
        var type = $(this).prop("type");
        var value = $(this).prop("value");
        var id = $(this).prop("id").split('_');
        if (type == "hidden") {
            if (id[1] == SplitedId[1]) {
                ID_FOR_DELETE = $("#hiddenLinks_" + id[1]).val();
            }
        }
    });
    var postData = { 'Id': ID_FOR_DELETE, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileLinksDelete',
        success: function (data) {
            if (data.isSuccess) {
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
                    title: "Information Has Been Deleted Successfully."
                });
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            }); 
            btnWaitMe_Stop(e.id); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
function checkRuntimeValidationUrlNewslink(e) {
    if (KingIsUrlValidWithoutDomain($(e).val())) {
        KingWarningStyleOff("#" + e.id, 0);
        return true;
    } else {
        pageWaitMeRemove(); // loading process stops
        KingWarningStyle("#" + e.id, 0);
        return false;
    }
}
// Attachment
function fileAttachmentChange(e) {
    if (($("#" + e.id).val()) != '')
        $("#btnUpdateProfileAttachments").prop("disabled", false);
    else
        $("#btnUpdateProfileAttachments").prop("disabled", true);
}
function PostProfileAttachments() {

    // Validations
    if ($("#txtAttachmentTitle").val().trim() == '') {
        KingWarningStyle("#txtAttachmentTitle", 0);
        return;
    } else {
        KingWarningStyleOff("#txtAttachmentTitle", 0);
    }
    if ($("#fileAttachment").val().trim() == '') {
        KingWarningStyle("#fileAttachment", 0);
        return;
    } else {
        KingWarningStyleOff("#fileAttachment", 0);
    }
    // End of Validations

    var postData = new FormData();
    postData.append("Title", $("#txtAttachmentTitle").val());
    var Image = document.getElementById("fileAttachment");

    // Validations
    if (!(KingCheckSizeExtension(Image.files[0], ["jpg", "png", "bmp", "jpeg", "docx", "pdf", "txt"], "2097152", false))) {
        $("#divInformationFileUpload").css("color", "red");
        btnWaitMe_Stop("btnUpdateProfileAttachments"); // Loading Button Stops
        pageWaitMeRemove(); // loading process stops
        return;
    }
    else {
        $("#divInformationFileUpload").css("color", "black");
        pageWaitMe("progress"); // loading process starts
        btnWaitMe_Start('btnUpdateProfileAttachments'); // Loading Button Start
        postData.append("File", Image.files[0]);
    }
    // End of Validations

    $.ajax({
        contentType: false,
        processData: false,
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'PostProfileAttachments',
        xhr: function () { // action the progressbar
            var xhr = new window.XMLHttpRequest();
            xhr.upload.addEventListener("progress", function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;
                    var elem = document.getElementById("myBar");
                    var amount = Math.round(percentComplete * 100);
                    elem.style.width = amount + '%';
                    elem.innerHTML = amount * 1 + '%';
                    if (percentComplete == 1) {
                        elem.style.width = '0%';
                        elem.innerHTML = '';
                    }
                }
            }, false);
            return xhr;
        },
        success: function (data) {
            if (data.isSuccess) {
                $("#status").html('UPLOADED!!');
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
                    title: "Information Has Been Updated Successfully."
                });
                $("#divAttachments").load(window.location + " #divAttachments"); // update table!
            }
            else {
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
                    title: data.message
                }); 
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            }); 
        }
    })
        .always(function (dataOrjqXHR, textStatus, jqXHRorErrorThrown) {
            btnWaitMe_Stop("btnUpdateProfileAttachments"); // Loading Button Stops
            $("#btnUpdateProfileAttachments").prop("disabled", true);
            pageWaitMeRemove(); // loading process stops
            $("#txtAttachmentTitle").val("");
            $("#fileAttachment").val("");
        });
}
function DeleteProfileAttachment(e, Id) {
    pageWaitMe("progress"); // loading process starts
    btnWaitMe_Start(e.id); // Loading Button Start
    var postData = { 'Id': Id, }
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: 'POST',
        data: postData,
        url: 'ProfileAttachmentsDelete',
        success: function (data) {
            if (data.isSuccess) {
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
                    title: "Information Has Been Deleted Successfully."
                });
                $("#divAttachments").load(window.location + " #divAttachments");
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
            else {
                btnWaitMe_Stop(e.id); // Loading Button Stops
                pageWaitMeRemove(); // loading process stops
            }
        },
        error: function (req, status, err) {
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
                title: "Something Went Wrong."
            }); 
            btnWaitMe_Stop(e.id); // Loading Button Stops
            pageWaitMeRemove(); // loading process stops
        }
    });
}
// Add Runtime Controls
function generateGuid() {
    return Math.random().toString(36).substring(2, 15) + Math.random().toString(36).substring(2, 15);
}
//===== add the form fieed row
$(document).ready(function () {
    $("body").on("click", ".add_new_frm_field_btn,.add_new_frm_field_favorite_movie_btn,.add_new_frm_field_companies_btn,.add_new_frm_field_news_btn,.add_new_frm_field_links_btn", function () {
        var className = this.className;
        switch (className) {
            case "add_new_frm_field_btn":
                fireNewEductionalPart();
                break;
            case "add_new_frm_field_favorite_movie_btn":
                fireNewFavoriteMoviePart();
                break;
            case "add_new_frm_field_companies_btn":
                fireNewCompaniesPart();
                break;
            case "add_new_frm_field_news_btn":
                fireNewNewsPart();
                break;
            case "add_new_frm_field_links_btn":
                fireNewLinksPart();
                break;
        }
    });
});
function fireNewEductionalPart() {
    // After adding the first form, the update button will be enabled.
    $("#btnUpdateProfileEducations").prop("disabled", false);
    // how many new forms a client can add? the answer is: at most 10 forms
    var index = $(".form_field_outer").find(".form_field_outer_row").length + 1;
    if (index > 10) {
        Swal.fire({
            position: "center",
            icon: "error",
            title: "Only 10 educational cases are allowed.",
            showConfirmButton: false,
            timer: 3000
        });
        return;
    }
    // end
    var guid = generateGuid();// generate a random string as the name of the controls
    $(".form_field_outer").append(`

                                                                                                                                                                                                                                                                            <div class="row form_field_outer_row" id="educational_form_`+ guid.toString() + `">

                                                                                                                                                                                                                                                                    <fieldset>
                                                                                                                                                                                                                                                                                <legend>Educational Case</legend>

                                                                                                                                                                                                                                                                                <input type="hidden"
                                                                                                                                                                                                                                                                                id="hiddenEducationalCase_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                                value="`+ guid.toString() + `"
                                                                                                                                                                                                                                                                />

                                                                                                                                                                                                                                                                        <div class="input-group mb-3">
                                                                                                                                                                                                                                                                            <span class="input-group-text">Name</span>
                                                                                                                                                                                                                                                                            <input type="text"
                                                                                                                                                                                                                                                                                    class="form-control"
                                                                                                                                                                                                                                                                                            id="txtSchoolName_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                                    placeholder="School, Instituion, College, University Name">
                                                                                                                                                                                                                                                                        </div>

                                                                                                                                                                                                                                                                        <div class="input-group mb-3">
                                                                                                                                                                                                                                                                            <span class="input-group-text">Field of Study</span>
                                                                                                                                                                                                                                                                            <input type="text"
                                                                                                                                                                                                                                                                                    class="form-control"
                                                                                                                                                                                                                                                                                            id="txtField_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                                    placeholder="Directing, Software engineering, ...">
                                                                                                                                                                                                                                                                        </div>

                                                                                                                                                                                                                                                                                                            <div style="display:flex;">
                                                                                                                                                                                                                                                                            <div>
                                                                                                                                                                                                                                                                                <label class="input-group-text" style="border-radius:5px 0px 0px 5px;"
                                                                                                                                                                                                                                                                                        for="inputGroupSelect01">From</label>
                                                                                                                                                                                                                                                                            </div>
                                                                                                                                                                                                                                                                            <div>
                                                                                                                                                                                                                                                                                <input readonly
                                                                                                                                                                                                                                                                                        placeholder="Starting date of Eduction"
                                                                                                                                                                                                                                                                                        style="border-radius:0px;border-left:0;" width="300"
                                                                                                                                                                                                                                                                                                id="datepickerFrom_`+ guid.toString() + `">
                                                                                                                                                                                                                                                                            </div>
                                                                                                                                                                                                                                                                        </div>

                                                                                                                                                                                                                                                                        <div style="display:flex;">
                                                                                                                                                                                                                                                                            <div>
                                                                                                                                                                                                                                                                                <label class="input-group-text" style="border-radius:5px 0px 0px 5px;"
                                                                                                                                                                                                                                                                                        for="inputGroupSelect01">To</label>
                                                                                                                                                                                                                                                                            </div>
                                                                                                                                                                                                                                                                            <div>
                                                                                                                                                                                                                                                                                <input readonly
                                                                                                                                                                                                                                                                                        placeholder="Ending date of Eduction"
                                                                                                                                                                                                                                                                                        style="border-radius:0px;border-left:0;" width="300"
                                                                                                                                                                                                                                                                                                        id="datepickerTo_`+ guid.toString() + `">
                                                                                                                                                                                                                                                                            </div>
                                                                                                                                                                                                                                                                        </div>

                                                                                                                                                                                                                                                                        <div class="form-group col-md-2 add_del_btn_outer">
                                                                                                                                                                                                                                                                            <button type="button" class="btn_round remove_node_btn_frm_field"
                                                                                                                                                                                                                                                                                        id="btnRemoveNodeBtnFrmField_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                              onclick="DeleteProfileEducation(this)"
                                                                                                                                                                                                                                                                            >
                                                                                                                                                                                                                                                                                <i class="fas fa-trash-alt"></i>
                                                                                                                                                                                                                                                                            </button>
                                                                                                                                                                                                                                                                        </div>
                                                                                                                                                                                                                                                                    </fieldset>

                                                                                                                                                                                                                                                                </div>

                                                                                                                                                                                                                                                                                                                                                                                                            `);

    $('#datepickerFrom_' + guid.toString()).datepicker({
        uiLibrary: 'bootstrap5'
    });
    $('#datepickerTo_' + guid.toString()).datepicker({
        uiLibrary: 'bootstrap5'
    });
}
function fireNewFavoriteMoviePart() {
    // After adding the first form, the update button will be enabled.
    $("#btnUpdateProfileFavoriteMovies").prop("disabled", false);
    //how many new forms a client can add? the answer is: at most 10 forms
    var index = $(".form_field_outer_favoriteMovie").find(".form_field_outer_row_favoriteMovie").length + 1;
    if (index > 10) {
        Swal.fire({
            position: "center",
            icon: "error",
            title: "Only 10 favorite movie are allowed.",
            showConfirmButton: false,
            timer: 3000
        });
        return;
    }
    var guid = generateGuid();// generate a random string as the name of the controls
    $(".form_field_outer_favoriteMovie").append(`

                                                                                                                                                                                                                                                                <div class="row form_field_outer_row_favoriteMovie" id="favoriteMovie_form_`+ guid.toString() + `">

                                                                                                                                                                                                                                                                        <fieldset>
                                                                                                                                                                                                                                                                            <legend>Favorite Movie</legend>

                                                                                                                                                                                                                                                                            <input type="hidden"
                                                                                                                                                                                                                                                                                    id="hiddenFavoriteMovie_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                                            value=`+ guid.toString() + `
                                                                                                                                                                                                                                                            />


                                                                                                                                                                                                                                                                                <div class="input-group mb-3">
                                                                                                                                                                                                                                                                                <span class="input-group-text">IMDb Movie Link</span>
                                                                                                                                                                                                                                                                                <input type="text"
                                                                                                                                                                                                                                                                                    onkeypress="if(event.keyCode === 13)event.preventDefault();"
                                                                                                                                                                                                                                                                                onkeyup="checkRuntimeValidationUrlIMDb(this)"
                                                                                                                                                                                                                                                                                    class="form-control"
                                                                                                                                                                                                                                                                                            id="txtMovieLink_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                                    placeholder="https://www.imdb.com/title/tt0068646/">
                                                                                                                                                                                                                                                                                <button type="button"
                                                                                                                                                                                                                                                                                                    onclick="CheckTheLink(this,'txtMovieLink_`+ guid.toString() + `');"
                                                                                                                                                                                                                                                                                                    id="btnCheckTheLink_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                                class="btn cur-p btn-primary">
                                                                                                                                                                                                                                                                                    CHECK THE LINK <span class="btn-icon-right">
                                                                                                                                                                                                                                                                                        <i class="fa-solid fa-magnifying-glass"></i>
                                                                                                                                                                                                                                                                                </button>
                                                                                                                                                                                                                                                                                </div>

                                                                                                                                                                                                                                                                            <div class="form-group col-md-2 add_del_btn_outer">
                                                                                                                                                                                                                                                                                <button type="button" class="btn_round remove_node_btn_frm_field_FavoriteMovie"
                                                                                                                                                                                                                                                                                onclick="DeleteProfileFavoriteMovies(this)"
                                                                                                                                                                                                                                                                                            id="btnRemoveNodeBtnFrmFieldFavoriteMovie_`+ guid.toString() + `"
                                                                                                                                                                                                                                                                                    \>
                                                                                                                                                                                                                                                                                    <i class="fas fa-trash-alt"></i>
                                                                                                                                                                                                                                                                                </button>
                                                                                                                                                                                                                                                                            </div>

                                                                                                                                                                                                                                                                        </fieldset>

                                                                                                                                                                                                                                                                    </div>

                                                                                                                                                                                                                                                                `);
}
function fireNewNewsPart() {
    // After adding the first form, the update button will be enabled.
    $("#btnUpdateProfileNews").prop("disabled", false);
    //how many new forms a client can add? the answer is: at most 10 forms
    var index = $(".form_field_outer_news").find(".form_field_outer_news_row").length + 1;
    if (index > 10) {
        Swal.fire({
            position: "center",
            icon: "error",
            title: "Only 10 news are allowed.",
            showConfirmButton: false,
            timer: 3000
        });
        return;
    }
    var guid = generateGuid();// generate a random string as the name of the controls
    $(".form_field_outer_news").append(`
                                                                                                        <div class="row form_field_outer_news_row">
                                                                                                                                        <fieldset>
                                                                                                                                            <legend>News</legend>
                                                                                                                                            <input type="hidden"
                                                                                                                                               id="hiddenNews_`+ guid.toString() + `"                                       />
                                                                                                                                            <div class="input-group mb-3">
                                                                                                                                                <span class="input-group-text">News Title</span>
                                                                                                                                                <input type="text"
                                                                                                                                                   class="form-control"
                                                                                                                                                   id="txtNewsTitle_`+ guid.toString() + `"
                                                                                                                                                   placeholder="The Official Selection at Cannes Film Festival">
                                                                                                                                                <span class="input-group-text">Reference</span>
                                                                                                                                                <input type="text"
                                                                                                                                                   class="form-control"
                                                                                                                                                   id="txtNewsReference_`+ guid.toString() + `"
                                                                                                                                                   placeholder="Festival Press, Magazine, ...">
                                                                                                                                            </div>
                                                                                                                                            <div class="input-group mb-3">
                                                                                                                                                <span class="input-group-text">News Link</span>
                                                                                                                                                <input type="text"
                                                                                                                                                   class="form-control"
onkeyup="checkRuntimeValidationUrlNewslink(this)"
                                                                                                                                                   id="txtNewsLink_`+ guid.toString() + `"
                                                                                                                                                   placeholder="www.galaxypremiere.com/blog/2035">
                                                                                                                                            </div>
                                                                                                                                            <div style="display:flex;">
                                                                                                                                                <div>
                                                                                                                                                    <label class="input-group-text" style="border-radius:5px 0px 0px 5px;"
                                                                                                                                                       for="inputGroupSelect01">From</label>
                                                                                                                                                </div>
                                                                                                                                                <div>
                                                                                                                                                    <input readonly
                                                                                                                                                       placeholder="Published Date of News"
                                                                                                                                                       style="border-radius:0px;border-left:0;" width="300"
                                                                                                                                                               id="datepickerNewsDate_`+ guid.toString() + `">
                                                                                                                                                </div>
                                                                                                                                            </div>
                                                                                                                                            <div class="form-group col-md-2 add_del_btn_outer">
                                                                                                                                                <button type="button" class="btn_round remove_node_btn_frm_field_news"
                                                                                                                                                  id="btnRemoveNodeBtnFrmFieldNews_`+ guid.toString() + `"
                                                                                                                                                    onclick="DeleteProfileNews(this)">
                                                                                                                                                    <i class="fas fa-trash-alt"></i>
                                                                                                                                                </button>
                                                                                                                                            </div>

                                                                                                                                        </fieldset>

                                                                                                                                    </div>
                                                                                                                        `);
    $('#datepickerNewsDate_' + guid.toString()).datepicker({
        uiLibrary: 'bootstrap5'
    });
}
function fireNewLinksPart() {
    // After adding the first form, the update button will be enabled.
    $("#btnUpdateProfileLinks").prop("disabled", false);
    //how many new forms a client can add? the answer is: at most 10 forms
    var index = $(".form_field_outer_links").find(".form_field_outer_links_row").length + 1;
    if (index > 10) {
        Swal.fire({
            position: "center",
            icon: "error",
            title: "Only 10 links are allowed.",
            showConfirmButton: false,
            timer: 3000
        });
        return;
    }
    var guid = generateGuid();// generate a random string as the name of the controls
    $(".form_field_outer_links").append(`
                                                                                                                <div class="row form_field_outer_links_row" id="links_form_`+ guid.toString() + `">
                                                                                                                                <fieldset>
                                                                                                                                    <legend>Link</legend>
                                                                                                                                    <input type="hidden"
                                                                                                                                     value=`+ guid.toString() + `
                                                                                                                                               id="hiddenLinks_`+ guid.toString() + `" />
                                                                                                                                    <div class="input-group mb-3">
                                                                                                                                        <span class="input-group-text">Title</span>
                                                                                                                                        <input type="text"
                                                                                                                                           class="form-control"
                                                                                                                                           id="txtLinkTitle_`+ guid.toString() + `"
                                                                                                                                           placeholder="The Official Selection at Cannes Film Festival">
                                                                                                                                    </div>
                                                                                                                                    <div class="input-group mb-3">
                                                                                                                                        <span class="input-group-text">Link</span>
                                                                                                                                        <input type="text"
                                                                                                                                           class="form-control"
onkeyup="checkRuntimeValidationUrlNewslink(this)"
                                                                                                                                           id="txtLinkLink_`+ guid.toString() + `"
                                                                                                                                           placeholder="www.galaxypremiere.com/blog/2035">
                                                                                                                                    </div>
                                                                                                                                    <div class="form-group col-md-2 add_del_btn_outer">
                                                                                                                                        <button type="button" class="btn_round remove_node_btn_frm_field_links"
                                                                                                                                                    id="btnRemoveNodeBtnFrmFieldLinks_`+ guid.toString() + `"
                                                                                                                                            onclick="DeleteProfileLinks(this)">
                                                                                                                                            <i class="fas fa-trash-alt"></i>
                                                                                                                                        </button>
                                                                                                                                    </div>
                                                                                                                                </fieldset>

                                                                                                                            </div>
                                                                                                    `);
}
//===== delete the form fieed row
$(document).ready(function () {
    $("body").on("click", ".remove_node_btn_frm_field,.remove_node_btn_frm_field_FavoriteMovie,.remove_node_btn_frm_field_company,.remove_node_btn_frm_field_news,.remove_node_btn_frm_field_links", function () {
        var className = this.className;
        switch (className) {
            case "btn_round remove_node_btn_frm_field":
                fireDeleteEductionalPart(this);
                break;
            case "btn_round remove_node_btn_frm_field_FavoriteMovie":
                fireDeleteFavoriteMoviePart(this);
                break;
            case "btn_round remove_node_btn_frm_field_company":
                fireDeleteCompanyPart(this);
                break;
            case "btn_round remove_node_btn_frm_field_news":
                fireDeleteNewsPart(this);
                break;
            case "btn_round remove_node_btn_frm_field_links":
                fireDeleteLinksPart(this);
                break;
        }
    });
});
function fireDeleteEductionalPart(e) {
    btnWaitMe_Start(e.id); // Loading Button Start
    $(e).closest(".form_field_outer_row").remove();
    var index = $(".form_field_outer").find(".form_field_outer_row").length;
    if (index == 0) $("#btnUpdateProfileEducations").prop("disabled", true);
}
function fireDeleteFavoriteMoviePart(e) {
    btnWaitMe_Start(e.id); // Loading Button Start
    $(e).closest(".form_field_outer_row_favoriteMovie").remove();
    var index = $(".form_field_outer_favoriteMovie").find(".form_field_outer_row_favoriteMovie").length;
    if (index == 0) $("#btnUpdateProfileFavoriteMovies").prop("disabled", true);
}
function fireDeleteCompanyPart(e) {
    btnWaitMe_Start(e.id); // Loading Button Start
    $(e).closest(".form_field_outer_companies_row").remove();
    var index = $(".form_field_outer_companies").find(".form_field_outer_companies_row").length;
    if (index == 0) $("#btnUpdateProfileCompanies").prop("disabled", true);
}
function fireDeleteNewsPart(e) {
    btnWaitMe_Start(e.id); // Loading Button Start
    $(e).closest(".form_field_outer_news_row").remove();
    var index = $(".form_field_outer_news").find(".form_field_outer_news_row").length;
    if (index == 0) $("#btnUpdateProfileNews").prop("disabled", true);
}
function fireDeleteLinksPart(e) {
    btnWaitMe_Start(e.id); // Loading Button Start
    $(e).closest(".form_field_outer_links_row").remove();
    var index = $(".form_field_outer_links").find(".form_field_outer_links_row").length;
    if (index == 0) $("#btnUpdateProfileLinks").prop("disabled", true);
}