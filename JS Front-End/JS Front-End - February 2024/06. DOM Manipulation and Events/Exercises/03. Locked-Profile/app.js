function lockedProfile() {
    const allProfileElements = document.querySelectorAll('.profile');
    let usersCount = 1;

    for (const profileElement of allProfileElements) {
        const unlockRadioButtonElement = profileElement.querySelector(`input[value=unlock]`);
        const showOrHideButton = profileElement.querySelector(`#user${usersCount}HiddenFields + button`);
        const userHiddenInformation = profileElement.querySelector(`#user${usersCount}HiddenFields`);

        showOrHideButton.addEventListener('click', () => {
            if (unlockRadioButtonElement.checked) {
                if (showOrHideButton.textContent === 'Show more') {
                    userHiddenInformation.style.display = 'block';
                    showOrHideButton.textContent = 'Hide it';
                } else {
                    userHiddenInformation.style.display = 'none';
                    showOrHideButton.textContent = 'Show more';
                }
            }
        });

        usersCount++;
    }
}