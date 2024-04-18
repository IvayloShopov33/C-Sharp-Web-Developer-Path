function attachEventsListeners() {
    const convertDistanceButtonElement = document.getElementById('convert');

    convertDistanceButtonElement.addEventListener('click', () => {
        const inputDistance = document.getElementById('inputDistance');
        const outputDistance = document.getElementById('outputDistance');

        const inputDistanceValue = Number(inputDistance.value);
        if (!inputDistanceValue) {
            outputDistance.value = 'Invalid input!';
            return;
        }

        const inputUnitsListElement = document.getElementById('inputUnits');
        const selectedInputUnitValue = inputUnitsListElement.options[inputUnitsListElement.selectedIndex].value;
        let metersUnit = 0;

        switch (selectedInputUnitValue) {
            case 'km':
                metersUnit = inputDistanceValue * 1000;
                break;
            case 'm':
                metersUnit = inputDistanceValue;
                break;
            case 'cm':
                metersUnit = inputDistanceValue / 100;
                break;
            case 'mm':
                metersUnit = inputDistanceValue / 1000;
                break;
            case 'mi':
                metersUnit = inputDistanceValue * 1609.34;
                break;
            case 'yrd':
                metersUnit = inputDistanceValue * 0.9144;
                break;
            case 'ft':
                metersUnit = inputDistanceValue * 0.3048;
                break;
            case 'in':
                metersUnit = inputDistanceValue * 0.0254;
                break;
        };

        const outputUnitsListElement = document.getElementById('outputUnits');
        const selectedOutputUnitValue = outputUnitsListElement.options[outputUnitsListElement.selectedIndex].value;
        let outputDistanceValue = 0;

        switch (selectedOutputUnitValue) {
            case 'km':
                outputDistanceValue = metersUnit / 1000;
                break;
            case 'm':
                outputDistanceValue = metersUnit;
                break;
            case 'cm':
                outputDistanceValue = metersUnit * 100;
                break;
            case 'mm':
                outputDistanceValue = metersUnit * 1000;
                break;
            case 'mi':
                outputDistanceValue = metersUnit / 1609.34;
                break;
            case 'yrd':
                outputDistanceValue = metersUnit / 0.9144;
                break;
            case 'ft':
                outputDistanceValue = metersUnit / 0.3048;
                break;
            case 'in':
                outputDistanceValue = metersUnit / 0.0254;
                break;
        };

        outputDistance.value = outputDistanceValue;
    });
}