function revealWords(revealingWords, text) {
    let words = text.split(' ');
    revealingWords = revealingWords.split(', ');
    for (const word of words) {
        if (word.startsWith('*')) {
            let wordWithSameLength = revealingWords.find(w => w.length === word.length);
            text = text.replace(word, wordWithSameLength);
        }
    }

    console.log(text);
}