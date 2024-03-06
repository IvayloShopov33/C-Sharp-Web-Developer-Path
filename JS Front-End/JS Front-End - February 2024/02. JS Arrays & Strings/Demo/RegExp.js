let text = 'I am JavaScript developer, JavaScript is awesome';

//RegExp literal
let pattern = /(Java)Script/ig;

//RegExp function constructor
let pattern2 = new RegExp('JavaScript', 'ig');

//test pattern
console.log(pattern.test(text));

//match by pattern
console.log(pattern2.exec(text));
console.log(pattern2.exec(text));
console.log(pattern2.exec(text));

//String RegExp Methods
console.log(text.match(pattern));
const matches = text.matchAll(pattern);
for (const match of matches) {
    console.log(match);
}

//How to count matches
console.log(Array.from(matches).length);

//Replace with RegExp
console.log(text.replace(/JavaScript/g, 'C#'));
console.log(text.replace(new RegExp('JavaScript', 'g'), 'C#'));