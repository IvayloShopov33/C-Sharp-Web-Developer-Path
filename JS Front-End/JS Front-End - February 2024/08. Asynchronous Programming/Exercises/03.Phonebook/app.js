function attachEvents() {
    const baseURL = 'http://localhost:3030/jsonstore/phonebook';
    const phoneBookUlElement = document.getElementById('phonebook');
    const loadButton = document.getElementById('btnLoad');

    loadButton.addEventListener('click', () => {
        phoneBookUlElement.innerHTML = '';

        fetch(baseURL)
            .then(response => response.json())
            .then(phoneBook => {
                const phonesFragment = document.createDocumentFragment();
                for (const phone in phoneBook) {
                    const phoneData = document.createElement('li');
                    phoneData.id = phoneBook[phone]._id;
                    phoneData.textContent = `${phoneBook[phone].person}: ${phoneBook[phone].phone}`;

                    const deletePhoneButton = document.createElement('button');
                    deletePhoneButton.textContent = 'Delete';

                    phoneData.appendChild(deletePhoneButton);
                    phonesFragment.appendChild(phoneData);
                }

                phoneBookUlElement.appendChild(phonesFragment);
            });
    });

    const personInputName = document.getElementById('person');
    const personInputPhone = document.getElementById('phone');
    const createButton = document.getElementById('btnCreate');

    createButton.addEventListener('click', () => {
        fetch(baseURL, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({
                'person': personInputName.value,
                'phone': personInputPhone.value,
            }),
        })
            .then(response => response.json())
            .then(phone => {
                const newPhoneLiElement = document.createElement('li');
                newPhoneLiElement.id = phone._id;
                newPhoneLiElement.textContent = `${phone.person}: ${phone.phone}`;

                const deletePhoneButton = document.createElement('button');
                deletePhoneButton.textContent = 'Delete';

                newPhoneLiElement.appendChild(deletePhoneButton);
                phoneBookUlElement.appendChild(newPhoneLiElement);

                personInputName.value = '';
                personInputPhone.value = '';
            })
    })

    phoneBookUlElement.addEventListener('click', (e) => {
        if (e.target.tagName === 'BUTTON') {
            const phoneToDelete = e.target.parentNode;

            fetch(`${baseURL}/${phoneToDelete.id}`, {
                method: 'DELETE',
            })
                .then(response => response.json())
                .then(phone => {
                    const phoneLiElement = document.getElementById(phone._id);
                    phoneLiElement.remove();
                })
        }
    });
}

attachEvents();