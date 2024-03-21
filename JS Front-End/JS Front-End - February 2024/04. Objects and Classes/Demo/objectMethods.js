//Define method in object literal with function expression

const cat = {
    name: 'Misho',
    breed: 'Persian',
    age: 8,
    grades: [6, 6, 5, 6, 4],
    owner: {
        name: 'Mitko',
        age: 17,
    },
    makeSound: function () {
        console.log('Meow...');
    },
    sleep: () => console.log('zzz...'),
}

//Call method
let methodName = 'makeSound';
cat.makeSound();
cat['makeSound']();
cat[methodName]();

//Add method dynamically
cat.eat = function () {
    console.log('Tasty...');
};
cat.eat2 = () => console.log('Tasty...');

cat.eat();
cat.eat2();
cat.sleep();

//Use method notation syntax
const dog = {
    name: 'Sharo',
    breed: 'Doberman',
    makeSound() {
        console.log('Laf...');
    },
}

//Get all property names of an object
const propertyNames = Object.keys(cat);
console.log(propertyNames);

//Get all property values of an object
const propertyValues = Object.values(cat);
console.log(propertyValues);

//Get object key value pairs
console.log(Object.entries(dog));

//Create new object from entries
console.log(Object.fromEntries(Object.entries(dog)));

//Check for method and call
cat.makeSound && cat.makeSound();