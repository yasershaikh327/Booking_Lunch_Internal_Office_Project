

//Fetch Veg Data and store in textboxes
//Call Veg Food Item
function VegCrud() {
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

function VegCrud() {
    var type = 'Veg';
    var day = document.getElementById("dateinput3").value;
    var week = document.getElementById("dateinput2").value;
    var tableBody = $("#menuTable tbody");
    tableBody.empty();

    var url = '/FoodApi/AdminFetchFood?Type=' + type + '&day=' + day + '&week=' + week;

    fetch(url)
        .then(response => response.json())
        .then(data => {
            var jsonArray = data;

            jsonArray.forEach(item => {
                var newRow = $("<tr>");
                var itemInput = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("title", "Alphabets Only")
                    .attr("name", "fooditems1")
                    .val(item.name.replace(/"/g, ""))
                    .prop("required", true);

                var itemColumn = $("<td>")
                    .css("width", "90%")
                    .append(itemInput);

                var updateColumn = $("<td>").append(
                    $("<button>")
                        .attr("onclick", "EditVegFood(this)") // Pass 'this' as an argument to access the button element
                        .attr("data-id", item.id) // Store the unique identifier in the data-id attribute
                        .addClass("update-button") // Use a class instead of an id
                        .css({
                            border: "none",
                            background: "none",
                            "font-size": "x-large",
                        })
                        .append(
                            $("<i>")
                                .addClass("glyphicon glyphicon-pencil")
                                .css("font-size", "large")
                        )
                );

                var deleteColumn = $("<td>").append(
                    $("<button>")
                        .attr("onclick", "RemoveVeg(this)") // Pass 'this' as an argument to access the button element
                        .attr("value", item.id)
                        .attr("name", "id")
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


                newRow.append(itemColumn, updateColumn, deleteColumn);
                $("#menuTable tbody").append(newRow);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });

}



//Remove Veg Food
function RemoveVeg(button) {
    var ID = $(button).val();

    $.ajax({
        url: "/FoodApi/RemoveFood?ID=" + ID, // Pass the ID in the URL
        type: 'DELETE',
        dataType: 'json',
        contentType: 'application/json',
        success: function (response) {
            // Handle success response
            $(button).closest("tr").remove();
            swal("Food Item Removed");
        },
        error: function (error) {
            // Handle error response
            swal("Something Went Wrong");
        }
    });
}



//Edit Veg Food
function EditVegFood(button) {
    var row = $(button).closest("tr");
    var userInput = row.find('input[name="fooditems1"]').val();
    var editIcon = $(button).attr('data-id');
    swal("Food Item Removed");
    $.ajax({
        url: "/FoodApi/UpdateFood?ID=" + editIcon + "&foodItemName=" + userInput, // Pass the ID in the URL
        type: 'PATCH',
        dataType: 'json',
        contentType: 'application/json',
        success: function (response) {
            // Handle success response
            $(button).closest("tr").remove();
            swal("Food Item Removed");
        },
        error: function (error) {
            // Handle error response
            swal("Something Went Wrong");
        }
    });

   

}
