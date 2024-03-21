//Associative Arrays declaration
const fullName = 'Cillian Murphy';

let phoneBook = {
    'Ivan Ivanov': '+35988123123',
    'Cristiano Ronaldo': '+35988777777',
    [fullName]: '+359191920',
};

phoneBook['Leo Messi'] = '+35988101010';

//Use for-in loop (looping through object's keys)
for (const name in phoneBook) {
    console.log(`${name} -> ${phoneBook[name]}`);
}

//Equivalent with for-of loop
for (const name of Object.keys(phoneBook)) {
    console.log(`${name} -> ${phoneBook[name]}`);
}

//Check if person has value in the phonebook
if (phoneBook['Grigor Dimitrov']) {
    console.log('Phone Found');
} else {
    console.log('Phone Not Found');
}

//Check if property name exists
if (phoneBook.hasOwnProperty('Grigor Dimitrov')) {
    console.log('Name Found');
} else {
    console.log('Name Not Found');
}

console.log('Grigor Dimitrov' in phoneBook);

//Sort an object
let sortedPhoneBook = Object
    .entries(phoneBook)
    .sort((a, b) => a[0].localeCompare(b[0]));

console.log(sortedPhoneBook);
console.log(Object.fromEntries(sortedPhoneBook));