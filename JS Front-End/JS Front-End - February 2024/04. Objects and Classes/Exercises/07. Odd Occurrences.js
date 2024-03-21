function setSolve(words) {
    let wordsWithTheirOccurrences = {};
    for (const word of words.toLowerCase().split(' ')) {
        if (wordsWithTheirOccurrences[word]) {
            wordsWithTheirOccurrences[word]++;
        } else {
            wordsWithTheirOccurrences[word] = 1;
        }
    }

    const wordsWithOddOccurrences = Object.entries(wordsWithTheirOccurrences).filter(word => word[1] % 2 === 1);
    wordsWithTheirOccurrences = Object.fromEntries(wordsWithOddOccurrences);
    console.log(Object.keys(wordsWithTheirOccurrences).join(' '));
}

function solveFancy(words) {
    const wordsWithTheirOccurrences = words
        .toLowerCase()
        .split(' ')
        .reduce((acc, word) =>
            acc.hasOwnProperty(word)
                ? { ...acc, [word]: acc[word] += 1 }
                : { ...acc, [word]: 1 }
            , {});

    const result = Object
        .entries(wordsWithTheirOccurrences)
        .filter(([word, occurrences]) => occurrences % 2 === 1)
        .map(([word, occurrences]) => word)
        .join(' ');

    console.log(result);
}

function mapSolve(words) {
    let wordsMap = new Map();
    for (const word of words.toLowerCase().split(' ')) {
        if (!wordsMap.has(word)) {
            wordsMap.set(word, 0);
        }

        wordsMap.set(word, wordsMap.get(word) + 1);
    }

    const result = [];
    for (const [word, occurrences] of wordsMap) {
        if (occurrences % 2 === 1) {
            result.push(word);
        }
    }

    console.log(result.join(' '));
}

setSolve("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
setSolve('Cake IS SWEET is Soft CAKE sweet Food');

solveFancy("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
solveFancy('Cake IS SWEET is Soft CAKE sweet Food');

mapSolve("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
mapSolve('Cake IS SWEET is Soft CAKE sweet Food');