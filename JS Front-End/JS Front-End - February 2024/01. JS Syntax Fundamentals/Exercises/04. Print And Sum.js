function printAndSumNumbers(bottomBorder, topBorder) {
    let stringOutput = '';
    let sum = 0;
    for (let i = bottomBorder; i <= topBorder; i++) {
        stringOutput += i + ' ';
        sum += i;
    }

    console.log(stringOutput);
    console.log(`Sum: ${sum}`);
}