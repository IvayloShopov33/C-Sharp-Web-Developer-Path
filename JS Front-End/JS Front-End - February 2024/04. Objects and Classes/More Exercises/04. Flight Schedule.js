function solve(flightsDetails) {
    const flights = {};
    const allFlights = flightsDetails.shift();
    TakeAllFlightsDetails(flights, allFlights);

    const flightsWithChangedStatuses = flightsDetails.shift();
    ChangeStatusOfGivenFlights(flights, flightsWithChangedStatuses);

    const flightStatusToCheck = flightsDetails.shift().shift();
    let flightsToTakeOff = [];
    PrintFlightsDetails(flights, flightStatusToCheck, flightsToTakeOff);
}

function TakeAllFlightsDetails(flights, allFlights) {
    for (const currentFlight of allFlights) {
        const [airportSector, ...Destination] = currentFlight.split(' ');
        const flight = {
            Destination: Destination.join(' '),
            Status: 'Ready to fly',
        };

        flights[airportSector] = flight;
    }
}

function ChangeStatusOfGivenFlights(flights, flightsWithChangedStatuses) {
    for (const currentFlight of flightsWithChangedStatuses) {
        const [airportSector, Status] = currentFlight.split(' ');
        if (flights[airportSector]) {
            flights[airportSector].Status = Status;
        }
    }
}

function PrintFlightsDetails(flights, flightStatusToCheck, flightsToTakeOff) {
    if (flightStatusToCheck === 'Ready to fly') {
        flightsToTakeOff = Array.from(Object.values(flights)).filter(flight => flight.Status === 'Ready to fly');
    } else {
        flightsToTakeOff = Array.from(Object.values(flights)).filter(flight => flight.Status === 'Cancelled');
    }

    for (let i = 0; i < flightsToTakeOff.length; i++) {
        console.log(flightsToTakeOff[i]);
    }
}

solve([['WN269 Delaware', 'FL2269 Oregon', 'WN498 Las Vegas', 'WN3145 Ohio', 'WN612 Alabama',
    'WN4010 New York', 'WN1173 California', 'DL2120 Texas', 'KL5744 Illinois', 'WN678 Pennsylvania'],
['DL2120 Cancelled', 'WN612 Cancelled', 'WN1173 Cancelled', 'SK330 Cancelled'], ['Ready to fly']]);

solve([['WN269 Delaware', 'FL2269 Oregon', 'WN498 Las Vegas', 'WN3145 Ohio', 'WN612 Alabama',
    'WN4010 New York', 'WN1173 California', 'DL2120 Texas', 'KL5744 Illinois', 'WN678 Pennsylvania'],
['DL2120 Cancelled', 'WN612 Cancelled', 'WN1173 Cancelled', 'SK430 Cancelled'], ['Cancelled']]);