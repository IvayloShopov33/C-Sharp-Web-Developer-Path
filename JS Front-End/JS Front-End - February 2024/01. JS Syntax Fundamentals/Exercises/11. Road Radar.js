function roadRadar(speed, area) {
    let speedLimit = 0;
    if (area === 'motorway') {
        speedLimit = 130;
    } else if (area === 'interstate') {
        speedLimit = 90;
    } else if (area === 'city') {
        speedLimit = 50;
    } else if (area === 'residential') {
        speedLimit = 20;
    }

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        const speedDifference = speed - speedLimit;
        let exceededSpeedStatus = '';
        if (speedDifference <= 20) {
            exceededSpeedStatus = 'speeding';
        } else if (speedDifference <= 40) {
            exceededSpeedStatus = 'excessive speeding';
        } else {
            exceededSpeedStatus = 'reckless driving';
        }

        console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${exceededSpeedStatus}`);
    }
}