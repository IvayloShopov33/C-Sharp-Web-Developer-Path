//Decalre an array
let numbers = [1, 2, 3, 4, 5];
let names = ['Ivaylo', 'Ivan', 'John', 'Mark', 'Harry'];

//Decalre an empty array
let empty = []; //truthy value

//Change array by reference
numbers[0] = 10;

//Dynamically add elements to an array
empty[0] = 2;

//Accessing by index
let firstName = names[0];
let lastName = names[names.length - 1];

//Accessing by invalid index
console.log(names[5]);
console.log(names[-3]);

//Array destructuring assignment
let [firstNum, secondNum, thirdNum, ...restNums] = [11, 12, 13, 14, 15, 16];
console.log(thirdNum);
console.log(restNums);

//For-of loop
for (let number of numbers) {
    console.log(number);
}

//Array hack 1
names[10] = "Fin";
console.log(names.length);
console.log(names);

//Array hack 2
let arr = [1, 2, 3];
arr.length = 10;
console.log(arr.length);
console.log(arr);

arr.length = 2;
console.log(arr.length);
console.log(arr);

//Basic Array Methods
let cities = ['Madrid', 'Paris', 'Lisbon', 'Berlin', 'Dortmund', 'Sofia', 'Plovdiv'];

//Mutating methods
//Get last item - pop
console.log(cities.length);
console.log(cities.pop());
console.log(cities.length);

//Add last item
let newLength = cities.push('Varna', 'Sopot', 'Karlovo');
console.log(newLength);

//Remove first item
console.log(cities.shift());

//Add first item
console.log(cities.unshift('Madrid'));

//Remove item with Splice
console.log(cities.splice(2, 3));
console.log(cities);

//Add item to the array with splice
cities.splice(2, 0, 'London');
console.log(cities);

//Add and remove items with splice
cities.splice(2, 3, 'Pernik', 'Burgas');
console.log(cities);

//Reverse array
console.log(cities.reverse());

//Non-mutating methods
//Join array as string
let citiesString = cities.join(', ');
console.log(citiesString);

//Slice
console.log(cities.slice(1, 3));
console.log(cities.slice());
console.log(cities.slice(2));

//Includes - check if element exists in array
console.log(cities.includes('Sofia'));
console.log(cities.includes('Paris'));

//Find index of element
console.log(cities.indexOf('Paris'));
console.log(cities.indexOf('Sofia'));

//Find specific element
console.log(cities.find(city => city[0] === 'P'));
console.log(cities.find(city => city === 'Sozopol'));

//Find all indexes of element
let capitals = ['Bern', 'Rome', 'Bern', 'Cairo'];
let bernIndex = capitals.indexOf('Bern');
while (bernIndex >= 0) {
    console.log(bernIndex);
    bernIndex = capitals.indexOf('Bern', bernIndex + 1);
}

//ForEach
cities.forEach(city => console.log(city));

//Map
let nums = [1, 2, 3, 4, 5];
let doubleNums = nums.map(num => num * 2);
console.log(doubleNums);

//Filter
let evenNums = nums.filter(num => num % 2 === 0);
console.log(evenNums);

//Reduce - Sum all numbers in array
console.log(nums.reduce((sum, number) => sum + number, 0));