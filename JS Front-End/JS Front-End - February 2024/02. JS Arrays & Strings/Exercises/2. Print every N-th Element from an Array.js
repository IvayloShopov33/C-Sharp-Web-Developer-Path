function printEveryNthElement(strings, step) {
    let outputArray = [];
    for (let i = 0; i < strings.length; i += step) {
        outputArray.push(strings[i]);
    }

    return outputArray;
}