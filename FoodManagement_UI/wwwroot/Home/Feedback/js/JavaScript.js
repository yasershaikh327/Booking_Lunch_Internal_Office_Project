function daterestrict() {
    // Get the current date
    var currentDate = new Date();

    // Format the date to match the input's value format (yyyy-mm-dd)
    var formattedDate = currentDate.toISOString().split('T')[0];

    // Set the maximum allowed date for the input
    document.getElementById('date-input').setAttribute('max', formattedDate);

}

function fetchWeekOfMonth() {
    // Get the selected date from the input field
    const dateInput = document.getElementById("date-input");
    const selectedDate = new Date(dateInput.value);

    // // Check if the selected date is a Saturday or Sunday
    if (selectedDate.getDay() === 0 || selectedDate.getDay() === 6) {
        alert("Please select a workday.");
        return false;
    }
    else {
        // Calculate the week of the month
        const firstDayOfMonth = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), 1);
        const dayOfWeek = firstDayOfMonth.getDay(); // 0 (Sunday) to 6 (Saturday)
        const weekOfMonth = Math.ceil((selectedDate.getDate() + dayOfWeek) / 7);

        // Output the week of the month
        document.getElementById("dateinput2").value = weekOfMonth;

        // Assuming you have an input element with the id "myDateInput"

        var dateValue = dateInput.value; // Retrieve the value from the input field

        var date = new Date(dateValue); // Create a Date object

        var dayOfWeek1 = date.getDay(); // Get the day of the week as a number

        // Convert the day of the week to a name
        var daysOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        var dayName = daysOfWeek[dayOfWeek1];

        console.log(dayName); // Output the day of the week
        document.getElementById("dateinput3").value = dayName;
        document.getElementById("DaySelection11").innerHTML = dayName;


    }
}

function Y() {
    swal("Thank You For Your Feedback!");
}
function X() {
    swal("Please Select Ratings!");
}


//To Add Feedback
function AddData() {
    var DayInput = $("#dateinput3").val();
    var WeekInput = $("#dateinput2").val();
    var ratingSelection = $('input[name="Rating"]:checked').val();
    var Comments = $("#Feedback").val();
    if (DayInput == "" || DayInput == null || DayInput == "undefined") {
        swal("Select Date");
        return false;
    }
    else if (WeekInput == "" || WeekInput == null || WeekInput == "undefined") {
        swal("Select Date");
        return false;
    }
    else if (ratingSelection == "" || ratingSelection == null || ratingSelection == "undefined") {
        swal("Select Rating");
        return false;
    }
    else if (Comments == "" || Comments == null || Comments == "undefined") {
        swal("Give Reviews");
        return false;
    }
    else {

        var feedback = {
            Week: WeekInput,
            Day: DayInput,
            Rating: ratingSelection,
            Comments: Comments
        };

        // Make an AJAX request
        $.ajax({
            type: "POST",
            url: "/EmployeeApi/UserGiveFeedback",
            data: JSON.stringify(feedback),
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                // Handle success here
                swal("Feedback submitted successfully!", "Redirecting");
                setTimeout(function () {
                    window.location.href = '/Home/Index'; // Replace with your desired URL
                }, 2500);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Handle error here
                console.error("Error:", textStatus, errorThrown);
            }
        });
    }
}
