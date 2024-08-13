function solve(numbers) {
    numbers = numbers.shift().split(' ');
    let peakElement = Number.MIN_SAFE_INTEGER;
    for (let i = 1; i < numbers.length - 1; i++) {
        numbers[i] = Number(numbers[i]);
        numbers[i - 1] = Number(numbers[i - 1]);
        numbers[i + 1] = Number(numbers[i + 1]);

        if ((numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1]) && numbers[i] > peakElement) {
            peakElement = numbers[i];
        }
    }

    console.log(peakElement);
}

solve(['1 4 2 4 5 6 1']);
solve(['13 17 12 3 5']);
solve(['2 3 5 18 7 11 13']);