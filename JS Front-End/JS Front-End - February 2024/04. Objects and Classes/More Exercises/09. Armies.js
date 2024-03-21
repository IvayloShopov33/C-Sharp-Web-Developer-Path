function solve(input) {
    let leadersWithTheirArmies = {};
    ArrangeArmiesWithTheirLeaders(input, leadersWithTheirArmies);

    const sortedLeaders = Object.entries(leadersWithTheirArmies).sort((a, b) => b[1].totalCountOfArmies - a[1].totalCountOfArmies);
    leadersWithTheirArmies = Object.fromEntries(sortedLeaders);
    PrintLeadersAndTheirArmies(leadersWithTheirArmies);
}

function ArrangeArmiesWithTheirLeaders(input, leadersWithTheirArmies) {
    for (const line of input) {
        if (line.includes('arrives')) {
            const leader = line.slice(0, line.indexOf(' arrives'));
            leadersWithTheirArmies[leader] = {
                totalCountOfArmies: 0,
                armies: []
            };
        } else if (line.includes(':')) {
            const [leader, armyDetails] = line.split(': ');
            if (leadersWithTheirArmies[leader]) {
                const [name, count] = armyDetails.split(', ');
                const army = {
                    name,
                    count: Number(count),
                };

                leadersWithTheirArmies[leader].totalCountOfArmies += army.count;
                leadersWithTheirArmies[leader].armies.push(army);
            }
        } else if (line.includes('+')) {
            const [name, count] = line.split(' + ');

            for (const leader in leadersWithTheirArmies) {
                const selectedArmy = leadersWithTheirArmies[leader].armies.find(army => army.name === name);
                if (selectedArmy) {
                    selectedArmy.count += Number(count);
                    leadersWithTheirArmies[leader].totalCountOfArmies += Number(count);
                    break;
                }
            }
        } else if (line.includes('defeated')) {
            const leader = line.slice(0, line.indexOf(' defeated'));
            if (leadersWithTheirArmies[leader]) {
                delete leadersWithTheirArmies[leader];
            }
        }
    }
}

function PrintLeadersAndTheirArmies(leadersWithTheirArmies) {
    for (const leader in leadersWithTheirArmies) {
        console.log(`${leader}: ${leadersWithTheirArmies[leader].totalCountOfArmies}`);
        for (const army of leadersWithTheirArmies[leader].armies.sort((a, b) => b.count - a.count)) {
            console.log(`>>> ${army.name} - ${army.count}`);
        }
    }
}

solve(['Rick Burr arrives', 'Findlay arrives', 'Rick Burr: Juard, 1500',
    'Wexamp arrives', 'Findlay: Wexamp, 34540', 'Wexamp + 340', 'Wexamp: Britox, 1155', 'Wexamp: Juard, 43423']);

solve(['Rick Burr arrives', 'Fergus:Wexamp, 30245', 'Rick Burr: Juard, 50000', 'Findlay arrives', 'Findlay: Britox, 34540', 'Wexamp + 6000',
    'Juard + 1350', 'Britox + 4500', 'Porter arrives', 'Porter: Legion, 55000', 'Legion + 302', 'Rick Burr defeated', 'Porter: Retix, 3205']);