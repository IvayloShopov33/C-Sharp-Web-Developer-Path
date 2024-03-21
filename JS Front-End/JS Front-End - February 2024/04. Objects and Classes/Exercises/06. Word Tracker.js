function setSolve(input) {
    const wordsAndTheirOccurrences = {};
    const wordsToLookFor = input.shift().split(' ');
    for (const word of wordsToLookFor) {
        wordsAndTheirOccurrences[word] = 0;
    }

    for (const word of input) {
        if (wordsAndTheirOccurrences.hasOwnProperty(word)) {
            wordsAndTheirOccurrences[word]++;
        }
    }

    Object
        .entries(wordsAndTheirOccurrences)
        .sort((a, b) => b[1] - a[1])
        .forEach(([word, occurrences]) => console.log(`${word} - ${occurrences}`));
}

setSolve(['this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task']);