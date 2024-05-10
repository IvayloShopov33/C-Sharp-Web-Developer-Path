function attachEvents() {
    const baseURL = 'http://localhost:3030/jsonstore/messenger';
    const submitButton = document.getElementById('submit');

    submitButton.addEventListener('click', () => {
        const authorName = document.querySelector('input[name=author]');
        const messageContent = document.querySelector('input[name=content]');

        fetch(baseURL, {
            method: 'POST',
            body: JSON.stringify({
                author: authorName.value,
                content: messageContent.value,
            }),
        });

        authorName.value = '';
        messageContent.value = '';
    });

    const messagesTextarea = document.getElementById('messages');
    const refreshButton = document.getElementById('refresh');

    refreshButton.addEventListener('click', () => {
        messagesTextarea.textContent = '';
        const allMessages = [];

        fetch(baseURL)
            .then(response => response.json())
            .then(messages => {
                for (const message in messages) {
                    allMessages.push(`${messages[message].author}: ${messages[message].content}`);
                }

                messagesTextarea.textContent = allMessages.join('\n');
            });
    });
}

attachEvents();