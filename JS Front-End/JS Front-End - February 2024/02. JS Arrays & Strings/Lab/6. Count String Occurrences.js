function stringOccurrencesCount(text, stringToSearchFor) {
    let occurrencesCount = 0;
    text = text.split(' ');
    for (const word of text) {
        if (word === stringToSearchFor) {
            occurrencesCount++;
        }
    }

    console.log(occurrencesCount);
}

function stringOccurrencesCountWithFilterArrayMethod(text, stringToSearchFor) {
    let result = text
        .split(' ')
        .filter(word => word === stringToSearchFor)
        .length;

    console.log(result);
}