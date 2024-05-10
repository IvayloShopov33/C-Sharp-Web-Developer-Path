function solve(input) {
    let encodedMessage = input.shift();

    while (true) {
        const [action, ...furtherDetails] = input.shift().split('?');

        if (action === 'Buy') {
            console.log(`The cryptocurrency is: ${encodedMessage}`);
            break;
        } else if (action === 'TakeEven') {
            let newMessage = '';

            for (let i = 0; i < encodedMessage.length; i++) {
                if (i % 2 === 0) {
                    newMessage += encodedMessage[i];
                }
            }

            encodedMessage = newMessage;
            console.log(encodedMessage);
        } else if (action === 'ChangeAll') {
            const [substring, replacement] = furtherDetails.join('?').split('?');

            while (encodedMessage.includes(substring)) {
                encodedMessage = encodedMessage.replace(substring, replacement);
            }

            console.log(encodedMessage);
        } else if (action === 'Reverse') {
            const substring = furtherDetails.shift();

            if (encodedMessage.includes(substring)) {
                encodedMessage = encodedMessage.replace(substring, '');
                encodedMessage += substring.split('').reverse().join('');

                console.log(encodedMessage);
            } else {
                console.log('error');
            }
        }
    }
}

solve(["z2tdsfndoctsB6z7tjc8ojzdngzhtjsyVjek!snfzsafhscs",
    "TakeEven",
    "Reverse?!nzahc",
    "ChangeAll?m?g",
    "Reverse?adshk",
    "ChangeAll?z?i",
    "Buy"]);

solve(["PZDfA2PkAsakhnefZ7aZ",
    "TakeEven",
    "TakeEven",
    "TakeEven",
    "ChangeAll?Z?X",
    "ChangeAll?A?R",
    "Reverse?PRX",
    "Buy"]);