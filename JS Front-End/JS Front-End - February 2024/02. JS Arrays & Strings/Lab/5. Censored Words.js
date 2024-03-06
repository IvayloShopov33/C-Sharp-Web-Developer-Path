function censoredWords(text, wordToCensore) {
    let censoredText = text.replace(new RegExp(wordToCensore, 'g'), '*'.repeat(wordToCensore.length));
    console.log(censoredText);
}

function censoredWordsSecondSolution(text, wordToCensore) {
    let indexOfWord = text.indexOf(wordToCensore);
    while (indexOfWord >= 0) {
        text = text.replace(wordToCensore, '*'.repeat(wordToCensore.length));
        indexOfWord = text.indexOf(wordToCensore);
    }

    console.log(text);
}