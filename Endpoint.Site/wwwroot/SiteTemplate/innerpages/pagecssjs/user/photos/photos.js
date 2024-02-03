/*@* Album Section *@*/
var albumTemplate = function (o) {
    return `
        <div class="col-sm-4 col-md-3 margin_bottom_30 album" id="divAlbum_`+ o.id + `">
            <div class="column">
                <a data-fancybox="gallery" onclick="OpenAlbum('`+ o.id + `')">
                        <img class="img-responsive img-crop-square albumCover_`+ o.id + `"
                     src="/SiteTemplate/innerpages/images/layout_img/addPhotoProfile.svg">
                </a>
                <div class="divAlbumMenu">
                    <div class="dropdown" style="float:right;">
                        <button class="dropbtn">
                            <i class="fa fa-ellipsis-v"></i>
                        </button>
                        <div class="dropdown-content">
                            <a onclick="OpenAlbum('`+ o.id + `')">Photos</a>
                            <a onclick="DeletePhotoAlbum('`+ o.id + `')">Delete</a>
                            <a onclick="UpdatePhotoAlbumTitle('`+ o.id + `')">Rename</a>
                        </div>
                    </div>
                </div>
            </div>
                    <div class="heading_section">
                        <h4>
                                <span id="titleAlbumH4_`+ o.id + `">` + o.title + `</span>
                        </h4>
            </div>
        </div>
            `
}
function OpenModalAddAlbum() {
    Swal.fire({
        title: "ALBUM TITLE",
        input: "text",
        inputLabel: "This filed is required.",
        showCancelButton: true,
        inputValidator: (value) => {
            if (!value) {
                return "You need to write something!";
            } else {
                pageWaitMe("progress"); // loading process starts
                $.ajax({
                    contentType: 'application/x-www-form-urlencoded',
                    postType: 'json',
                    type: 'POST',
                    data: { 'Title': value },
                    url: 'ProfileAlbumPost',
                    success: function (data) {
                        if (data.isSuccess) {
                            KingSweetAlert(true, null);
                            //$("#divAlbum").load(window.location + " #divAlbum");
                            $("#divAlbum").append(albumTemplate(data.data));
                        }
                    },
                    error: function (req, status, err) {
                        KingSweetAlert(false, null);
                    }
                }).always(function () {
                    pageWaitMeRemove(); // loading process stops
                });
            }
        }
    });
}
function DeletePhotoAlbum(id) {
    Swal.fire({
        title: 'Delete This Album',
        text: 'All the photos of the album will be deleted, are you sure?',
        icon: 'info',
        showCancelButton: true,
        confirmButtonColor: '#000222',
        cancelButtonColor: '#000222',
        confirmButtonText: 'Yes',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.value) {
            pageWaitMe("progress"); // loading process starts
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                postType: 'json',
                type: 'POST',
                data: { 'Id': id },
                url: 'ProfileAlbumDelete',
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(true, null);
                        $("#divAlbum_" + id).hide();
                    }
                },
                error: function (req, status, err) {
                    KingSweetAlert(false, null);
                }
            }).always(function () {
                pageWaitMeRemove(); // loading process stops
            });
        }
    });
}
function UpdatePhotoAlbumTitle(id) {
    var title = $("#titleAlbumH4_" + id).text();
    Swal.fire({
        title: 'The Album Current Title is [' + title + ']',
        input: "text",
        inputLabel: "New Title:",
        showCancelButton: true,
        inputValidator: (value) => {
            if (!value) {
                return "You Need to Write Something!";
            } else {
                pageWaitMe("progress"); // loading process starts
                $.ajax({
                    contentType: 'application/x-www-form-urlencoded',
                    dataType: 'json',
                    type: 'POST',
                    data: { 'Id': id, 'Title': value },
                    url: 'ProfileAlbumRenameUpdate',
                    success: function (data) {
                        if (data.isSuccess) {
                            KingSweetAlert(true, null);
                            $("#titleAlbumH4_" + id).text(value);
                        }
                    },
                    error: function (req, status, err) {
                        KingSweetAlert(false, null);
                    }
                }).always(function () {
                    pageWaitMeRemove(); // loading process stops
                });
            }
        }
    });
}
// Open Album
var skeletonTemplate = function () {
    return `
                                                <div class='col p-0 m-0'>
                                                        <div class="animated-background m-2"></div>
                                                </div>
                                           `
}
var cardItemTemplate = function (data) {
    if (data.title == null) data.title = '- unknown title -';
    return `
                                                            <div class="itemG `+ data.usersAlbumsId + `"
                                                                    id="photo_`+ data.id + `"
                                                            >
                                                                            <input type="hidden" id="hiddenPhotoTitle_`+ data.id + `" value="` + data.title + `" />
                                                                                    <input type="hidden" id="hiddenPhotoDetail_`+ data.id + `" value="` + data.detail + `" />
                                                            <a class="imgG" onclick="OpenModalPhoto('`+ data.id + `','` + data.title + `','` + data.detail + `','` + data.filename + `')">
                                                                    <img src="/SiteTemplate/innerpages/images/user-photos/`+ data.filename + `"  class="rounded"  alt=` + data.title + ` />
                                                            </a>
                                                                    <span class="caption" onclick="OpenModalPhoto('`+ data.id + `','` + data.title + `','` + data.detail + `','` + data.filename + `')">
                                                            <a>
                                                                <span id="spanTitle_`+ data.id + `">` + data.title + `</span>
                                                            </a>
                                                            </span>
                                                        </div>
                                                        `}
function OpenAlbum(albumId) {
    var title = $("#titleAlbumH4_" + albumId).text();
    pageWaitMe("progress"); // loading process starts
    $("#spanAlbumName").text("Loading Album ...");
    tabNavigationByTabName('TabUserPhotos');
    $('.itemG').prop('hidden', true);
    /////////////////////////////////////////////////////////////////////////

    $.ajax({
        type: "GET",
        url: "PhotosGetPhotosByAlbumId",
        dataType: "json",
        data: { 'AlbumId': albumId },
        success: function (data) {

            var json = data.data.resultGetUsersPhotoPhotosServiceDto;
            var temp = '';
            for (var i = 0; i < json.length; i++) { temp += skeletonTemplate(); }
            $(".containerG").append("<div class='container'> <div class='row row-cols-auto'> " + temp + "</div> </div>");

        },
        error: function (r, s, e) {
            alert(s);
        }
    });

    //setTimeout(function () {
    /////////////////////////////
    $.ajax({
        type: "GET",
        url: "PhotosGetPhotosByAlbumId",
        dataType: "json",
        data: { 'AlbumId': albumId },
        success: function (data) {

            $("#hiddenAlbumId").val(albumId);
            $("#spanAlbumName").text(title);

            var json = data.data.resultGetUsersPhotoPhotosServiceDto;
            var parsToStr = JSON.stringify(json);

            $(".rowG").empty();
            for (var i = 0; i < json.length; i++) {
                $(".rowG").append(cardItemTemplate(json[i]));
            }
            //alert(parsToStr);
        },
        error: function (r, s, e) {
            alert(s);
        }
    }).always(function () {
        pageWaitMeRemove(); // loading process stops
        $('.animated-background').hide();
        $('.itemG').prop('hidden', false);
    });
    ////////////////////////////////
    //}, 1000);
}
// End Open Album
/*@* Upload Js *@*/
var dropzoneavatar = $("#dropzoneAvatar");
dropzoneavatar.on({
    dragenter: draginavatar,
    dragleave: dragoutavatar
});
var inputavatar = dropzoneavatar.find('input');
inputavatar.on('change', dropavatar);
$(dropzoneavatar).hover(
    function () {
        $("#HeadshotChangePhoto").css("display", "inline");
        dropzoneavatar.css("opacity", "0.5")
    }, function () {
        $(this).find("#HeadshotChangePhoto").css("display", "none");
        dropzoneavatar.css("opacity", "1")
    }
);
function draginavatar(e) { //function for drag into element, just turns the bix X white
    $(dropzoneavatar).addClass('hover');
    $("#HeadshotChangePhoto").css("display", "inline");
    dropzoneavatar.css("opacity", "0.5")
}
function dragoutavatar(e) { //function for dragging out of element
    $(dropzoneavatar).removeClass('hover');
    $(this).find("#HeadshotChangePhoto").css("display", "none");
    dropzoneavatar.css("opacity", "1")
}
function dropavatar(e) {

    if ($("#spanAlbumName").text() == "Loading Album ...") {
        Swal.fire({
            title: 'Please Wait !',
            html: 'Your album is getting ready to upload.',
            allowEscapeKey: false,
            allowOutsideClick: false,
            timer: 4000,
            didOpen: () => {
                Swal.showLoading()
            }
        });
        return;
    }

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
        ////////////////////////////// upload file here

        var postData = new FormData();
        postData.append("File", file);
        postData.append("UsersAlbumsId", $("#hiddenAlbumId").val());
        postData.append("Title", "");
        postData.append("Detail", "");
        $.ajax({
            contentType: false,
            processData: false,
            type: 'POST',
            data: postData,
            url: 'PostPhoto',
            success: function (data) {
                if (data.isSuccess) {
                    //////////////////////////// Loaders
                    $("#HeadshotLoader").css("display", "none"); // circle loading on photo
                    $("#dropzoneAvatar *").attr("disabled", false).off('click'); // enable clickable
                    $("#dropzoneAvatar *").css({ // clear ...
                        opacity: "1",
                        cursor: "pointer",
                    });
                    $("#filedropzoneAvatar").css("opacity", "0");
                    //////////////////////////////
                    var newItems = {
                        'usersAlbumsId': $("#hiddenAlbumId").val(),
                        'title': '- unknown title -',
                        'detail': '- unknown detail -',
                        'filename': data.data.filename,
                        'id': data.data.photoId,
                    };
                    $(".rowG").append(cardItemTemplate(newItems));
                    $('.itemG').prop('hidden', false);
                    $('.img-responsive.albumCover_' + $("#hiddenAlbumId").val()).attr('src', '/SiteTemplate/innerpages/images/user-photos/' + data.data.filename); // change the cover of album
                }
                else {
                    KingSweetAlert(false, data.message);
                }
            },
            error: function (req, res, err) {
                KingSweetAlert(false, err);
            }
        }).always(function () {
            $("#HeadshotLoader").css("display", "none"); // circle loading on photo
            $("#dropzoneAvatar *").attr("disabled", false).off('click'); // enable clickable
            $('#dropzoneAvatar').removeClass('hover').addClass('dropped').find('img').remove();
            $('#filedropzoneAvatar').val('');
            $("#dropzoneAvatar *").css({ // clear ...
                cursor: "pointer"
            });
            pageWaitMeRemove(); // loading process stops
        });
    }
    else {
        $('#filedropzoneAvatar').val('');
    }
}
/*@* Photo Section *@*/
function OpenModalPhoto(id, title, detail, filename) {

    $("#modalPhoto").modal("show");

    var controlHiddenDetail = $("#hiddenPhotoDetail_" + id);
    var controlHiddenTitle = $("#hiddenPhotoTitle_" + id);
    var controlId = $("#HiddenPhotoID");
    var controlTitleSpan = $("#txtPhotoTitleSpan");
    var controlDetailSpan = $("#txtPhotoDetailSpan");
    var controlPhoto = $("#photo");

    controlId.val(id);
    if (title.trim() == '' || title == null) controlTitleSpan.text('- unknown title -'); else controlTitleSpan.text(controlHiddenTitle.val());
    if (detail.trim() == '' || detail == null || detail.trim() == 'null') controlDetailSpan.text('- unknown detail -'); else controlDetailSpan.html(controlHiddenDetail.val());
    controlPhoto.attr("src", "../../../SiteTemplate/innerpages/images/user-photos/" + filename);

}
$('document').ready(function () {
    $('#txtPhotoTitle,#txtPhotoDetail').bind('blur', function () {

        //var controlDetailHidden = $('#hiddenPhotoDetail_' + id);
        var input = $(this);
        var span = $(this).attr("hidden", true).siblings("span").show();

        if (input.attr('id') == 'txtPhotoTitle') {
            if (input.val() == '') {
                span.text('- unknown title -');
            }
            else {
                span.text(input.val());
                $("#spanTitle_" + $("#HiddenPhotoID").val()).text(input.val());
                $("#hiddenPhotoTitle_" + $("#HiddenPhotoID").val()).val(input.val());
            }
            // update service launch here:
            if (input.val() != '')
                UpdatePhotoInformation($("#HiddenPhotoID").val(), input.attr('id'), input.val());
        }
        if (input.attr('id') == 'txtPhotoDetail') {
            if (input.val() == '') {
                span.text('- unknown detail -');
            }
            else {
                span.text(input.val().replaceAll("<br>", "\n"));
                //alert(input.attr('id'));
                $("#hiddenPhotoDetail_" + $("#HiddenPhotoID").val()).val(input.val());
                //controlDetailHidden.val(input.val().replaceAll("<br>", "\n"));
            }
            // update service launch here:
            if (input.val() != '')
                UpdatePhotoInformation($("#HiddenPhotoID").val(), input.attr('id'), input.val());
        }
    });
});
$('.spanInputSwitch').click(function () {
    var controlId = $("#HiddenPhotoID");
    var input = $(this).hide().siblings("input");
    var textarea = $(this).hide().siblings("textarea");
    input.attr("hidden", false).focus().select();
    textarea.attr("hidden", false).focus().select();

    if (input.attr('id') == 'txtPhotoTitle') {
        if ($(this).text() == '- unknown title -') {
            input.attr("placeholder", "Type title of your photo");
            input.val('');
        }
        else {
            input.val($(this).text());
        }
    }
    if (textarea.attr('id') == 'txtPhotoDetail') {
        if ($(this).text() == '- unknown detail -') {
            textarea.attr("placeholder", "Type detail of your photo");
            textarea.val('');
        }
        else {
            textarea.val($(this).html().replaceAll("<br>", "\n"));
        }
    }
});
function UpdatePhotoInformation(PhotoId, ControlId, value) {
    pageWaitMe("progress"); // loading process starts
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        postType: 'json',
        type: 'POST',
        data: { 'Id': PhotoId, 'ControlId': ControlId, 'Value': value.replaceAll('\n', "<br>") },
        url: 'UpdatePhoto',
        success: function (data) {
            KingSweetAlert(true, null);
        },
        error: function (req, status, err) {
            KingSweetAlert(false, null);
        },
    }).always(function () {
        pageWaitMeRemove(); // loading process stops
    });
}
function DeletePhotoPhoto() {
    Swal.fire({
        title: 'PHOTO DELETION!',
        text: 'Are you sure to delete this photo?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#000222',
        cancelButtonColor: '#000222',
        confirmButtonText: 'Yes,Sure.',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.value) {
            pageWaitMe("progress"); // loading process starts
            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                postType: 'json',
                type: 'POST',
                data: { 'Id': $("#HiddenPhotoID").val() },
                url: 'DeletePhoto',
                success: function (data) {
                    if (data.isSuccess) {
                        KingSweetAlert(true, null);
                        $("#photo_" + $("#HiddenPhotoID").val()).hide();

                        if (data.data.leftover) {
                            $('.img-responsive.albumCover_' + $("#hiddenAlbumId").val()).attr('src', '/SiteTemplate/innerpages/images/user-photos/' + data.data.randomPhoto); // change the cover of album
                        }
                        else {
                            $('.img-responsive.albumCover_' + $("#hiddenAlbumId").val()).attr('src', '/SiteTemplate/innerpages/images/layout_img/addPhotoProfile.svg'); // change the cover of album to default
                        }
                    }
                },
                error: function (req, status, err) {
                    KingSweetAlert(false, null);
                }
            }).always(function () {
                pageWaitMeRemove(); // loading process stops
                $('.modal').modal('hide');
                $(document.body).removeClass('modal-open');
            });
        }
    });
}
// CLOSE FUNCTION FOR ALL MODALS: (when you are supposed to add modals dynamically, for instance):
$(document).keydown(function (event) {
    if (event.keyCode == 27) {
        $('.modal').modal('hide');
    }
});
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