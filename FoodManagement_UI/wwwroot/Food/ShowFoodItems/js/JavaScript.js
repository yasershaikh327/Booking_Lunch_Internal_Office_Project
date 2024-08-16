function Reminder() {

    //swal("", "Please Login To Book!", "warning");
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
                document.getElementById("flexRadioDefault2").disabled = true;
                document.getElementById("nonveg").style.color = "#c5c5c8";
                return false;
            }

        })
        .catch(error => {
            console.error('Error:', error);
        });
}