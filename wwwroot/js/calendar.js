$(document).ready(function() {
    var currentDate = new Date(); // Get current date
    var selectedDate = null; // Store the selected date

    // Render the initial calendar
    renderCalendar(currentDate);

    // Left arrow button click event
    $('.left-arrow').click(function() {
        currentDate.setDate(currentDate.getDate() - 1);
        renderCalendar(currentDate);
    });

    // Right arrow button click event
    $('.right-arrow').click(function() {
        currentDate.setDate(currentDate.getDate() + 1);
        renderCalendar(currentDate);
    });

    // Highlight rectangle on hover
    $(".calendar").on("mouseenter", ".day", function() {
        $(this).addClass("hover");
    });

    $(".calendar").on("mouseleave", ".day", function() {
        $(this).removeClass("hover");
    });

    // Add Meal button click event
    $('#add-meal-btn').click(function() {
        $('#add-meal-modal').modal('show');
    });

    // Save Meal button click event
    $('#save-meal-btn').click(function() {
        var foodType = $('#food-type').val();
        var calories = $('#calories').val();
        var mass = $('#mass').val();
        var mealType = $('#meal-type').val();

        var mealInfo = {
            foodType: foodType,
            calories: calories,
            mass: mass,
            mealType: mealType
        };

        addMealInfo(mealInfo);
        $('#add-meal-modal').modal('hide');
    });

    // Day click event to select and deselect rectangles
    $(".calendar").on("click", ".day", function() {
        var clickedDate = $(this).text().trim(); // Get the clicked date

        if (selectedDate === clickedDate) {
            // Deselect the rectangle if it's already selected
            $(this).removeClass("selected");
            selectedDate = null;
        } else {
            // Deselect any previously selected rectangle
            $(".day.selected").removeClass("selected");
            // Select the clicked rectangle
            $(this).addClass("selected");
            selectedDate = clickedDate;
        }
    });
});

function renderCalendar(date) {
    // Clear previous calendar
    $('.calendar').empty();

    // Populate days for the current month
    for (var i = -3; i <= 3; i++) {
        var day = new Date(date.getFullYear(), date.getMonth(), date.getDate() + i);
        $('.calendar').append('<div class="day">' + day.toLocaleString('default', { month: 'long', day: 'numeric' }) + '</div>'); // Display month and date
    }
}

function addMealInfo(mealInfo) {
    if (selectedDate) {
        var selectedRectangle = $(".day.selected");
        selectedRectangle.html('<em>' + mealInfo.foodType + '</em>'); // Add meal's name in italic font
        selectedRectangle.append('<div class="meal-info" style="display: none;">' +
            '<p><strong>Food Type:</strong> ' + mealInfo.foodType + '</p>' +
            '<p><strong>Calories:</strong> ' + mealInfo.calories + '</p>' +
            '<p><strong>Mass:</strong> ' + mealInfo.mass + 'g</p>' +
            '<p><strong>Meal Type:</strong> ' + mealInfo.mealType + '</p>' +
            '</div>');
        selectedRectangle.find("em").hover(function() {
            $(this).next(".meal-info").toggle();
        });
    }
}
