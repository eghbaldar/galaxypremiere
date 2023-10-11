function checkStrength(password) {
    var val = password;
    var meter = document.getElementById("meter");
    var no = 0;
    if (val != "") {
        // If the password length is less than or equal to 6
        if (val.length <= 6) no = 1;

        // If the password length is greater than 6 and contain any lowercase alphabet or any number or any special character
        if (val.length > 6 && (val.match(/[a-z]/) || val.match(/\d+/) || val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/))) no = 2;

        // If the password length is greater than 6 and contain alphabet,number,special character respectively
        if (val.length > 6 && ((val.match(/[a-z]/) && val.match(/\d+/)) || (val.match(/\d+/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)) || (val.match(/[a-z]/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)))) no = 3;

        // If the password length is greater than 6 and must contain alphabets,numbers and special characters
        if (val.length > 6 && val.match(/[a-z]/) && val.match(/\d+/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)) no = 4;

        if (no == 1) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "red";
            return false // means invalidated
        }

        if (no == 2) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "#F5BCA9";
            return false // means invalidated
        }

        if (no == 3) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "#FF8000";
            return false // means invalidated
        }

        if (no == 4) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "#00FF40";
            return true // means validated
        }
    }

    else {
        meter.style.backgroundColor = "white";
        return false // means invalidated
    }
}

function generatePass() {

    let pass = '';
    let str = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ' +
        'a%b!cd_e+fg(hi/%jklm*n[%op]qrs/tu|vwxyz%01%23$456@@78%9@@#$';

    for (let i = 1; i <= 15; i++) {
        let char = Math.floor(Math.random()
            * str.length + 1);

        pass += str.charAt(char)
    }

    $("#txtPassword").val(pass);
    $("#txtRePassword").val(pass);
    document.getElementById("txtPassword").type = "text";
    checkStrength(pass);
}

function matchPassword(pass, rePass) {
    if (pass != rePass) {
        Swal.fire({
            title: 'Error!',
            text: 'Password doesnt match with repassword.',
            icon: 'error',
            confirmButtonColor: '#ff5722',
            confirmButtonText: 'OK',
        }).then((result) => {
            return false;
        });
        return false;
    }
    else
    {
        if (!checkStrength(pass)) {
            Swal.fire({
                title: 'Error!',
                text: 'Password Is Not Enough Strong.',
                icon: 'error',
                confirmButtonColor: '#ff5722',
                confirmButtonText: 'OK',
            }).then((result) => {
                return false;
            })
        };
        return false;
    }
    return true;
}
