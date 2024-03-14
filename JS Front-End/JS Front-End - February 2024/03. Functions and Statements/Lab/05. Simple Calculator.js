function solve(a, b, operator) {
    let result = (a, b) => console.log(a + b);

    switch (operator) {
        case 'subtract':
            result = (a, b) => console.log(a - b);
            break;
        case 'multiply':
            result = (a, b) => console.log(a * b);
            break;
        case 'divide':
            result = (a, b) => console.log(a / b);
            break;
    }

    result(a, b);
}

function fancySolve(a, b, operator) {
    const operations = {
        add: (a, b) => a + b,
        subtract: (a, b) => a - b,
        multiply: (a, b) => a * b,
        divide: (a, b) => a / b
    }

    console.log(operations[operator](a, b));
}