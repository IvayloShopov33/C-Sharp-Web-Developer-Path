function solve(jsonString) {
    const objectData = JSON.parse(jsonString);
    Object
        .keys(objectData)
        .forEach(propertyName => console.log(`${propertyName}: ${objectData[propertyName]}`));
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');
solve('{"name": "Peter", "age": 35, "town": "Plovdiv"}');