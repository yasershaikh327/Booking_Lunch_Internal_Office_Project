function Invalid() {
    swal("Invalid Details!", "", "error");
}

function Success() {
    swal("Login Successful!", "", "success");
}

function Login() {

    var Email = document.getElementById("Email").value;
    var Password = document.getElementById("Password").value;


    if (Email == null || Email == "") {
        swal("Enter Email!");
        return false;
    }
    /*else if (!Email.toLowerCase().includes("@zapcg.com")) {
        swal("Please Enter zapcom Email ID");
        return false;
    }*/
    else if (Password == null || Password == "") {
        swal("Enter Password!");
        return false;
    }
    else if (!Password.length < 8 && Password.length > 60) {
        swal(" Password Must contain: 8-60 Characters");
        return false;
    }
    else {
        var UsrInput = {
            Email: Email,
            Password: Password
        };
/*
        console.log(sessionStorage.setItem('Email', Email));*/
        sessionStorage.setItem('Email', Email);
        // Convert the parameters to query string format
    

        // Perform an AJAX request to fetch the JSON data
        // Make an HTTP request to fetch the JSON data
        fetch('/EmployeeApi/ConfirmLogin', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' // Ensure this matches the expected media type
            },
            body: JSON.stringify(UsrInput)
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                // Check if the response contains data
                if (data === -2)
                    window.location.href = "/Admin/ManageFood";
                if (data !== -1 || data === "True") {
                    Success();
                    setTimeout(function () {
                        window.location.href = '/Employee/BookMenuEmployee';
                        sessionStorage.setItem('EmployeeID', data);
                    }, 2000);

                }
                else {
                    Invalid();
                }
            })
            .catch(error => {
                console.error('Fetch Error:', error);
            });
    }
}


    //Admin Login

function AdminLogin() {
    swal("Welcome To Admin Site");
    setTimeout(function () {
        window.location.href = "/Admin/Managefood"; // Replace with the desired URL
    }, 2000); // 5000 milliseconds = 5 seconds
}