function reverseAnArray(reversedNumbersCount, numbers) {
    numbers.length = reversedNumbersCount;
    numbers.reverse();
    console.log(numbers.join(' '));
}