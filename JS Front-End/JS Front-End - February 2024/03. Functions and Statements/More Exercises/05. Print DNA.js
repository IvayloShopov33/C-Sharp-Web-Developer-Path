function solve(lengthOfDNA) {
    const dna = 'ATCGTTAGGG';
    let dnaIterator = 0;

    for (let i = 0; i < lengthOfDNA; i++) {
        if (i % 4 === 0) {
            console.log(`**${dna[dnaIterator]}${dna[++dnaIterator]}**`);
        } else if (i % 4 === 1 || i % 4 === 3) {
            console.log(`*${dna[dnaIterator]}--${dna[++dnaIterator]}*`);
        } else {
            console.log(`${dna[dnaIterator]}----${dna[++dnaIterator]}`);
        }

        dnaIterator++;
        if (dnaIterator === dna.length) {
            dnaIterator = 0;
        }
    }
}