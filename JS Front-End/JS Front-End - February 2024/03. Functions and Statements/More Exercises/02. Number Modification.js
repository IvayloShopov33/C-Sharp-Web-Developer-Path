function solve(number) {
    function sumOfItsDigits(number) {
        let averageSum = 0;
        for (let i = 0; i < number.length; i++) {
            averageSum += Number(number[i]);
        }

        return averageSum / number.length;
    }

    let numberAsArray = number.toString().split('');
    while (sumOfItsDigits(numberAsArray) <= 5) {
        numberAsArray.push('9');
    }

    console.log(numberAsArray.join(''));
}