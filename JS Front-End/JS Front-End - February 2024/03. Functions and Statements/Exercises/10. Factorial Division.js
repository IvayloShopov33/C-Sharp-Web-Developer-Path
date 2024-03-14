function solve(firstNumber, secondNumber) {
    function factorial(factorialProduct, countOfNums, number) {
        if (countOfNums === number) {
            factorialResult = factorialProduct * number;
            return;
        }

        factorialProduct *= countOfNums;
        countOfNums++;
        factorial(factorialProduct, countOfNums, number);
    }

    let factorialResult = 0;
    let factorialProduct = 1;
    let countOfNums = 1;
    factorial(factorialProduct, countOfNums, firstNumber);
    const firstFactorialResult = factorialResult;

    factorialResult = 0;
    factorialProduct = 1;
    countOfNums = 1;
    factorial(factorialProduct, countOfNums, secondNumber);
    const secondFactorialResult = factorialResult;

    const division = firstFactorialResult / secondFactorialResult;
    console.log(division.toFixed(2));
}

function solveFancy(firstNumber, secondNumber) {
    function factorial(number) {
        if (number <= 1) {
            return 1;
        }

        return number * factorial(number - 1);
    }

    const division = factorial(firstNumber) / factorial(secondNumber);

    console.log(division.toFixed(2));
}

solve(5, 2);
solve(6, 2);

solveFancy(5, 2);
solveFancy(6, 2)