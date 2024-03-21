function solve(name, lastName, hairColor) {
    const person = {
        name,
        lastName,
        hairColor,
    };

    const personObjectToJSON = JSON.stringify(person);
    console.log(personObjectToJSON);
}

solve('George', 'Jones', 'Brown');
solve('Peter', 'Smith', 'Blond');