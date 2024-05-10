function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/tasks';
    const foodInput = document.getElementById('food');
    const timeInput = document.getElementById('time');
    const caloriesInput = document.getElementById('calories');
    const editMealButton = document.getElementById('edit-meal');
    const addMealButton = document.getElementById('add-meal');
    const todaysMeals = document.getElementById('list');
    let currentMealId;

    const loadMealsButton = document.getElementById('load-meals');
    loadMealsButton.addEventListener('click', () => {
        loadAllMeals();
    });

    function loadAllMeals() {
        fetch(baseUrl)
            .then(response => response.json())
            .then(meals => {
                todaysMeals.textContent = '';
                const mealsFragment = document.createDocumentFragment();
                for (const meal in meals) {
                    const mealData = meals[meal];
                    currentMealId = meals[meal]._id;
                    const mealDiv = createNewMealDiv(currentMealId, mealData);
                    mealsFragment.appendChild(mealDiv);
                }

                todaysMeals.appendChild(mealsFragment);
            });
    }

    function createNewMealDiv(currentMealId, meal) {
        const mealDiv = document.createElement('div');
        mealDiv.classList.add('meal');

        const food = document.createElement('h2');
        food.textContent = meal.food;
        mealDiv.appendChild(food);

        const time = document.createElement('h3');
        time.textContent = meal.time;
        mealDiv.appendChild(time);

        const calories = document.createElement('h3');
        calories.textContent = meal.calories;
        mealDiv.appendChild(calories);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.id = 'meal-buttons';

        const changeMealButton = document.createElement('button');
        changeMealButton.classList.add('change-meal');
        changeMealButton.textContent = 'Change';
        buttonsDiv.appendChild(changeMealButton);

        changeMealButton.addEventListener('click', () => {
            foodInput.value = food.textContent;
            timeInput.value = time.textContent;
            caloriesInput.value = calories.textContent;

            editMealButton.removeAttribute('disabled');
            addMealButton.setAttribute('disabled', 'disabled');
            mealDiv.remove();
            editMeal(currentMealId);
        });

        const deleteMealButton = document.createElement('button');
        deleteMealButton.classList.add('delete-meal');
        deleteMealButton.textContent = 'Delete';
        buttonsDiv.appendChild(deleteMealButton);

        deleteMealButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentMealId}`, {
                method: 'DELETE',
            });
            mealDiv.remove();
        });

        mealDiv.appendChild(buttonsDiv);

        return mealDiv;
    }

    function editMeal(currentMealId) {
        editMealButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentMealId}`, {
                method: 'PUT',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    food: foodInput.value,
                    calories: caloriesInput.value,
                    time: timeInput.value,
                    _id: currentMealId,
                }),
            })
                .then(response => response.json())
                .then(data => {
                    loadAllMeals();

                    foodInput.value = '';
                    timeInput.value = '';
                    caloriesInput.value = '';
                    editMealButton.setAttribute('disabled', 'disablled');
                    addMealButton.removeAttribute('disabled');
                    currentMealId = null;
                });
        });
    }

    addMealButton.addEventListener('click', () => {
        if (!foodInput.value || !caloriesInput.value || !timeInput.value) {
            return;
        }

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                food: foodInput.value,
                calories: caloriesInput.value,
                time: timeInput.value,
            }),
        });

        loadAllMeals();
        foodInput.value = '';
        timeInput.value = '';
        caloriesInput.value = '';
    })
}

solve();