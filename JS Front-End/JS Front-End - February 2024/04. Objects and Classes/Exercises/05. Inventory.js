function setSolve(heroesInput) {
    const heroes = [];
    for (const heroInput of heroesInput) {
        const [name, level, items] = heroInput.split(' / ');
        const hero = {
            name,
            level: Number(level),
            items,
        }

        heroes.push(hero);
    }

    for (const hero of heroes.sort((a, b) => a.level - b.level)) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    }
}

function solveFancy(heroesInput) {
    heroesInput
        .map(row => {
            const [name, level, items] = row.split(' / ');

            return {
                name,
                level: Number(level),
                items,
            };
        })
        .sort((a, b) => a.level - b.level)
        .forEach(hero => {
            console.log(`Hero: ${hero.name}`);
            console.log(`level => ${hero.level}`);
            console.log(`items => ${hero.items}`);
        });
}

setSolve(['Isacc / 25 / Apple, GravityGun', 'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);

solveFancy(['Isacc / 25 / Apple, GravityGun', 'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);