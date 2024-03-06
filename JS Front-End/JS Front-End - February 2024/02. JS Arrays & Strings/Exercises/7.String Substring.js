function stringSubstring(word, text) {
    const pattern = new RegExp(word, 'i');
    const words = text.split(' ');
    for (const vocable of words) {
        if (vocable.match(pattern) && vocable.length === word.length) {
            console.log(word);
            return;
        }
    }

    console.log(`${word} not found!`);
}