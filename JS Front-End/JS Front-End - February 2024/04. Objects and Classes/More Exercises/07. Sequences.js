function solve(numbersArrays) {
    let uniqueArraysOfNumbers = [];
    for (const numbers of numbersArrays) {
        let numbersArray = JSON.parse(numbers);
        numbersArray = numbersArray.sort((a, b) => b - a);

        if (!uniqueArraysOfNumbers.some(numbers => JSON.stringify(numbers) === JSON.stringify(numbersArray))) {
            uniqueArraysOfNumbers.push(numbersArray);
        }
    }

    uniqueArraysOfNumbers = uniqueArraysOfNumbers.sort((a, b) => a.length - b.length);
    for (const numbers of uniqueArraysOfNumbers) {
        console.log(`[${numbers.join(', ')}]`);
    }
}

solve(["[1, 2, 2]", "[1, 1, 2]"]);

solve(["[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"]);

solve(["[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"]);