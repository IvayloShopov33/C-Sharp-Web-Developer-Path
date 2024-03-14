function solve(number) {
    if (number <= 0) {
        console.log("It's not so perfect.");
        return;
    }

    function getSumOfTheProperPositiveDivisors(number) {
        let sumOfProperPositiveDivisors = 0;
        for (let i = 1; i < number; i++) {
            if (isDivisor(number, i)) {
                sumOfProperPositiveDivisors += i;
            }
        }

        return sumOfProperPositiveDivisors;
    }

    const isDivisor = (a, b) => a % b === 0;

    if (getSumOfTheProperPositiveDivisors(number) === number) {
        console.log('We have a perfect number!');
    } else {
        console.log("It's not so perfect.");
    }
}

solve(6);
solve(28);
solve(1236498);
solve(-6);