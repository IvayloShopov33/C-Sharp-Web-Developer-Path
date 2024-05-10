function lockedProfile() {
    fetch('http://localhost:3030/jsonstore/advanced/profiles')
        .then(response => response.json())
        .then(users => {
            const profilesFragment = document.createDocumentFragment();
            let userIndex = 1;

            for (const user in users) {
                const profileDiv = document.createElement('div');
                profileDiv.classList.add('profile');

                const profileImage = document.createElement('img');
                profileImage.src = './iconProfile2.png';
                profileImage.classList.add('userIcon');
                profileDiv.appendChild(profileImage);

                const lockLabel = document.createElement('label');
                lockLabel.textContent = 'Lock';
                profileDiv.appendChild(lockLabel);

                const inputLockRadioButton = document.createElement('input');
                inputLockRadioButton.type = 'radio';
                inputLockRadioButton.name = `user${userIndex}Locked`;
                inputLockRadioButton.value = 'lock';
                inputLockRadioButton.setAttribute('checked', 'checked');
                profileDiv.appendChild(inputLockRadioButton);

                const unlockLabel = document.createElement('label');
                unlockLabel.textContent = 'Unlock';
                profileDiv.appendChild(unlockLabel);

                const inputUnlockRadioButton = document.createElement('input');
                inputUnlockRadioButton.type = 'radio';
                inputUnlockRadioButton.name = `user${userIndex}Locked`;
                inputUnlockRadioButton.value = 'unlock';
                profileDiv.appendChild(inputUnlockRadioButton);

                const brElement = document.createElement('br');
                profileDiv.appendChild(brElement);

                const hrElement = document.createElement('hr');
                profileDiv.appendChild(hrElement);

                const usernameLabel = document.createElement('label');
                usernameLabel.textContent = 'Username';
                profileDiv.appendChild(usernameLabel);

                const inputUsername = document.createElement('input');
                inputUsername.type = 'text';
                inputUsername.name = `user${userIndex}Username`;
                inputUsername.value = users[user].username;
                inputUsername.setAttribute('disabled', 'disabled');
                inputUsername.setAttribute('readonly', 'readonly');
                profileDiv.appendChild(inputUsername);

                const userHiddenData = document.createElement('div');
                userHiddenData.classList.add(...[`user${userIndex}Username`, 'hiddenInfo']);

                const hiddenHrElement = document.createElement('hr');
                userHiddenData.appendChild(hiddenHrElement);

                const emailLabel = document.createElement('label');
                emailLabel.textContent = 'Email:';
                userHiddenData.appendChild(emailLabel);

                const inputEmail = document.createElement('input');
                inputEmail.type = 'email';
                inputEmail.name = `user${userIndex}Username`;
                inputEmail.value = users[user].email;
                inputEmail.setAttribute('disabled', 'disabled');
                inputEmail.setAttribute('readonly', 'readonly');
                userHiddenData.appendChild(inputEmail);

                const ageLabel = document.createElement('label');
                ageLabel.textContent = 'Age:';
                userHiddenData.appendChild(ageLabel);

                const inputAge = document.createElement('input');
                inputAge.type = 'email';
                inputAge.name = `user${userIndex}Username`;
                inputAge.value = users[user].age;
                inputAge.setAttribute('disabled', 'disabled');
                inputAge.setAttribute('readonly', 'readonly');
                userHiddenData.appendChild(inputAge);

                profileDiv.appendChild(userHiddenData);

                const showOrHideButton = document.createElement('button');
                showOrHideButton.textContent = 'Show more';

                showOrHideButton.addEventListener('click', () => {
                    if (inputUnlockRadioButton.checked) {
                        if (showOrHideButton.textContent === 'Show more') {
                            userHiddenData.classList.remove('hiddenInfo');
                            showOrHideButton.textContent = 'Hide it';
                        } else {
                            userHiddenData.classList.add('hiddenInfo');
                            showOrHideButton.textContent = 'Show more';
                        }
                    }
                });

                profileDiv.appendChild(showOrHideButton);
                profilesFragment.appendChild(profileDiv);

                userIndex++;
            }

            const mainElement = document.getElementById('main');
            mainElement.appendChild(profilesFragment);
        });
}