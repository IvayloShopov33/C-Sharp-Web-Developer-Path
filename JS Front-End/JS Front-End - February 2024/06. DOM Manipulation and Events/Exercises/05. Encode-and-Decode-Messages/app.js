function encodeAndDecodeMessages() {
    const encodeAndSendButtonElement = document.querySelector('#main div:first-child button');
    const decodeAndReadButtonElement = document.querySelector('#main div:last-child button');
    const displayedMessage = document.querySelector('#main div:last-child textarea');

    encodeAndSendButtonElement.addEventListener('click', () => {
        const messageToEncode = document.querySelector('#main div:first-child textarea');
        const encodedMessage = [];

        for (const char of messageToEncode.value) {
            const newCharCode = char.charCodeAt(0) + 1;
            encodedMessage.push(String.fromCharCode(newCharCode));
        }

        displayedMessage.value = encodedMessage.join('');
        messageToEncode.value = '';
    });

    decodeAndReadButtonElement.addEventListener('click', () => {
        const messageToDecode = displayedMessage.value;
        const decodedMessage = [];

        for (const char of messageToDecode) {
            const newCharCode = char.charCodeAt(0) - 1;
            decodedMessage.push(String.fromCharCode(newCharCode));
        }

        displayedMessage.value = decodedMessage.join('');
    });
}