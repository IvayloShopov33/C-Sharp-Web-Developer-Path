function solve(cityDetails) {
    Object
        .keys(cityDetails)
        .forEach(propertyName => console.log(`${propertyName} -> ${cityDetails[propertyName]}`));
}

solve({ name: "Plovdiv", area: 389, population: 1162358, country: "Bulgaria", postCode: "4000" });