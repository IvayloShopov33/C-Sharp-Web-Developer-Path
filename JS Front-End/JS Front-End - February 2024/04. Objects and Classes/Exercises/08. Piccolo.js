function solve(cars) {
    const parkingLot = {};
    for (const car of cars) {
        const [direction, carNumber] = car.split(', ');

        direction === 'IN'
            ? parkingLot[carNumber] = true
            : delete parkingLot[carNumber];
    }

    Object.keys(parkingLot).length !== 0
        ? Object
            .keys(parkingLot)
            .sort((a, b) => a.localeCompare(b))
            .forEach(carNumber => console.log(carNumber))
        : console.log('Parking Lot is Empty');
}

function setSolve(cars) {
    const parkingLot = new Set();
    for (const car of cars) {
        const [direction, carNumber] = car.split(', ');
        if (direction === 'IN') {
            parkingLot.add(carNumber);
        } else if (direction === 'OUT') {
            parkingLot.delete(carNumber);
        }
    }

    if (parkingLot.size === 0) {
        console.log('Parking Lot is Empty');
    } else {
        const carNumbers = Array.from(parkingLot).sort((a, b) => a.localeCompare(b));

        for (const carNumber of carNumbers) {
            console.log(carNumber);
        }
    }
}

setSolve(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'IN, CA9999TT', 'IN, CA2866HI',
    'OUT, CA1234TA', 'IN, CA2844AA', 'OUT, CA2866HI', 'IN, CA9876HH', 'IN, CA2822UU']);

setSolve(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'OUT, CA1234TA']);

solve(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'IN, CA9999TT', 'IN, CA2866HI',
    'OUT, CA1234TA', 'IN, CA2844AA', 'OUT, CA2866HI', 'IN, CA9876HH', 'IN, CA2822UU']);

solve(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'OUT, CA1234TA']);