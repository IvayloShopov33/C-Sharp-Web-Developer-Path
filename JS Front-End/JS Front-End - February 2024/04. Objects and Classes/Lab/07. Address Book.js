function solve(peopleDetails) {
    const addressBook = {};
    for (let i = 0; i < peopleDetails.length; i++) {
        const [personName, personAddress] = peopleDetails[i].split(':');
        addressBook[personName] = personAddress;
    }

    const sortedAddressBook = Object
        .entries(addressBook)
        .sort((a, b) => a[0].localeCompare(b[0]));

    const result = Object.fromEntries(sortedAddressBook);
    Object
        .keys(result)
        .forEach(propertyName => console.log(`${propertyName} -> ${result[propertyName]}`));
}

solve(['Tim:Doe Crossing', 'Bill:Nelson Place', 'Peter:Carlyle Ave', 'Bill:Ornery Rd']);