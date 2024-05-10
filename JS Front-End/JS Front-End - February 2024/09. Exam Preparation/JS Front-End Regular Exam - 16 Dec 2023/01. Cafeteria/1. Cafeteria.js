function solve(params) {
    const baristasWithTheirShiftAndCoffees = [];
    const baristasCount = Number(params.shift());
    for (let i = 0; i < baristasCount; i++) {
        const [name, shift, coffeeTypes] = params.shift().split(' ');
        const barista = {
            name,
            shift,
            coffeeTypes: coffeeTypes.split(','),
        };

        baristasWithTheirShiftAndCoffees.push(barista);
    }

    while (true) {
        const input = params.shift();
        if (input === 'Closed') {
            for (const barista of baristasWithTheirShiftAndCoffees) {
                console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${barista.coffeeTypes.join(', ')}`);
            }

            break;
        }

        const [action, baristaName, ...furtherDetails] = input.split(' / ');
        const selectedBarista = baristasWithTheirShiftAndCoffees.find(barista => barista.name === baristaName);

        if (action === 'Prepare') {
            const [shift, coffeeType] = furtherDetails;
            if (selectedBarista.shift !== shift || !selectedBarista.coffeeTypes.includes(coffeeType)) {
                console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
            } else {
                console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
            }
        } else if (action === 'Change Shift') {
            const shift = furtherDetails.shift();
            selectedBarista.shift = shift;
            console.log(`${baristaName} has updated his shift to: ${shift}`);
        } else if (action === 'Learn') {
            const coffeeType = furtherDetails.shift();
            if (selectedBarista.coffeeTypes.includes(coffeeType)) {
                console.log(`${baristaName} knows how to make ${coffeeType}.`);
            } else {
                selectedBarista.coffeeTypes.push(coffeeType);
                console.log(`${baristaName} has learned a new coffee type: ${coffeeType}.`);
            }
        }
    }
}

solve([

    '3',
    
    'Alice day Espresso,Cappuccino',
    
    'Bob night Latte,Mocha',
    
    'Carol day Americano,Mocha',
    
    'Prepare / Alice / day / Espresso',
    
    'Change Shift / Bob / night',
    
    'Learn / Carol / Latte',
    
    'Learn / Bob / Latte',
    
    'Prepare / Bob / night / Latte',
    
    'Closed']);