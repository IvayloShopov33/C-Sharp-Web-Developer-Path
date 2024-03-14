function addAndSubtractNumbers(firstNumber, secondNumber, thirdNumber) {
    const sumOfTheFirstTwoNumbers = function (firstNumber, secondNumber) {
        return firstNumber + secondNumber;
    }

    const subtractTheThirdNumberFromTheSum = (sum, thirdNumber) => console.log(sum - thirdNumber);
    subtractTheThirdNumberFromTheSum(sumOfTheFirstTwoNumbers(firstNumber, secondNumber), thirdNumber);
}