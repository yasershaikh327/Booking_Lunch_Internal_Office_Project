
function CallFunction() {
    var Email = $("#Email").val();

    if (Email == null || Email == "") {
        swal("Enter Email!");
        return false;
    } else if (!Email.toLowerCase().includes("@zapcg.com")) {
        swal("Please Enter zapcom Email ID");
        return false;
    } else {

        // Make an AJAX request
        $.ajax({
            url: '/EmployeeApi/ForgetPassword?Email=' + Email, // Replace with the actual controller and action URL
            type: 'POST',
            success: function (response) {
                if (response === true) {
                    swal("Password updated successfully.", "", "success");
                    setTimeout(function () {
                        window.location.href = '/Home/Index';
                    }, 2000);
                } else
                    swal("Invalid Email", "", "error");
            },
            error: function (xhr, status, error) {
                swal('An error occurred while making the Ajax call:', error);
            }
        });
        
    }
}



function Invalid() {
    swal("Invalid Email ID!", "Please Enter Valid Email", "error");
}


function Success() {
    swal("Check Email!", "Use that Password to Login", "info");
}