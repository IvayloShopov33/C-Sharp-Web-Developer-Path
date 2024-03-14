//Pass function as an argument
function executeOperation(operation, operandA, operandB) {
    const result = operation(operandA, operandB);
    console.log(`The result of this operation is: ${result.toFixed(2)}`);
}

function sum(a, b) {
    return a + b;
}

//Pass function by reference
executeOperation(sum, 1, 2);

//Pass function expression body as an argument
executeOperation(function (a, b) {
    return a / b;
}, 9, 3);

//Pass arrow function body as an argument
executeOperation((a, b) => a * b, 2, 4);