function attachEventsListeners() {
    const convertDaysButton = document.getElementById('daysBtn');
    const convertHoursButton = document.getElementById('hoursBtn');
    const convertMinutesButton = document.getElementById('minutesBtn');
    const convertSecondsButton = document.getElementById('secondsBtn');

    const inputDaysElement = document.getElementById('days');
    const inputHoursElement = document.getElementById('hours');
    const inputMinutesElement = document.getElementById('minutes');
    const inputSecondsElement = document.getElementById('seconds');

    let days = 0;
    let hours = 0;
    let minutes = 0;
    let seconds = 0;

    convertDaysButton.addEventListener('click', () => {
        days = Number(inputDaysElement.value);
        hours = days * 24;
        minutes = hours * 60;
        seconds = minutes * 60;

        inputHoursElement.value = hours;
        inputMinutesElement.value = minutes;
        inputSecondsElement.value = seconds;
    });

    convertHoursButton.addEventListener('click', () => {
        hours = Number(inputHoursElement.value);
        minutes = hours * 60;
        seconds = minutes * 60;
        days = hours / 24;

        inputDaysElement.value = days;
        inputMinutesElement.value = minutes;
        inputSecondsElement.value = seconds;
    });

    convertMinutesButton.addEventListener('click', () => {
        minutes = Number(inputMinutesElement.value);
        seconds = minutes * 60;
        hours = minutes / 60;
        days = hours / 24;

        inputDaysElement.value = days;
        inputHoursElement.value = hours;
        inputSecondsElement.value = seconds;
    });

    convertSecondsButton.addEventListener('click', () => {
        seconds = Number(inputSecondsElement.value);
        minutes = seconds / 60;
        hours = minutes / 60;
        days = hours / 24;

        inputDaysElement.value = days;
        inputHoursElement.value = hours;
        inputMinutesElement.value = minutes;
    });
}