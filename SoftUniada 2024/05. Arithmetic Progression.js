function solve(input) {
    let numbers = input.shift().split(' ');
    numbers = numbers.map((number) => Number(number));
    let arithmeticProgressionsCount = 1 + numbers.length;
    for (let i = 0; i < numbers.length; i++) {
        for (let j = i + 1; j < numbers.length; j++) {
            arithmeticProgressionsCount++;
        }
    }

    for (let i = 0; i < numbers.length; i++) {
        for (let j = i + 1; j < numbers.length; j++) {
            const difference = numbers[j] - numbers[i];
            let previousNumber = numbers[j];
            let subsequenceLength = 2;

            for (let k = j + 1; k < numbers.length; k++) {
                if (numbers[k] - difference === previousNumber) {
                    previousNumber = numbers[k];
                    subsequenceLength++;

                    if (subsequenceLength >= 3) {
                        arithmeticProgressionsCount++;
                    }
                }
            }
        }
    }

    console.log(arithmeticProgressionsCount);
}

solve(['1 2 3']);
solve(['10 20 30 45']);
solve(['1 2 3 4 5']);