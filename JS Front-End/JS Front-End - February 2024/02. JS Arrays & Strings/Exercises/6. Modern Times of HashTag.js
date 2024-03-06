function solve(text) {
    let words = text.split(' ');
    for (const word of words) {
        if (word.startsWith('#') && word.length > 1) {
            let wordWithoutDS = word.substring(1);
            if (/^[a-zA-Z]+$/.test(wordWithoutDS)) {
                console.log(wordWithoutDS);
            }
        }
    }
}

function solveSecondWay(text) {
    const pattern = /#(?<word>[a-zA-Z]+)/g;
    const matches = text.matchAll(pattern);

    for (const match of matches) {
        console.log(match.groups.word);
    }
}