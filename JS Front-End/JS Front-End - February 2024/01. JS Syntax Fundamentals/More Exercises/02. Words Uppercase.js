function wordsToUpperCase(text) {
    let words = text.split(/\W/g);
    let output = '';
    for (let i = 0; i < words.length; i++) {
        let word = words[i];
        word = word.replace(/\W/g, '');
        word = word.toUpperCase();

        if (word.length >= 1) {
            output += `${word}, `;
        }
    }

    output = output.slice(0, output.length - 2);
    console.log(output);
}