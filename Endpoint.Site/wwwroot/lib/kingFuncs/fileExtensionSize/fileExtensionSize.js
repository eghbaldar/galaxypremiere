/////////////////////////////////////////////////////////////////
//
// DevelopeR: Alimohammad Eghbaldar
// https://eghbaldar.ir
//
// Features:
//----> 1: Check the extension and size of file
//----> Sample:
// var file = this.files[0];
// if (checkSizeExtension(file, ["jpg", "png", "bmp", "jpeg"], "2097152",true)) {}
//
/////////////////////////////////////////////////////////////////checkSizeExtension

function KingCheckSizeExtension(file, arr_extensions, size, alertMode) {
    var getextension = /[^.]+$/.exec(file.name);
    if (parseInt(arr_extensions.indexOf(getextension.toString().trim().toLowerCase())) > -1) {
        var fileSize = size;
        if (file.size < fileSize) {

            return true;
        }
        else {
            if (alertMode) Swal.fire("File size must be less than 2 Mb");
            return false;
        }
    }
    else {
        if (alertMode) Swal.fire("File extension (" + getextension.toString() + ") is unacceptable");
        return false;
    }
}