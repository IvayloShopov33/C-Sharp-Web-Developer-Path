function solve() {
    const busDepartButtonElement = document.getElementById('depart');
    const busArriveButtonElement = document.getElementById('arrive');
    const infoSpanElement = document.querySelector('#info .info');

    const baseURL = 'http://localhost:3030/jsonstore/bus/schedule';
    let nextBusStopId = 'depot';
    let busStopName = '';

    function depart() {
        fetch(`${baseURL}/${nextBusStopId}`)
            .then(response => response.json())
            .then(busStopData => {
                busStopName = busStopData.name;
                nextBusStopId = busStopData.next;

                infoSpanElement.textContent = `Next stop ${busStopName}`;
                busDepartButtonElement.setAttribute('disabled', 'disabled');
                busArriveButtonElement.removeAttribute('disabled');
            })
            .catch(() => {
                infoSpanElement.textContent = 'Error';
                busDepartButtonElement.setAttribute('disabled', 'disabled');
                busArriveButtonElement.setAttribute('disabled', 'disabled');
            });
    }

    async function arrive() {
        infoSpanElement.textContent = `Arriving at ${busStopName}`;
        busArriveButtonElement.setAttribute('disabled', 'disabled');
        busDepartButtonElement.removeAttribute('disabled');
    }

    return {
        depart,
        arrive
    };
}

let result = solve();