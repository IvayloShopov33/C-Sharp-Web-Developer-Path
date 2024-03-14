function palindromeIntegers(numbers) {
    const isIntegerPalindrome = (number, reversedNumber) => console.log(number === reversedNumber);
    let currentNumAsString = '';
    let currentNumReversedAsString = '';

    for (let i = 0; i < numbers.length; i++) {
        currentNumAsString = numbers[i].toString();
        currentNumReversedAsString = currentNumAsString.split('').reverse().join('');

        isIntegerPalindrome(currentNumAsString, currentNumReversedAsString);
    }
}

function palindromeIntegersFancy(numbers) {
    numbers.forEach(printPalindromeResult);
}

function printPalindromeResult(number) {
    console.log(isPalindrome(number));
}

function isPalindrome(number) {
    const forwardNumber = number.toString();
    const backwardNumber = forwardNumber.split('').reverse().join('');

    return forwardNumber === backwardNumber;
}