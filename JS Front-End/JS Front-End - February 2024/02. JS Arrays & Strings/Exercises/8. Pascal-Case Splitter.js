function pascalCaseSplitter(text) {
    let previousUpperCaseLetter = 0;
    let words = [];
    let index = 0;

    for (let i = 1; i < text.length; i++) {
        if (text[i] === text[i].toUpperCase()) {
            words[index++] = text.substring(previousUpperCaseLetter, i);
            previousUpperCaseLetter = i;
        }
    }

    words[index] = text.substring(previousUpperCaseLetter, text.length);
    console.log(words.join(', '));
}

function pascalCaseSplitterSecondWay(text) {
    const matches = text.matchAll(/[A-Z][a-z]*/g);
    const words = Array.from(matches).map(match => match[0]);
    console.log(words.join(', '));
}

function pascalCaseSplitterSolvedWithLookAhead(text) {
    console.log(text.split(/(?=[A-Z])/).join(', '));
}