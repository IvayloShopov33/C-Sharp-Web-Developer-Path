function focused() {
    const inputElements = document.querySelectorAll('input[type=text]');
    for (const inputElement of inputElements) {
        inputElement.addEventListener('focus', (event) => {
            event.target.parentNode.classList.add('focused');
        });

        inputElement.addEventListener('blur', (event) => {
            event.target.parentNode.classList.remove('focused');
        });
    }
}