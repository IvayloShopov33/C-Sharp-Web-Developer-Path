function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/tasks';

    const locationInput = document.getElementById('location');
    const temperatureInput = document.getElementById('temperature');
    const dateInput = document.getElementById('date');

    const editWeatherButton = document.getElementById('edit-weather');
    const addWeatherButton = document.getElementById('add-weather');
    const weatherHistoryList = document.getElementById('list');
    let currentWeatherId;

    const loadWeatherHistoryButton = document.getElementById('load-history');
    loadWeatherHistoryButton.addEventListener('click', () => {
        loadWeatherHistory();
    });

    function loadWeatherHistory() {
        fetch(baseUrl)
            .then(response => response.json())
            .then(allWeatherDetails => {
                weatherHistoryList.textContent = '';
                const weatherFragment = document.createDocumentFragment();

                for (const weatherDetails in allWeatherDetails) {
                    const weatherData = allWeatherDetails[weatherDetails];
                    currentWeatherId = allWeatherDetails[weatherDetails]._id;
                    const weatherDiv = createNewWeatherDiv(currentWeatherId, weatherData);
                    weatherFragment.appendChild(weatherDiv);
                }

                weatherHistoryList.appendChild(weatherFragment);
                editWeatherButton.setAttribute('disabled', 'disabled');
            });
    }

    function createNewWeatherDiv(currentWeatherId, weather) {
        const weatherDiv = document.createElement('div');
        weatherDiv.classList.add('container');

        const location = document.createElement('h2');
        location.textContent = weather.location;
        weatherDiv.appendChild(location);

        const date = document.createElement('h3');
        date.textContent = weather.date;
        weatherDiv.appendChild(date);

        const temperature = document.createElement('h3');
        temperature.textContent = weather.temperature;
        temperature.id = 'celsius';
        weatherDiv.appendChild(temperature);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons-container');

        const changeWeatherButton = document.createElement('button');
        changeWeatherButton.classList.add('change-btn');
        changeWeatherButton.textContent = 'Change';
        buttonsDiv.appendChild(changeWeatherButton);

        changeWeatherButton.addEventListener('click', () => {
            locationInput.value = location.textContent;
            temperatureInput.value = temperature.textContent;
            dateInput.value = date.textContent;

            editWeatherButton.removeAttribute('disabled');
            addWeatherButton.setAttribute('disabled', 'disabled');

            weatherDiv.remove();
            editWeather(currentWeatherId);
        });

        const deleteWeatherButton = document.createElement('button');
        deleteWeatherButton.classList.add('delete-btn');
        deleteWeatherButton.textContent = 'Delete';
        buttonsDiv.appendChild(deleteWeatherButton);

        deleteWeatherButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentWeatherId}`, {
                method: 'DELETE',
            })
                .then(() => {
                    weatherDiv.remove();
                    loadWeatherHistory();
                });
        });

        weatherDiv.appendChild(buttonsDiv);

        return weatherDiv;
    }

    function editWeather(currentWeatherId) {
        editWeatherButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentWeatherId}`, {
                method: 'PUT',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    location: locationInput.value,
                    date: dateInput.value,
                    temperature: temperatureInput.value,
                    _id: currentWeatherId,
                }),
            })
                .then(() => {
                    loadWeatherHistory();

                    editWeatherButton.setAttribute('disabled', 'disablled');
                    addWeatherButton.removeAttribute('disabled');
                    currentWeatherId = null;

                    locationInput.value = '';
                    temperatureInput.value = '';
                    dateInput.value = '';
                });
        });
    }

    addWeatherButton.addEventListener('click', () => {
        if (!locationInput.value || !dateInput.value || !temperatureInput.value) {
            return;
        }

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                location: locationInput.value,
                date: dateInput.value,
                temperature: temperatureInput.value,
            }),
        })
            .then(() => {
                loadWeatherHistory();
                locationInput.value = '';
                temperatureInput.value = '';
                dateInput.value = '';
            });
    });
}

solve();