// scripts.js

function addFood() {
    // Get values from input fields
    var foodName = document.getElementById("food-name").value;
    var calories = parseInt(document.getElementById("calories").value);
    var portion = parseInt(document.getElementById("portion").value);

    // Create a new food object
    var food = {
        name: foodName,
        calories: calories,
        portion: portion
    };

    // Call a function to add the food to the diary
    addToDiary(food);
}

function addToDiary(food) {
    // Display the added food in the diary section
    var diaryDiv = document.getElementById("diary");
    var foodEntry = document.createElement("div");
    foodEntry.innerHTML = "<p><strong>Food Name:</strong> " + food.name + "</p>" +
                          "<p><strong>Calories:</strong> " + food.calories + "</p>" +
                          "<p><strong>Portion (grams):</strong> " + food.portion + "</p>";
    diaryDiv.appendChild(foodEntry);
}
