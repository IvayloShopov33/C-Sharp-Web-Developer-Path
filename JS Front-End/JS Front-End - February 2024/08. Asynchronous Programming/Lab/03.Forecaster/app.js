function attachEvents() {
    const locationElement = document.getElementById('location');
    const submitButton = document.getElementById('submit');

    submitButton.addEventListener('click', () => {
        const forecastDivElement = document.getElementById('forecast');
        forecastDivElement.style.display = 'block';

        const forecastURL = 'http://localhost:3030/jsonstore/forecaster';
        const weatherSymbols = {
            'Sunny': '☀',
            'Partly sunny': '⛅',
            'Overcast': '☁',
            'Rain': '☂',
            'Degrees': '°',
        };

        fetch(`${forecastURL}/locations`)
            .then(response => response.json())
            .then(locations => {
                const location = locations.find(loc => loc.name === locationElement.value);

                return Promise.all([
                    fetch(`${forecastURL}/today/${location.code}`),
                    fetch(`${forecastURL}/upcoming/${location.code}`),
                ]);
            })
            .then(responses => Promise.all(responses.map(res => res.json())))
            .then(([todayWeather, upcomindWeather]) => {
                const currentWeather = document.getElementById('current');
                const forecastsNewDivElement = document.createElement('div');
                forecastsNewDivElement.classList.add('forecasts');

                const todayWeatherCondition = todayWeather.forecast;
                const spansFragment = document.createDocumentFragment();

                const spanConditionSymbol = document.createElement('span');
                spanConditionSymbol.classList.add('condition');
                spanConditionSymbol.classList.add('symbol');
                spanConditionSymbol.textContent = weatherSymbols[todayWeatherCondition.condition];

                const spanCondition = document.createElement('span');
                spanCondition.classList.add('condition');

                const spanLocation = document.createElement('span');
                spanLocation.classList.add('forecast-data');
                spanLocation.textContent = todayWeather.name;
                spanCondition.appendChild(spanLocation);

                const spanTemperatures = document.createElement('span');
                spanTemperatures.classList.add('forecast-data');
                spanTemperatures.textContent =
                    `${todayWeatherCondition.low}${weatherSymbols['Degrees']}/${todayWeatherCondition.high}${weatherSymbols['Degrees']}`;
                spanCondition.appendChild(spanTemperatures);

                const spanWeather = document.createElement('span');
                spanWeather.classList.add('forecast-data');
                spanWeather.textContent = todayWeatherCondition.condition;
                spanCondition.appendChild(spanWeather);

                spansFragment.appendChild(spanConditionSymbol);
                spansFragment.appendChild(spanCondition);

                forecastsNewDivElement.appendChild(spansFragment);
                currentWeather.appendChild(forecastsNewDivElement);

                const upcomingWeatherForecast = document.getElementById('upcoming');
                const newDivElement = document.createElement('div');
                newDivElement.classList.add('forecast-info');

                for (const dailyForecast of upcomindWeather.forecast) {
                    const spanPerUpcomingDay = document.createElement('span');
                    spanPerUpcomingDay.classList.add('upcoming');

                    const spanSymbol = document.createElement('span');
                    spanSymbol.classList.add('symbol');
                    spanSymbol.textContent = weatherSymbols[dailyForecast.condition];

                    const spanUpcomingTemperatures = document.createElement('span');
                    spanUpcomingTemperatures.classList.add('forecast-data');
                    spanUpcomingTemperatures.textContent = `${dailyForecast.low}${weatherSymbols['Degrees']}/${dailyForecast.high}${weatherSymbols['Degrees']}`;

                    const spanUpcomingWeather = document.createElement('span');
                    spanUpcomingWeather.classList.add('forecast-data');
                    spanUpcomingWeather.textContent = `${dailyForecast.condition}`;

                    spanPerUpcomingDay.appendChild(spanSymbol);
                    spanPerUpcomingDay.appendChild(spanUpcomingTemperatures);
                    spanPerUpcomingDay.appendChild(spanUpcomingWeather);

                    newDivElement.appendChild(spanPerUpcomingDay);
                }

                upcomingWeatherForecast.appendChild(newDivElement);
            })
            .catch(() => locationElement.value = 'Something went wrong');
    });
}

attachEvents();