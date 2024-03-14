function solve(actions) {
    let carValue = 0;
    for (let i = 0; i < actions.length; i++) {
        switch (actions[i]) {
            case 'soap':
                carValue += 10;
                break;
            case 'water':
                carValue += carValue * 0.2;
                break;
            case 'vacuum cleaner':
                carValue += carValue * 0.25;
                break;
            case 'mud':
                carValue -= carValue * 0.1;
                break;
        }
    }

    console.log(`The car is ${carValue.toFixed(2)}% clean.`);
}