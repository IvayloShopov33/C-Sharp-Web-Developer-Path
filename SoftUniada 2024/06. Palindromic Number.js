function solve(input) {
    let initialNumber = input.shift().split('');
    initialNumber = initialNumber.map(Number);
    const newBiggestPalindromicNumber = [];
    const numbersWithTheirOccurrences = {};

    for (let i = 0; i < initialNumber.length; i++) {
        let count = 0;
        initialNumber.forEach(number => number === initialNumber[i] && count++);

        if (!numbersWithTheirOccurrences[initialNumber[i]]) {
            numbersWithTheirOccurrences[initialNumber[i]] = count;
        }

        if (count % 2 === 1 && initialNumber.length % 2 === 0) {
            console.log('No palindromic number available.');
            return;
        }
    }

    let indexToInsertDigits = 0;
    while (initialNumber.length > 0) {
        const biggestDigit = Math.max(...initialNumber);
        for (let i = 0; i < Math.ceil(numbersWithTheirOccurrences[biggestDigit] / 2); i++) {
            newBiggestPalindromicNumber.splice(indexToInsertDigits, 0, biggestDigit);

            if (numbersWithTheirOccurrences[biggestDigit] % 2 === 1 && i === Math.ceil(numbersWithTheirOccurrences[biggestDigit] / 2) - 1) {
                indexToInsertDigits++;
                continue;
            }

            newBiggestPalindromicNumber.splice(newBiggestPalindromicNumber.length - indexToInsertDigits, 0, biggestDigit);
            indexToInsertDigits++;
        }

        initialNumber = initialNumber.filter(number => number !== biggestDigit);
    }

    let palindromicNumber = newBiggestPalindromicNumber.join('');
    let reversedPalindromicNumber = newBiggestPalindromicNumber.reverse().join('');

    palindromicNumber = Number(palindromicNumber);
    reversedPalindromicNumber = Number(reversedPalindromicNumber);

    if (palindromicNumber === reversedPalindromicNumber) {
        console.log(palindromicNumber);
    } else {
        console.log('No palindromic number available.');
    }
}

solve(['313551']);
solve(['331']);
solve(['3444']);