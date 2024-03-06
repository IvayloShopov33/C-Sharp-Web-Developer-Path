function sameNumbers(number) {
    const numberAsString = number.toString();
    let isAllNumbersSame = true;
    let sum = Number(numberAsString[0]);
    for (let i = 1; i < numberAsString.length; i++) {
        if (numberAsString[i - 1] !== numberAsString[i]) {
            isAllNumbersSame = false;
        }

        sum += Number(numberAsString[i]);
    }

    console.log(isAllNumbersSame);
    console.log(sum);
}