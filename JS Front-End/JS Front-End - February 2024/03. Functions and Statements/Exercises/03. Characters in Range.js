function solve(firstChar, secondChar) {
    let arrayOfChars = [];
    const minCharValue = Math.min(firstChar.charCodeAt(0), secondChar.charCodeAt(0));
    const maxCharValue = Math.max(firstChar.charCodeAt(0), secondChar.charCodeAt(0));

    for (let i = minCharValue + 1; i < maxCharValue; i++) {
        arrayOfChars.push(String.fromCharCode(i));
    }

    console.log(arrayOfChars.join(' '));
}

function solveFancy(...charsBorders) {
    function getCharactersBetween(charsBorders, arrayOfChars) {
        for (let i = charsBorders[0].charCodeAt(0) + 1; i < charsBorders[charsBorders.length - 1].charCodeAt(0); i++) {
            arrayOfChars.push(String.fromCharCode(i));
        }

        return arrayOfChars;
    }

    charsBorders.sort();
    let arrayOfChars = [];

    const arrayOfCharsBetween = getCharactersBetween(charsBorders, arrayOfChars);

    console.log(arrayOfCharsBetween.join(' '));
}