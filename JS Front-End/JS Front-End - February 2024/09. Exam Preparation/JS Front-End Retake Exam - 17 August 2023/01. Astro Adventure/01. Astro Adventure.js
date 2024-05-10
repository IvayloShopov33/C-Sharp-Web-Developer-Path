function solve(input) {
    const astronautsCount = Number(input.shift());
    const astronauts = [];

    for (let i = 0; i < astronautsCount; i++) {
        const [name, oxygenLevel, energy] = input.shift().split(' ');
        const astronaut = {
            name,
            oxygenLevel: Number(oxygenLevel),
            energy: Number(energy),
        };

        astronauts.push(astronaut);
    }

    while (true) {
        const [action, name, furtherDetails] = input.shift().split(' - ');
        if (action === 'End') {
            for (const astronaut of astronauts) {
                console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxygenLevel}, Energy: ${astronaut.energy}`);
            }

            break;
        }

        const selectedAstronaut = astronauts.find(astronaut => astronaut.name === name);
        if (action === 'Explore') {
            const energyNeeded = Number(furtherDetails);

            if (selectedAstronaut.energy >= energyNeeded) {
                selectedAstronaut.energy -= energyNeeded;
                console.log(`${selectedAstronaut.name} has successfully explored a new area and now has ${selectedAstronaut.energy} energy!`);
            } else {
                console.log(`${selectedAstronaut.name} does not have enough energy to explore!`);
            }
        } else if (action === 'Refuel') {
            const energyAmount = Number(furtherDetails);
            selectedAstronaut.energy += energyAmount;
            let energyRecovered = energyAmount;

            if (selectedAstronaut.energy > 200) {
                energyRecovered = 200 - (selectedAstronaut.energy - energyAmount);
                selectedAstronaut.energy = 200;
            }

            console.log(`${selectedAstronaut.name} refueled their energy by ${energyRecovered}!`);
        } else if (action === 'Breathe') {
            const oxygenAmount = Number(furtherDetails);
            selectedAstronaut.oxygenLevel += oxygenAmount;
            let oxygenRecovered = oxygenAmount;

            if (selectedAstronaut.oxygenLevel > 100) {
                oxygenRecovered = 100 - (selectedAstronaut.oxygenLevel - oxygenAmount);
                selectedAstronaut.oxygenLevel = 100;
            }

            console.log(`${selectedAstronaut.name} took a breath and recovered ${oxygenRecovered} oxygen!`);
        }
    }
}

solve(['3',
    'John 50 120',
    'Kate 80 180',
    'Rob 70 150',
    'Explore - John - 50',
    'Refuel - Kate - 30',
    'Breathe - Rob - 20',
    'End']);

solve(['4',
    'Alice 60 100',
    'Bob 40 80',
    'Charlie 70 150',
    'Dave 80 180',
    'Explore - Bob - 60',
    'Refuel - Alice - 30',
    'Breathe - Charlie - 50',
    'Refuel - Dave - 40',
    'Explore - Bob - 40',
    'Breathe - Charlie - 30',
    'Explore - Alice - 40',
    'End']);