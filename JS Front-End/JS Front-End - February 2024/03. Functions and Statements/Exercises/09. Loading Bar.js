function solve(number) {
    if (number === 100) {
        console.log(`${number}% Complete!`);
        console.log(`[${'%'.repeat(number / 10)}]`);
        return;
    }

    console.log(`${number}% [${'%'.repeat(number / 10)}${'.'.repeat(10 - (number / 10))}]`);
    console.log('Still loading...');
}

solve(30);
solve(100);
solve(50);