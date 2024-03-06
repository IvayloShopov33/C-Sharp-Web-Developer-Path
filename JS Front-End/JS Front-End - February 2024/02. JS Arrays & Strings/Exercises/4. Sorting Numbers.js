function sortingNumbers(numbers) {
    numbers.sort((a, b) => a - b);
    let sortedNumbers = [];
    let indexBiggerNums = 0;
    for (let i = 0; i < numbers.length; i++) {
        if (i % 2 === 0) {
            sortedNumbers.push(numbers[i / 2]);
            continue;
        }

        sortedNumbers.push(numbers[numbers.length - 1 - indexBiggerNums++]);
    }

    return sortedNumbers;
}