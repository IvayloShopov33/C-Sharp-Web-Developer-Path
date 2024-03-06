function evenAndOddSumsSubstraction(numbers) {
    let evenSum = 0;
    let oddSum = 0;
    for (const number of numbers) {
        if (number % 2 === 0) {
            evenSum += number;
            continue;
        }

        oddSum += number;
    }

    console.log(evenSum - oddSum);
}

function evenAndOddSumsSubstractionWithFilterAndReduceArrayMethod(numbers) {
    let evenNumbers = numbers.filter(num => num % 2 === 0);
    let oddNumbers = numbers.filter(num => num % 2 !== 0);
    let evenSum = evenNumbers.reduce((a, b) => a + b, 0);
    let oddSum = oddNumbers.reduce((a, b) => a + b, 0);

    console.log(evenSum - oddSum);
}

function evenAndOddSumsSubstractionWithReduceArrayMethod(numbers) {
    let result = numbers.reduce((sum, num) => num % 2 === 0 ? sum + num : sum - num, 0);
    console.log(result);
}