function solve(input) {
    let message = input.shift();

    while (true) {
        const [action, ...furtherDetails] = input.shift().split('!');

        if (action === 'End') {
            console.log(`The concealed spell is: ${message}`);
            break;
        } else if (action === 'RemoveEven') {
            let newMessage = '';
            for (let i = 0; i < message.length; i++) {
                if (i % 2 === 0) {
                    newMessage += message[i];
                }
            }

            message = newMessage;
            console.log(message);
        } else if (action === 'TakePart') {
            const fromIndex = Number(furtherDetails.shift());
            const toIndex = Number(furtherDetails.shift());

            message = message.substring(fromIndex, toIndex);
            console.log(message);
        } else if (action === 'Reverse') {
            const substring = furtherDetails.shift();

            if (message.includes(substring)) {
                message = message.replace(substring, '');
                message += substring.split('').reverse().join('');
                console.log(message);
            } else {
                console.log('Error');
            }
        }
    }
}

solve(["asAsl2adkda2mdaczsa",
    "RemoveEven",
    "TakePart!1!9",
    "Reverse!maz",
    "End"]);

solve(["hZwemtroiui5tfone1haGnanbvcaploL2u2a2n2i2m",
    "TakePart!31!42",
    "RemoveEven",
    "Reverse!anim",
    "Reverse!sad",
    "End"]);