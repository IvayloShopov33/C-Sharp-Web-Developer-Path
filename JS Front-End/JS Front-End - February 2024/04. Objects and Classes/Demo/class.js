class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    greet(to) {
        console.log(`${this.firstName} says hello to ${to}`);
    }
}

const personObject = new Person('Ivaylo', 'Shopov');
const personObject2 = new Person('Leo', 'Messi');

console.log(personObject);
console.log(personObject2);

personObject.greet('Spas');
personObject2.greet('Ronaldo');