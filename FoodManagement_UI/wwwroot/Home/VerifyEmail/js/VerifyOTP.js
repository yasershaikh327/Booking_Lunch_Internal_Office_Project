


function VerifyOTP() {
    var OTP = document.getElementById("OTP").value;
    if (OTP == null || OTP == "") {
        swal("Enter OTP!");
        return false;
    }  else {

        // Perform an AJAX request to fetch the JSON data
        // Make an AJAX request
        // Create the OTPPayload object
        var OTPPayload = {
            Email: sessionStorage.getItem('Email'),     // Assuming OTP contains the email
            OTPData: OTP     // Your OTPData value
        };

        // Convert the object to JSON
        var jsonPayload = JSON.stringify(OTPPayload);

        // Make the AJAX call
        $.ajax({
            url: '/EmployeeApi/VerifyOTP', // Replace with the actual controller and action URL
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


function NewRegistration() {
    swal("OTP Verified", "Redirecting...", "success");
        setTimeout(function () {
            window.location.href = '/Employee/Registration';
        }, 2000);

    }
