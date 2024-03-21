//Create an object
const person = { name: 'Ivaylo', age: 17 };

//Create an object with non-classic identifier
const person2 = { 'full-name': 'Spas Nedelev' };

//Get property from object - dot syntax and bracket syntax
console.log(person.age);
console.log(person['name']);
console.log(person2['full-name']);

//Create an empty object and dynamically add values
const animal = {};

//Add with dot syntax
animal.name = 'Prascho';

//Add with bracket syntax
animal['max-weight'] = 50;

//Add dynamic name property
const propName = 'breed';
animal[propName] = 'Labrador';

console.log(animal);

//Add dynamic name property in the literal
const dynamicPropName = 'last_Name';
const person3 = { [dynamicPropName]: 'Shopov' };
console.log(person3[dynamicPropName]);

//Object literal with shorthand syntax
const firstName = 'Spasimir';
const lastName = "Dobrev";
const personInfo = {
    firstName,
    lastName,
};

console.log(personInfo.firstName);
console.log(personInfo.lastName);

//Get undefined property
console.log(animal.age);

//Delete an entry from object
delete personInfo.firstName;
console.log(personInfo);

//Object destructuring assignment
const person4 = { name: 'Pesho', age: 16 };
const { age, name } = person4;
console.log(age);

//Object destructuring assignment with rest operator
const { name: animalName, ...restInfoOfTheAnimal } = animal;
console.log(animalName);
console.log(restInfoOfTheAnimal);