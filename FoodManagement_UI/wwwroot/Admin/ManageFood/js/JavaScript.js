
function Test() {
    if (sessionStorage.getItem('Email') == null || sessionStorage.getItem('Email') == "" || sessionStorage.getItem('Email').length <= 0) {
        window.location.href = '/Home/Index';
        //console.log(sessionStorage.getItem('AdminID'));
        return false;
    }
}

//Fetch week Of Month
function fetchWeekOfMonth() {
    // Get the selected date from the input field
    const dateInput = document.getElementById("date-input");
    var dateValue = dateInput.value; // Retrieve the value from the input field
    const d = new Date(dateValue);
    const date = d.getDate();
    const day = d.getDay();
    // Convert the day of the week to a name
    var daysOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var dayName = daysOfWeek[day];
    const week = Math.ceil((date - 1 - day) / 7);


    if (day=== 0 || day === 6) {
        alert("Please select a workday.");
        return false;
    }
    else {
   
        // Output the week of the month
        if (week == 5 || week == 6) {
            document.getElementById("dateinput2").value = 1;
        }
        else
            document.getElementById("dateinput2").value = week;
     
/*        console.log(dayName); // Output the day of the week*/
        document.getElementById("dateinput3").value = dayName;
        document.getElementById("DaySelection11").innerHTML = dayName;
        document.getElementById("WeekSelection11").innerHTML = week;


    }
}

//Add Food
function AddData() {
     var FoodSelect = $('input[name="FoodSelection"]:checked').val();

    //Check if it is Empty
    var elements = document.querySelectorAll(".form-control.form-control-lg");

    // Iterate through the elements
    for (var i = 0; i < elements.length; i++) 
        var element = elements[i];

    // Check if the element is empty
        if (element.value.trim() === "") {
        swal("Please Enter Food Item", "Or Click X to discard", "warning");
        return false;
    }
        else {
            var date = document.getElementById("date-input").value;
            var FoodSelect = $('input[name="FoodSelection"]:checked').val();
            if (date == null || date == "") {
                swal("Please Select Date");
                return false;
            }
            else if (FoodSelect == null || FoodSelect == "") {
                swal("Please Veg/NonVeg");
                return false;
            }
            else 
            var userInput = $('#FoodItems').val(); // Retrieve user input from the textbox
            var week = $('#dateinput2').val(); // Week
            var day = $('#dateinput3').val(); // Day
            var FoodSelect = $('input[name="FoodSelection"]:checked').val();
            if (FoodSelect == "Veg") {
                VegCrud();
            } else {
                NonVegCrud();
            }

     
        if (FoodSelect == "Veg") {
            var food = {
                Week: week,
                Day: day,
                Type: FoodSelect,
                Name: userInput
            };

            // Perform an AJAX request to send the data to the server
            $.ajax({
                url: "/FoodApi/AddFood",
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(food), // Send the food object as JSON data
                contentType: 'application/json',
                success: function (response) {
                    swal(userInput + " Added", "", "success");
                    var tableBody = $("#menuTable tbody");
                    tableBody.empty();
                    VegCrud();
                },
                error: function (error) {
                    // Handle error response
                }
            });

            userInput = ''; // Clear userInput after sending the request

        }
        else {

            var food = {
                Week: week,
                Day: day,
                Type: FoodSelect,
                Name: userInput
            };

            // Perform an AJAX request to send the data to the server
            $.ajax({
                url: "/FoodApi/AddFood",
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(food), // Send the food object as JSON data
                contentType: 'application/json',
                success: function (response) {
                    swal(userInput + " Added", "", "success");
                    var tableBody = $("#menuTable tbody");
                    tableBody.empty();
                    VegCrud();
                },
                error: function (error) {
                    // Handle error response
                }
            });

            userInput = ''; // Clear userInput after sending the request
        }
    }
}


    

//Export Feedback
function exportTableToExcel(tableID, filename = '') {
    var downloadLink;
    var dataType = 'application/vnd.ms-excel';
    var tableSelect = document.getElementById(tableID);
    var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

    // Specify file name
    filename = filename ? filename + '.xls' : 'excel_data.xls';

    // Create download link element
    downloadLink = document.createElement("a");

    document.body.appendChild(downloadLink);

    if (navigator.msSaveOrOpenBlob) {
        var blob = new Blob(['\ufeff', tableHTML], {
            type: dataType
        });
        navigator.msSaveOrOpenBlob(blob, filename);
    } else {
        // Create a link to the file
        downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

        // Setting the file name
        downloadLink.download = filename;

        //triggering the function
        downloadLink.click();
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



//Get The Feedback
function GetFeedback() {
    fetch('/AdminApi/FetchFeedback?Data=Admin')
        .then(response => response.json())
        .then(data => {
            var jsonArray = data;
            var tableBody = document.querySelector('#feedbackTable tbody');
            tableBody.innerHTML = '';

            jsonArray.forEach(item => {
                var row = document.createElement('tr');

                var Day = document.createElement('td');
                Day.textContent = item.day;

                var Week = document.createElement('td');
                Week.textContent = item.week;

                var Rating = document.createElement('td');
                Rating.textContent = item.rating;

                var Comments = document.createElement('td');
                Comments.textContent = item.comments; // Corrected property name

                row.appendChild(Day);
                row.appendChild(Week);
                row.appendChild(Rating);
                row.appendChild(Comments);

                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });

}





//Get The Feedback
function GetBookings() {
    fetch('/AdminAPi/FetchBookings?Data=Admin')
        .then(response => response.json())
        .then(data => {
            // Store the JSON data in an array
            var jsonArray = data;
           // console.log(jsonArray);

            // Get the table body element
            var tableBody = document.querySelector('#BookingsTable tbody');

            // Clear any existing rows
            tableBody.innerHTML = '';

            // Loop through the data and create table rows
            jsonArray.forEach(item => {
                var row = document.createElement('tr');

                var Name = document.createElement('td');
                Name.textContent = item.name;

                var Food = document.createElement('td');
                Food.textContent = item.vegNonVegSelection;

                var Dates = document.createElement('td');
                Dates.textContent = item.date;



                row.appendChild(Name);
                row.appendChild(Food);
                row.appendChild(Dates);

                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

//Get Food Items
function Call()
{
    var date = document.getElementById("date-input").value;
    var FoodSelect = $('input[name="FoodSelection"]:checked').val();
    if (date == null || date == "") {
        swal("Please Select Date");
        return false;
    }
    else if (FoodSelect == null || FoodSelect == "") {
        swal("Please Veg/NonVeg");
        return false;
    }
    else if (FoodSelect == "Veg") {
        VegCrud();
        return true;
    }
    else {
        NonVegCrud();
        return true;
    }

}


