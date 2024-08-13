function solve(input) {
    const smallerNumber = Number(input.shift());
    const biggestNumber = Number(input.shift());

    for (let i = smallerNumber; i <= biggestNumber; i++) {
        const number = i.toString();
        let isNumberSpecial = true;

        for (let j = 1; j < number.length; j++) {
            const firstDigit = Number(number[j - 1]);
            const secondDigit = Number(number[j]);
            const diff = Math.abs(secondDigit - firstDigit);

            if (diff !== 1) {
                isNumberSpecial = false;
                break;
            }
        }

        if (isNumberSpecial) {
            console.log(i);
        }
    }
}

solve(['10', '21']);
solve(['10', '15']);
solve(['40', '50']);
solve(['100', '30000000']);