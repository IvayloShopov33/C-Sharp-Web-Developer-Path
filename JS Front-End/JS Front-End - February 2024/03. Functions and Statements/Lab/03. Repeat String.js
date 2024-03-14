function solve(text, repetitionCount) {
    const result = repeatString(text, repetitionCount);
    console.log(result);

}

function repeatString(text, repetitionCount) {
    return text.repeat(repetitionCount);
}

solve('Str', 2);