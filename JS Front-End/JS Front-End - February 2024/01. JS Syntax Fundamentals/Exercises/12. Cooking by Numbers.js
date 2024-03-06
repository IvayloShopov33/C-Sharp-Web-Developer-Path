function numbersCooking(number, firstAction, secondAction, thirdAction, fourthAction, fifthAction) {
    const operations = firstAction[0] + secondAction[0] + thirdAction[0] + fourthAction[0] + fifthAction[0];

    for (let i = 0; i < operations.length; i++) {
        switch (operations[i]) {
            case 'c':
                number /= 2;
                break;
            case 'd':
                number = Math.sqrt(number);
                break;
            case 's':
                number++;
                break;
            case 'b':
                number *= 3;
                break;
            case 'f':
                number -= number * 0.2;
                break;
        }

        console.log(number);
    }
}

function numbersCookingWithRestOperatorAndArray(number, ...actions) {
    for (let i = 0; i < actions.length; i++) {
        switch (actions[i]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number -= number * 0.2;
                break;
        }

        console.log(number);
    }
}