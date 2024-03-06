function pyramidOfKindDjoser(base, increment) {
    let stoneRequired = 0;
    let marbleRequired = 0;
    let lapisLazuliRequired = 0;
    let goldRequired = 0;
    let stepsCount = 0;
    let decorationRequired = 0;
    let finalStepBase = 2;

    if (base % 2 === 1) {
        finalStepBase = 1;
    }

    while (base >= finalStepBase) {
        if (base === 2 || base === 1) {
            goldRequired += Math.pow(base, 2) * increment;
            stepsCount++;
            break;
        }

        stoneRequired += Math.pow(base - 2, 2) * increment;
        decorationRequired = (2 * (base * 2) - 4) * increment;
        stepsCount++;

        if (stepsCount % 5 === 0 && stepsCount !== 0) {
            lapisLazuliRequired += decorationRequired;
        } else {
            marbleRequired += decorationRequired;
        }

        base -= 2;
    }

    console.log(`Stone required: ${Math.ceil(stoneRequired)}`);
    console.log(`Marble required: ${Math.ceil(marbleRequired)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuliRequired)}`);
    console.log(`Gold required: ${Math.ceil(goldRequired)}`);
    console.log(`Final pyramid height: ${Math.floor(stepsCount * increment)}`);
}