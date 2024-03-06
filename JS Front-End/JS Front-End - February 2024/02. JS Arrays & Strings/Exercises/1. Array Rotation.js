function arrayRotation(numbers, rotationsCount) {
    for (let i = 0; i < rotationsCount; i++) {
        let number = numbers.shift();
        numbers.push(number);
    }

    console.log(numbers.join(' '));
}