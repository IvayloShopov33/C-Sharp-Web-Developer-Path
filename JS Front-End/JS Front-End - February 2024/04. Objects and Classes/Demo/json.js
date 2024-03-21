let person = {
    name: 'Ivo',
    age: 19,
};

//Convert JS Object to JSON
const data = JSON.stringify(person, null, 2);
console.log(data);

//Convert from JSON to JS Object
const originalObject = JSON.parse(data);
console.log(originalObject);
console.log(originalObject.name);