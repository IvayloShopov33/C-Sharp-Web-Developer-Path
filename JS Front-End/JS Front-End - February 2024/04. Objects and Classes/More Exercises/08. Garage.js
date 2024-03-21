function solve(garagesWithCars) {
    const garages = {};
    ArrangeCarsInGarages(garagesWithCars, garages);

    PrintGaragesWithCarsInThem(garages);
}

function ArrangeCarsInGarages(garagesWithCars, garages) {
    for (const garageWithCar of garagesWithCars) {
        let [garageNumber, carDetails] = garageWithCar.split(' - ');
        carDetails = carDetails.split(', ');
        const car = {};

        for (const carDetail of carDetails) {
            const [detailKey, detailValue] = carDetail.split(': ');
            car[detailKey] = detailValue;
        }

        if (!garages[garageNumber]) {
            garages[garageNumber] = [];
        }

        garages[garageNumber].push(car);
    }
}

function PrintGaragesWithCarsInThem(garages) {
    for (const garage in garages) {
        console.log(`Garage № ${garage}`);
        for (const car of garages[garage]) {
            const carDetailsPrint = [];
            for (const propertyName in car) {
                carDetailsPrint.push(`${propertyName} - ${car[propertyName]}`);
            }
            console.log(`--- ${carDetailsPrint.join(', ')}`);
        }
    }
}

solve(['1 - color: blue, fuel type: diesel', '1 - color: red, manufacture: Audi',
    '2 - fuel type: petrol', '4 - color: dark blue, fuel type: diesel, manufacture: Fiat']);