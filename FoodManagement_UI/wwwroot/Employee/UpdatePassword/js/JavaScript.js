//Update Password
function UpdatePassword() {
    var Oldpassword = document.getElementById("ForgetPasswordOld").value;
    var Newpassword = document.getElementById("ForgetPasswordNew").value;
    var CNewpassword = document.getElementById("ForgetPasswordConfirmPassword").value;
    if (Oldpassword == "" || Oldpassword == null) {
        swal("Enter Old Password");
        return false;
    }
    else if (Newpassword == "" || Newpassword == null) {
        swal("Enter New Password");
        return false;
    }
    else if (CNewpassword == "" || CNewpassword == null) {
        swal("Enter Confirm Password");
        return false;
    }
    else if (Newpassword != CNewpassword) {
        swal("Password's Doesnt Match", "", "error");
        return false;
    }
    else {
        var id = sessionStorage.getItem('EmployeeID');
        var Password = Newpassword;
        var oldPassword = Oldpassword;

        var Updatepassword = {
            Id: id,
            oldPassword : oldPassword,
            Password : Password
        };

        // Convert the object to JSON
        var jsonPayload = JSON.stringify(Updatepassword);

        // Make the AJAX call
        $.ajax({
            url: '/EmployeeApi/UpdatePassword', // Replace with the actual controller and action URL
            type: 'POST',
            contentType: 'application/json', // Set the content type to JSON
            data: jsonPayload, // Pass the JSON payload as data
            success: function (response) {
                if (response === false || response === "false") {
                    swal("Invalid OTP", "", "error");
                } else {
                    NewRegistration();
                }
            },
            error: function (xhr, status, error) {
                swal('An error occurred while making the Ajax call:', error);
            }
        });



        
    }
    
}





//Logout
function Logout() {

    swal({
        title: "Are you sure you want to Logout?",
        text: "",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                sessionStorage.removeItem('EmployeeID');
                sessionStorage.removeItem('Email');
                window.location.href = '/Home/Index';
            } else {
                return false;
            }
        });
}

