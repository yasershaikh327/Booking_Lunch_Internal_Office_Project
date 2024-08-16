function Test() {
    if (sessionStorage.getItem('Email') == null || sessionStorage.getItem('Email') == "" || sessionStorage.getItem('Email').length <= 0) {
        window.location.href = '/Home/Index';
        //console.log(sessionStorage.getItem('AdminID'));
        return false;
    }
}


//Fetch Employee Data and store in textboxes
function EmployeeCrud() {

    // Get the element where you want to display the textbox
    var tableBody = $("#menuTable tbody");
    // Clear the existing rows
    tableBody.empty();
    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/AdminApi/FetchEmployee?Data=Admin')
        .then(response => response.json())
        .then(data => {
   

            // Store the JSON data in an array
            var jsonArray = data;

   
            // Iterate over the array containing the JSON data
            jsonArray.forEach(item => {
                    var newRow = $("<tr>");
                    var itemInputName = $("<input>")
                        .attr("type", "text")
                        .addClass("form-control form-control-lg")
                        .attr("readonly", true)
                        .prop("required", true)
                        .attr("value", item.name.replace(/"/g, ""));


                    var itemColumn1 = $("<td>")
                        .css("width", "45%")
                        .append(itemInputName);

                    var itemInputEmail = $("<input>")
                        .attr("type", "text")
                        .attr("readonly", true)
                        .prop("required", true)
                        .addClass("form-control form-control-lg")
                        .attr("value", item.email.replace(/"/g, ""));


                    var itemColumn2 = $("<td>")
                        .css("width", "45%")
                        .append(itemInputEmail);

               

                    var deleteColumn = $("<td>").append(
                        $("<button>")
                            .attr("onclick", "Warning(this)") // Pass 'this' as an argument to access the button element
                            .attr("value", item.id)
                            .attr("name", "Delete")
                            .attr("id", "DeleteRow")
                            .addClass("deleteButton")
                            .css({
                                border: "none",
                                background: "none",
                                "font-size": "x-large",
                            })
                            .append(
                                $("<i>")
                                    .addClass("glyphicon glyphicon-trash")
                                    .css("font-size", "large")
                            )
                    );

                    newRow.append(itemColumn1, itemColumn2, deleteColumn);
                    $("#menuTable tbody").append(newRow);
                
            });

        })
        .catch(error => {
            console.error('Error:', error);
        });
}


//Warn Before Delete
function Warning(button) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this Employee Account!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
             
                $(button).closest("tr").remove();
                Remove(button);

            }
        });
}



//Remove Employee
function Remove(button) {
    var deleteRow = $(button).val(); // Retrieve from Delete button
    var Employee = {
        Id: deleteRow,
    };

    // Convert the parameters to query string format
    var queryString = Object.keys(Employee)
        .map(key => `${encodeURIComponent(key)}=${encodeURIComponent(Employee[key])}`)
        .join("&");

    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    //  fetch('/Home/NonVeg?' + queryString)
    $.ajax({
        url: "/AdminApi/RemoveEmployee?" + queryString,
        type: 'DELETE',
        dataType: 'json',
        Employee: JSON.stringify(Employee),
        contentType: 'application/json',
   
        success: function (response) {
            // Handle success response
            swal("Employee Removed");
          

            $(document).on("click", ".deleteButton", function () {
                $(this).closest("tr").remove();
            });

        },
        error: function (error) {
            // Handle error response
            console.log(error);
    
        }
    });

}