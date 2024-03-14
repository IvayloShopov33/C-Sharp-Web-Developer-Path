function oddAndEvenSum(number) {
    const sum = (a, b) => a + b;
    let evenSum = 0;
    let oddSum = 0;

    while (number !== 0) {
        let digit = number % 10;
        number = Math.trunc(number / 10);

        if (digit % 2 === 0) {
            evenSum = sum(evenSum, digit);
        } else {
            oddSum = sum(oddSum, digit);
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

function oddAndEvenSumFancy(number) {
    function calculateFilteredDigitsSum(number, filter) {
        const filteredDigits = number
            .toString()
            .split('')
            .map(Number)
            .filter(filter);

        const sum = filteredDigits.reduce((acc, digit) => acc + digit, 0);

        return sum;
    }

    const isEven = x => x % 2 === 0;
    const isOdd = x => x % 2 === 1;

    const evenSum = calculateFilteredDigitsSum(number, isEven);
    const oddSum = calculateFilteredDigitsSum(number, isOdd);

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}