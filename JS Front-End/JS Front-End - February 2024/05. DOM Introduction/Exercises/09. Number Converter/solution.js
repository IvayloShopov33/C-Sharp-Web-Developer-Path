function solve() {
    const selectedMenuConvertFrom = document.getElementById('selectMenuFrom');
    const selectedMenuConvertTo = document.getElementById('selectMenuTo');

    createOptionToConvertFromBinary(selectedMenuConvertFrom);
    createOptionToConvertFromOctal(selectedMenuConvertFrom);
    createOptionToConvertFromHexadecimal(selectedMenuConvertFrom);

    addOptionToConvertToHexadecimal();
    createOptionToConvertToBinary(selectedMenuConvertTo);
    createOptionToConvertToOctal(selectedMenuConvertTo);
    createOptionToConvertToDecimal(selectedMenuConvertTo);

    document.querySelector('button').addEventListener('click', onClick);

    function onClick() {
        let inputNumber = document.getElementById('input').value;
        let convertedNumber = '';

        if (selectedMenuConvertFrom.value === 'decimal' && selectedMenuConvertTo.value === 'binary') {
            convertedNumber = convertDecimalToBinary(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'decimal' && selectedMenuConvertTo.value === 'octal') {
            convertedNumber = convertDecimalToOctal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'decimal' && selectedMenuConvertTo.value === 'hexadecimal') {
            convertedNumber = convertDecimalToHexadecimal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'binary' && selectedMenuConvertTo.value === 'octal') {
            convertedNumber = convertBinaryToOctal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'binary' && selectedMenuConvertTo.value === 'decimal') {
            convertedNumber = convertBinaryToDecimal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'binary' && selectedMenuConvertTo.value === 'hexadecimal') {
            convertedNumber = convertBinaryToHexadecimal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'octal' && selectedMenuConvertTo.value === 'binary') {
            convertedNumber = convertOctalToBinary(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'octal' && selectedMenuConvertTo.value === 'decimal') {
            convertedNumber = convertOctalToDecimal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'octal' && selectedMenuConvertTo.value === 'hexadecimal') {
            convertedNumber = convertOctalToHexadecimal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'hexadecimal' && selectedMenuConvertTo.value === 'binary') {
            convertedNumber = convertHexadecimalToBinary(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'hexadecimal' && selectedMenuConvertTo.value === 'octal') {
            convertedNumber = convertHexadecimalToOctal(inputNumber);
        } else if (selectedMenuConvertFrom.value === 'hexadecimal' && selectedMenuConvertTo.value === 'decimal') {
            convertedNumber = convertHexadecimalToDecimal(inputNumber);
        } else if ((selectedMenuConvertFrom.value === 'binary' && selectedMenuConvertTo.value === 'binary' && !checkIfTheBinaryNumberIsInvalid(inputNumber)) ||
            (selectedMenuConvertFrom.value === 'octal' && selectedMenuConvertTo.value === 'octal' && !checkIfTheOctalNumberIsInvalid(inputNumber)) ||
            (selectedMenuConvertFrom.value === 'decimal' && selectedMenuConvertTo.value === 'decimal' && !checkIfTheDecimalNumberIsInvalid(inputNumber)) ||
            (selectedMenuConvertFrom.value === 'hexadecimal' && selectedMenuConvertTo.value === 'hexadecimal' && !checkIfTheHexadecimalNumberIsInvalid(inputNumber.toUpperCase()))) {
            convertedNumber = inputNumber.toUpperCase();
        }
        else {
            convertedNumber = 'The input data is incorrect!';
        }

        const outputField = document.getElementById('result');
        outputField.value = convertedNumber;
    }
}

function createOptionToConvertFromBinary(selectedMenuConvertFrom) {
    const convertFromBinaryOption = document.createElement('option');
    convertFromBinaryOption.value = 'binary';
    convertFromBinaryOption.textContent = 'Binary';

    selectedMenuConvertFrom.appendChild(convertFromBinaryOption);
}

function createOptionToConvertFromOctal(selectedMenuConvertFrom) {
    const convertFromOctalOption = document.createElement('option');
    convertFromOctalOption.value = 'octal';
    convertFromOctalOption.textContent = 'Octal';

    selectedMenuConvertFrom.appendChild(convertFromOctalOption);
}

function createOptionToConvertFromHexadecimal(selectedMenuConvertFrom) {
    const convertFromHexadecimalOption = document.createElement('option');
    convertFromHexadecimalOption.value = 'hexadecimal';
    convertFromHexadecimalOption.textContent = 'Hexadecimal';

    selectedMenuConvertFrom.appendChild(convertFromHexadecimalOption);
}

function addOptionToConvertToHexadecimal() {
    const convertToHexadecimalOption = document.querySelector('#selectMenuTo option');
    convertToHexadecimalOption.value = 'hexadecimal';
    convertToHexadecimalOption.textContent = 'Hexadecimal';
}

function createOptionToConvertToBinary(selectedMenuConvertTo) {
    const convertToBinaryOption = document.createElement('option');
    convertToBinaryOption.value = 'binary';
    convertToBinaryOption.textContent = 'Binary';

    selectedMenuConvertTo.appendChild(convertToBinaryOption);
}

function createOptionToConvertToOctal(selectedMenuConvertTo) {
    const convertToOctalOption = document.createElement('option');
    convertToOctalOption.value = 'octal';
    convertToOctalOption.textContent = 'Octal';

    selectedMenuConvertTo.appendChild(convertToOctalOption);
}

function createOptionToConvertToDecimal(selectedMenuConvertTo) {
    const convertToDecimalOption = document.createElement('option');
    convertToDecimalOption.value = 'decimal';
    convertToDecimalOption.textContent = 'Decimal';

    selectedMenuConvertTo.appendChild(convertToDecimalOption);
}

function checkIfTheBinaryNumberIsInvalid(binaryNumber) {
    const binaryAlphabet = ['0', '1'];

    return [...binaryNumber].some(digit => !binaryAlphabet.includes(digit));
}

function checkIfTheOctalNumberIsInvalid(octalNumber) {
    const octalAlphabet = ['0', '1', '2', '3', '4', '5', '6', '7'];

    return [...octalNumber].some(digit => !octalAlphabet.includes(digit));
}

function checkIfTheDecimalNumberIsInvalid(decimalNumber) {
    const decimalAlphabet = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    return [...decimalNumber].some(digit => !decimalAlphabet.includes(digit));
}

function checkIfTheHexadecimalNumberIsInvalid(hexadecimalNumber) {
    const hexadecimalAlphabet = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'];

    return [...hexadecimalNumber].some(digit => !hexadecimalAlphabet.includes(digit));
}

function convertDecimalToBinaryOrOctal(decimalNumber, base) {
    if (checkIfTheDecimalNumberIsInvalid(decimalNumber) === true) {
        return 'The input data is incorrect!';
    }

    let binaryOrOctalNumber = '';
    decimalNumber = Number(decimalNumber);

    while (decimalNumber !== 0) {
        const digit = decimalNumber % base;
        decimalNumber = Math.trunc(decimalNumber / base);
        binaryOrOctalNumber += digit;
    }

    return binaryOrOctalNumber.split('').reverse().join('');
}

function convertDecimalToBinary(decimalNumber) {
    return convertDecimalToBinaryOrOctal(decimalNumber, 2);
}

function convertDecimalToOctal(decimalNumber) {
    return convertDecimalToBinaryOrOctal(decimalNumber, 8);
}

function convertDecimalToHexadecimal(decimalNumber) {
    if (checkIfTheDecimalNumberIsInvalid(decimalNumber) === true) {
        return 'The input data is incorrect!';
    }

    decimalNumber = Number(decimalNumber);
    let hexadecimalNumber = '';
    const hexadecimalNumeralSystemAlphabetLetters = ['A', 'B', 'C', 'D', 'E', 'F'];

    while (decimalNumber !== 0) {
        let digit = decimalNumber % 16;
        decimalNumber = Math.trunc(decimalNumber / 16);

        if (digit > 9) {
            digit = hexadecimalNumeralSystemAlphabetLetters[digit - 10];
        }

        hexadecimalNumber += digit;
    }

    return hexadecimalNumber.split('').reverse().join('');
}

function convertBinaryOrOctalToDecimal(number, base) {
    let decimalNumber = 0;
    number = number.split('').reverse().join('');

    for (let i = 0; i < number.length; i++) {
        decimalNumber += Number(number[i]) * Math.pow(base, i);
    }

    return decimalNumber;
}

function convertBinaryBitsToOctalOrHexadecimalDigits(binaryNumber, binaryBitsToDigits, bitsRange) {
    let numberToConvert = '';
    binaryNumber = Array.from(binaryNumber);

    while (binaryNumber.length % bitsRange !== 0) {
        binaryNumber.splice(0, 0, '0');
    }

    for (let i = 0; i < binaryNumber.length; i += bitsRange) {
        const binaryBits = binaryNumber.slice(i, i + bitsRange);
        numberToConvert += binaryBitsToDigits[binaryBits.join('')];
    }

    return numberToConvert;
}

function convertBinaryToOctal(binaryNumber) {
    if (checkIfTheBinaryNumberIsInvalid(binaryNumber) === true) {
        return 'The input data is incorrect!';
    }

    const bitsRange = 3;
    const binaryBitsToOctalDigits = {
        '000': '0',
        '001': '1',
        '010': '2',
        '011': '3',
        '100': '4',
        '101': '5',
        '110': '6',
        '111': '7',
    };

    return convertBinaryBitsToOctalOrHexadecimalDigits(binaryNumber, binaryBitsToOctalDigits, bitsRange);
}

function convertBinaryToDecimal(binaryNumber) {
    if (checkIfTheBinaryNumberIsInvalid(binaryNumber) === true) {
        return 'The input data is incorrect!';
    }

    const decimalNumber = convertBinaryOrOctalToDecimal(binaryNumber, 2);

    return decimalNumber;
}

function convertBinaryToHexadecimal(binaryNumber) {
    if (checkIfTheBinaryNumberIsInvalid(binaryNumber) === true) {
        return 'The input data is incorrect!';
    }

    const bitsRange = 4;
    const binaryBitsToHexadecimalDigits = {
        '0000': '0',
        '0001': '1',
        '0010': '2',
        '0011': '3',
        '0100': '4',
        '0101': '5',
        '0110': '6',
        '0111': '7',
        '1000': '8',
        '1001': '9',
        '1010': 'A',
        '1011': 'B',
        '1100': 'C',
        '1101': 'D',
        '1110': 'E',
        '1111': 'F',
    };

    return convertBinaryBitsToOctalOrHexadecimalDigits(binaryNumber, binaryBitsToHexadecimalDigits, bitsRange);
}

function convertOctalOrHexadecimalDigitsToBinaryBits(numberToConvert, digitsToBinaryBits) {
    let binaryNumber = '';
    numberToConvert = Array.from(numberToConvert);

    for (let i = 0; i < numberToConvert.length; i++) {
        const digit = numberToConvert[i];
        binaryNumber += digitsToBinaryBits[digit];
    }

    binaryNumber = [...binaryNumber];
    while (binaryNumber[0] === '0') {
        binaryNumber.shift();
    }

    return binaryNumber.join('');
}

function convertOctalToBinary(octalNumber) {
    if (checkIfTheOctalNumberIsInvalid(octalNumber) === true) {
        return 'The input data is incorrect!';
    }

    const octalDigitsToBinaryBits = {
        '0': '000',
        '1': '001',
        '2': '010',
        '3': '011',
        '4': '100',
        '5': '101',
        '6': '110',
        '7': '111',
    };

    return convertOctalOrHexadecimalDigitsToBinaryBits(octalNumber, octalDigitsToBinaryBits);
}

function convertOctalToDecimal(octalNumber) {
    if (checkIfTheOctalNumberIsInvalid(octalNumber) === true) {
        return 'The input data is incorrect!';
    }

    const decimalNumber = convertBinaryOrOctalToDecimal(octalNumber, 8);

    return decimalNumber;
}

function convertOctalToHexadecimal(octalNumber) {
    if (checkIfTheOctalNumberIsInvalid(octalNumber) === true) {
        return 'The input data is incorrect!';
    }

    const binaryNumber = convertOctalToBinary(octalNumber);
    const hexadecimalNumber = convertBinaryToHexadecimal(binaryNumber);

    return hexadecimalNumber;
}

function convertHexadecimalToBinary(hexadecimalNumber) {
    hexadecimalNumber = hexadecimalNumber.toUpperCase();
    if (checkIfTheHexadecimalNumberIsInvalid(hexadecimalNumber)) {
        return 'The input data is incorrect!';
    }

    const hexadecimalDigitsToBinaryBits = {
        '0': '0000',
        '1': '0001',
        '2': '0010',
        '3': '0011',
        '4': '0100',
        '5': '0101',
        '6': '0110',
        '7': '0111',
        '8': '1000',
        '9': '1001',
        'A': '1010',
        'B': '1011',
        'C': '1100',
        'D': '1101',
        'E': '1110',
        'F': '1111',
    };

    return convertOctalOrHexadecimalDigitsToBinaryBits(hexadecimalNumber, hexadecimalDigitsToBinaryBits);
}

function convertHexadecimalToOctal(hexadecimalNumber) {
    hexadecimalNumber = hexadecimalNumber.toUpperCase();
    if (checkIfTheHexadecimalNumberIsInvalid(hexadecimalNumber)) {
        return 'The input data is incorrect!';
    }

    const binaryNumber = convertHexadecimalToBinary(hexadecimalNumber);
    const octalNumber = convertBinaryToOctal(binaryNumber);

    return octalNumber;
}

function convertHexadecimalToDecimal(hexadecimalNumber) {
    hexadecimalNumber = hexadecimalNumber.toUpperCase();
    if (checkIfTheHexadecimalNumberIsInvalid(hexadecimalNumber)) {
        return 'The input data is incorrect!';
    }

    let decimalNumber = 0;
    hexadecimalNumber = hexadecimalNumber.split('').reverse().join('');
    const hexadecimalNumeralSystemAlphabetLettersToDecimal = [
        ['A', 10],
        ['B', 11],
        ['C', 12],
        ['D', 13],
        ['E', 14],
        ['F', 15],
    ];

    for (let i = 0; i < hexadecimalNumber.length; i++) {
        let digit = hexadecimalNumber[i];
        const letter = hexadecimalNumeralSystemAlphabetLettersToDecimal.find(letter => letter[0] === digit);

        if (letter) {
            digit = letter[1];
        }

        decimalNumber += Number(digit) * Math.pow(16, i);
    }

    return decimalNumber;
}