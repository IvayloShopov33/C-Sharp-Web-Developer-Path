function solve(input) {
    input = Number(input.shift());
    const width = 5 * input;
    let addedRows = input / 2;
    let moreDots = 0;
    for (let index = 0; index < addedRows; index++) {
        let row = '.'.repeat(input + moreDots);
        row += '#'.repeat(width - 2 * (input + moreDots));
        row += '.'.repeat(input + moreDots);
        console.log(row);
        moreDots++;
    }

    for (let index = 0; index < 1 + addedRows; index++) {
        let row = '.'.repeat(input + moreDots);
        row += '#';
        const reversedRow = row.split('').reverse().join('');
        row += '.'.repeat(width - 2 * (row.length));
        row += reversedRow;
        console.log(row);
        moreDots++;
    }

    let row = '.'.repeat(input + moreDots - 1);
    row += '#'.repeat(width - 2 * (input + moreDots - 1));
    row += '.'.repeat(input + moreDots - 1);
    console.log(row);
    moreDots -= 3;

    for (let index = 0; index < addedRows; index++) {
        let row = '.'.repeat(input + moreDots);
        row += '#'.repeat(width - 2 * (input + moreDots));
        row += '.'.repeat(input + moreDots);
        console.log(row);
    }

    const specificText = 'D^A^N^C^E^';
    const distanceToText = (width - 10) / 2;
    row = '.'.repeat(distanceToText);
    row += specificText;
    row += '.'.repeat(distanceToText);
    console.log(row);

    for (let index = 0; index < addedRows + 1; index++) {
        let row = '.'.repeat(input + moreDots);
        row += '#'.repeat(width - 2 * (input + moreDots));
        row += '.'.repeat(input + moreDots);
        console.log(row);
    }
}

solve(['6']);
solve(['8']);