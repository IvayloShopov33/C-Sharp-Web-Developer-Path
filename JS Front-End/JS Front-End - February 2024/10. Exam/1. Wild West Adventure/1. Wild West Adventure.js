function solve(params) {
    const heroesCount = Number(params.shift());
    let heroes = [];
    for (let i = 0; i < heroesCount; i++) {
        const [name, hp, bullets] = params.shift().split(' ');
        const hero = {
            name,
            hp: Number(hp),
            bullets: Number(bullets),
        };

        heroes.push(hero);
    }

    while (true) {
        const input = params.shift();
        if (input === 'Ride Off Into Sunset') {
            for (const hero of heroes) {
                console.log(hero.name);
                console.log(`HP: ${hero.hp}`);
                console.log(`Bullets: ${hero.bullets}`);
            }

            break;
        }

        const [action, heroName, ...furtherDetails] = input.split(' - ');
        const selectedHero = heroes.find(hero => hero.name === heroName);

        if (selectedHero) {
            if (action === 'FireShot') {
                const target = furtherDetails.shift();
                if (selectedHero.bullets > 0) {
                    selectedHero.bullets--;
                    console.log(`${selectedHero.name} has successfully hit ${target} and now has ${selectedHero.bullets} bullets!`);
                } else {
                    console.log(`${selectedHero.name} doesn't have enough bullets to shoot at ${target}!`);
                }
            } else if (action === 'TakeHit') {
                const damage = Number(furtherDetails.shift());
                const attacker = furtherDetails.shift();
                selectedHero.hp -= damage;

                if (selectedHero.hp > 0) {
                    console.log(`${selectedHero.name} took a hit for ${damage} HP from ${attacker} and now has ${selectedHero.hp} HP!`);
                } else {
                    heroes = heroes.filter(hero => hero.name !== selectedHero.name);
                    console.log(`${selectedHero.name} was gunned down by ${attacker}!`);
                }
            } else if (action === 'Reload') {
                if (selectedHero.bullets < 6) {
                    console.log(`${selectedHero.name} reloaded ${6 - selectedHero.bullets} bullets!`);
                    selectedHero.bullets = 6;
                } else {
                    console.log(`${selectedHero.name}'s pistol is fully loaded!`);
                }
            } else if (action === 'PatchUp') {
                if (selectedHero.hp === 100) {
                    console.log(`${selectedHero.name} is in full health!`);
                } else {
                    const amountOfHp = Number(furtherDetails.shift());
                    selectedHero.hp += amountOfHp;
                    let amountRecovered = amountOfHp;
                    if (selectedHero.hp > 100) {
                        amountRecovered = 100 - (selectedHero.hp - amountOfHp);
                    }

                    console.log(`${selectedHero.name} patched up and recovered ${amountRecovered} HP!`);
                }
            }
        }
    }
}

solve(["2",
    "Gus 100 0",
    "Walt 100 6",
    "FireShot - Gus - Bandit",
    "TakeHit - Gus - 100 - Bandit",
    "Reload - Walt",
    "Ride Off Into Sunset"]);

solve(["2",
    "Jesse 100 4",
    "Walt 100 5",
    "FireShot - Jesse - Bandit",
    "TakeHit - Walt - 30 - Bandit",
    "PatchUp - Walt - 20",
    "Reload - Jesse",
    "Ride Off Into Sunset"]);

solve(["2",
    "Gus 100 4",
    "Walt 100 5",
    "FireShot - Gus - Bandit",
    "TakeHit - Walt - 100 - Bandit",
    "Reload - Gus",
    "Ride Off Into Sunset"]);