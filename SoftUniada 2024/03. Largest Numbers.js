function solve(input) {
    let numbers = input.shift().split(' ');
    let largestNumbersToPrintCount = Number(input.shift());
    let outputArray = [];

    for (let i = 0; i < numbers.length; i++) {
        numbers[i] = Number(numbers[i]);
    }

    while (largestNumbersToPrintCount > 0) {
        const currentLargestNumber = Math.max(...numbers);
        numbers = numbers.filter((number) => number !== currentLargestNumber);
        outputArray.push(currentLargestNumber);
        largestNumbersToPrintCount--;
    }

    outputArray = outputArray.sort((a, b) => a - b);
    for (const number of outputArray) {
        console.log(number);
    }
}

solve(['23 67 34 12 39 27', '2']);
solve(['63 97 32 31 5', '3']);
solve(['2 3 5 18 7 11 13', '5']);