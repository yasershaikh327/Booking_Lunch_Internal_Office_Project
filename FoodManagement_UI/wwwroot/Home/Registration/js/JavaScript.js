
function pops1() {
    setTimeout(function () {
        window.location.href = '/Home/Index'; // Replace with your desired URL
    }, 1000);
    swal("Registered Successfully", "", "success")
}
function pops2() {
    swal("Passwords Doesnt Match", "", "error")
}



  



//Check if Email Exists
function Success() {
    swal("Email Already Exists", "", "warning");
}

//Check if EMail is Existing
function Registration() {
    var Name = $("#Name").val();
    var email = sessionStorage.getItem('Email');
    var Password = $("#Password").val();
    var CPassword = $("#ConfirmPassword").val();

    if (Name == "" || Name == null) {
        swal("Enter Name");
        return false;
    }
    else if (!/^[A-Za-z\s.'-]+$/.test(Name)) {
        swal("Name: Please Enter Alphabets Only!");
        return false;
    }
    else if (Password == "" || Password == null) {
        swal("Enter Password");
        return false;
    }
    else if (!/[A-Z]/.test(Password) || !/[a-z]/.test(Password) || !/\d/.test(Password) || !/[!@#$%^&*_]/.test(Password) || (Password.length < 8 && Password.length > 16)) {
        swal(" Password Must contain:  \tAt least one uppercase letter,One lowercase letter,One digit,One special character[!@#$%^&*_] containing 8-16 Characters");
        return false;
    }
    else if (CPassword == "" || CPassword == null) {
        swal("Enter Confirm Password");
        return false;
    }
    else if (Password != CPassword) {
        swal("Password's Doest Match");
        return false;
    }
    else {

        var UsrData = {
            name: Name,
            email: sessionStorage.getItem('Email'),
            password: Password

        };
         
        //Check if Email is Already Existing 
        fetch('/EmployeeApi/ConfirmEmail', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' // Ensure this matches the expected media type
            },
            body: JSON.stringify(UsrData)
        })
            .then(response => response.json())
            .then(data => {
                if (data === "true" || data === true)
                    swal("Email Already Exists");
                else
                    // Make an AJAX request
                    $.ajax({
                        type: "POST",
                        url: "/EmployeeApi/Registration",
                        data: JSON.stringify(UsrData),
                        contentType: "application/json",
                        dataType: "json",
                        success: function (data) {
                            // Handle success here
                            swal("Registered Successfully!", "Redirecting", "success");
                            setTimeout(function () {
                                window.location.href = '/Home/Index'; // Replace with your desired URL
                            }, 2500);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            // Handle error here
                            console.error("Error:", textStatus, errorThrown);
                        }
                    });
                return true;
            })
            .catch(error => {
                console.error('Fetch Error:', error);
            });
    }
}