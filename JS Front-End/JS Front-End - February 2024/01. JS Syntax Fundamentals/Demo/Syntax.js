//Declare variables
let a = 10;
let b = 20;
console.log(a + b);

var c = 30; //before ES2015 (legacy)- not recommended to use
console.log(c + a);

const pi = 3.14159265359; //Constant variable

//Conditional Statements
if (b > a) {
    console.log('b is bigger than a');
} else if (b == a) {
    console.log('b is equal to a');
} else {
    console.log('b is lower than a');
}

//Function declaration
function add(a, b) {
    console.log(a + b);
}

//Function invocation
add(7, pi);

//Console print with string concatenation
console.log('The Number PI is: ' + pi + '!');

//String interpolation/tempalte literal
console.log(`The Number PI is: ${pi}!`);

//Fix the number output
console.log(pi.toFixed(2));

//Switch statement
switch (c) {
    case 10:
        console.log(`${c} is 10`);
        break;
    case 30:
        console.log(`${c} is 30`);
        break;
    default:
        console.log(`${c} is something different.`);
        break;
}

//Truthy and falsy values
if (a) {
    console.log(a);
}

if (!0) {
    console.log('falsy value');
}

//for loop
for (let i = 0; i < 10; i++) {
    console.log(i);
}

//while loop
let i = 0;
while (i < 10) {
    console.log(i);
    i++;
}

//Undefined
let futureValue;
console.log(typeof futureValue);