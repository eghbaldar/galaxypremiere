function checkSizeExtension(file, arr_extensions, size) {
    var getextension = /[^.]+$/.exec(file.name);
    if (parseInt(arr_extensions.indexOf(getextension.toString().trim().toLowerCase())) > -1) {
        var fileSize = size;
        if (file.size < fileSize) {

            return true;
        }
        else {
            Swal.fire("File size must be less than 2 Mb");
            return false;
        }
    }
    else {
        Swal.fire("File extension (" + getextension.toString() + ") is unacceptable");
        return false;
    }
}