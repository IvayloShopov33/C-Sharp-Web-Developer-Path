function getTheSmallestNum(...numbers) {
    let minNumber = Number.MAX_SAFE_INTEGER;
    for (const number of numbers) {
        if (minNumber > number) {
            minNumber = number;
        }
    }

    console.log(minNumber);
}

function getTheSmallestNumUsingSort(...numbers) {
    numbers.sort((a, b) => a - b);
    console.log(numbers.shift());
}

function getTheSmallestNumUsingMin(a, b, c) {
    console.log(Math.min(a, b, c));
}

function getTheSmallestNumUsingMinAndSpreadOperator(...numbers) {
    console.log(Math.min(...numbers));
}