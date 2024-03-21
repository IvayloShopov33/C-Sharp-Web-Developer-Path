function solve(namesAndNumbers) {
    const phoneBook = {};
    for (let i = 0; i < namesAndNumbers.length; i++) {
        const [name, number] = namesAndNumbers[i].split(' ');
        phoneBook[name] = number;
    }

    Object
        .keys(phoneBook)
        .forEach(propertyName => console.log(`${propertyName} -> ${phoneBook[propertyName]}`));
}

solve(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']);
solve(['George 0552554', 'Peter 087587', 'George 0453112', 'Bill 0845344']);