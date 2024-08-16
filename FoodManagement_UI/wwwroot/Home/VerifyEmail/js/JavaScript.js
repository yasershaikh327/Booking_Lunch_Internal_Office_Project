function Success() {
    swal("Email Already Exists", "", "warning");
}

function NewEmail() {

    setTimeout(function () {
        window.location.href = '/Employee/VerifyOTP';
    }, 2000);

    
}

function VerifyEmail() {
    var Email = document.getElementById("Email").value;
    if (!Email.toLowerCase().includes("@zapcg.com")) {
        swal("Please Enter zapcom Email ID");
        return false;
    }
    else {
        var data = {
            Email: Email
        };
        sessionStorage.setItem('Email', Email)
        fetch('/EmployeeApi/ConfirmEmail', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' // Ensure this matches the expected media type
            },
            body: JSON.stringify(data)
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                if (data === "true" || data === true)
                    swal("Email Already Exists");
                else
                window.location.href = '/Employee/VerifyOTP';

            })
            .catch(error => {
                console.error('Fetch Error:', error);
            });

    }
}

