
function Test() {
    if (sessionStorage.getItem('EmployeeID') == null || sessionStorage.getItem('EmployeeID') == "" || sessionStorage.getItem('EmployeeID').length <= 0) {
        window.location.href = '/Home/Index';
        return false;
    }
 
}


//Booking Lunch
function BookingLunch() {

    var FoodSelect = $('input[name="SelectFoods"]:checked').val();
    if (typeof FoodSelect === 'undefined' || FoodSelect === '') { 
        swal("Please Select Veg/NonVeg");
        return false;
    }
    else {

        var Book = {
            Employee: sessionStorage.getItem('EmployeeID'),
            VegNonVegSelection: FoodSelect,
        };


        // Perform an AJAX request to fetch the JSON data
        // Make an HTTP request to fetch the JSON data
        // Make an AJAX request
        $.ajax({
            type: "POST",
            url: "/EmployeeApi/BookLunch",
            data: JSON.stringify(Book),
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                 if (data === 0)
                    // Handle success here
                    swal("Lunch Booked Sucessfully", "Coupon is sent Over mail", "success");
                else if (data === 1)
                    swal("Lunch Can be Booked Between 12am - 10:30am","","warning");
                else
                    swal("Lunch ALready Booked");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Handle error here
                swal("Something Went Wrong");
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



//Call Veg Food Item
function DisplayVegFood() {
    // Get the element where you want to display the textbox
    var tableBody = $("#menuTable tbody");
    // Clear the existing rows
    tableBody.empty();
    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/FoodApi/Gets?Type=Veg')
        .then(response => response.json())
        .then(data => {
            // Store the JSON data in an array

            var jsonArray = data;
            // Iterate over the array containing the JSON data
            jsonArray.forEach(item => {
                var newRow = $("<tr>");
                var itemInput = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .attr("style", "text-align:center;font-size:revert")
                    .attr("value", item.name.replace(/"/g, ""))
                    .prop("required", true);

                var itemColumn = $("<td>")
                    .css("width", "90%")
                    .append(itemInput);

                newRow.append(itemColumn);
                tableBody.append(newRow);

            });


        })
        .catch(error => {
            console.error('Error:', error);
        });

}



function DisplayNonVegFood() {
    // Get the element where you want to display the textbox
    var tableBody = $("#menuTable tbody");
    // Clear the existing rows
    tableBody.empty();
    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/FoodApi/Gets?Type=NonVeg')
        .then(response => response.json())
        .then(data => {
            // Store the JSON data in an array

            var jsonArray = data;
            // Iterate over the array containing the JSON data
            jsonArray.forEach(item => {
                var newRow = $("<tr>");
                var itemInput = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .attr("style", "text-align:center;font-size:revert")
                    .attr("value", item.name.replace(/"/g, ""))
                    .prop("required", true);

                var itemColumn = $("<td>")
                    .css("width", "90%")
                    .append(itemInput);

                newRow.append(itemColumn);
                tableBody.append(newRow);

            });


        })
        .catch(error => {
            console.error('Error:', error);
        });

}



//Check if  NonVeg is Available for the day or not
function CheckIfNonvegExists() {
    fetch('/FoodApi/Gets?Type=NonVeg')
        .then(response => response.json())
        .then(data => {
            // Store the JSON data in an array
            var jsonArray = data;
            // console.log(data);
            if (jsonArray.length === 0) {
                document.getElementById("NonVegFoodSelected").disabled = true;
                document.getElementById("nonveg").style.color = "#c5c5c8";
                return false;
            }

        })
        .catch(error => {
            console.error('Error:', error);
        });
}