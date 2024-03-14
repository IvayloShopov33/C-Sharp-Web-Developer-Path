const isLengthCorrect = password => password.length >= 6 && password.length <= 10;
const isAlphaNumerical = password => /^[A-Za-z0-9]+$/.test(password);
const isThereAtLeastTwoDigits = function (password) {
    return password.split('').filter(character => Number.isInteger(Number(character)) === true).length >= 2;
}

function solve(password) {
    if (isLengthCorrect(password) && isAlphaNumerical(password) && isThereAtLeastTwoDigits(password)) {
        console.log('Password is valid');
        return;
    }

    if (!isLengthCorrect(password)) {
        console.log('Password must be between 6 and 10 characters');
    }

    if (!isAlphaNumerical(password)) {
        console.log('Password must consist only of letters and digits');
    }

    if (!isThereAtLeastTwoDigits(password)) {
        console.log('Password must have at least 2 digits');
    }
}

function solveFancy(password) {
    const validations = [
        [isLengthCorrect, 'Password must be between 6 and 10 characters'],
        [isAlphaNumerical, 'Password must consist only of letters and digits'],
        [isThereAtLeastTwoDigits, 'Password must have at least 2 digits']
    ]

    const errors = validations
        .map(([validator, message]) => validator(password) ? '' : message)
        .filter(message => !!message)

    errors.forEach(message => console.log(message));

    if (errors.length === 0) {
        console.log('Password is valid');
    }
}

solve('logIn');
solve('MyPass123');
solve('Pa$s$s');

solveFancy('logIn');
solveFancy('MyPass123');
solveFancy('Pa$s$s');