function solve(firstNumber, secondNumber, thirdNumber) {
    const productOfFirstTwoNums = firstNumber * secondNumber;
    if ((productOfFirstTwoNums > 0 && thirdNumber > 0) || (productOfFirstTwoNums < 0 && thirdNumber < 0)) {
        console.log('Positive');
    } else {
        console.log('Negative');
    }
}

function fancySolve(firstNumber, secondNumber, thirdNumber) {
    const multiply = (a, b) => a * b;
    if (multiply(multiply(firstNumber, secondNumber), thirdNumber) > 0) {
        console.log('Positive');
    } else {
        console.log('Negative');
    }
}