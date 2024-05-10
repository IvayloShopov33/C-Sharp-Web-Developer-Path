function getInfo() {
    const busStopsURL = 'http://localhost:3030/jsonstore/bus/businfo';

    const stopIdElement = document.getElementById('stopId');
    const busStopNameElement = document.getElementById('stopName');
    const busesElement = document.getElementById('buses');

    fetch(`${busStopsURL}/${stopIdElement.value}`)
        .then(response => response.json())
        .then(data => {
            busStopNameElement.textContent = data.name;
            const busesLiElementsFragment = document.createDocumentFragment();
            for (const bus in data.buses) {
                const busLiElement = document.createElement('li');
                busLiElement.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
                busesLiElementsFragment.appendChild(busLiElement);
            }

            busesElement.appendChild(busesLiElementsFragment);
        })
        .catch(() => busStopNameElement.textContent = 'Error');
}