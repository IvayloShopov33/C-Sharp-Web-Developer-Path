function sumDigitsOfString(number) {
    const numberAsString = number.toString();
    let sumOfDigits = 0;
    for (let i = 0; i < numberAsString.length; i++) {
        sumOfDigits += Number(numberAsString[i]);
    }

    console.log(sumOfDigits);
}

function sumDigitsOfStringMathematically(number) {
    let sum = 0;
    while (number !== 0) {
        sum += (number % 10);
        number = Math.trunc(number / 10);
    }

    console.log(sum);
}