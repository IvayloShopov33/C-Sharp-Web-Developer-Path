//IndexOf
let text = 'I am JavaScript developer';
console.log(text.indexOf('Java'));

//Substring
console.log(text.substring(text.indexOf('J'), 15));

//Replace
console.log(text.replace('JavaScript', 'C#'));

//Split
let words = text.split(' ');
console.log(words);

//Includes
console.log(text.includes('Java'));

//Repeat
console.log('Opi ' + 'Settings '.repeat(6));

//Trim
let message = '       I am okay!        ';
console.log(message.trim());

//Check if string starts or ends with other string
console.log(text.startsWith('I am'));
console.log(text.endsWith('developer'));

//Pad string
console.log('10'.padStart(10, '3'));
console.log('11'.padEnd(10, '3'));

//Reverse string
let reversedString = text
    .split('')
    .reverse()
    .join('');

console.log(reversedString);