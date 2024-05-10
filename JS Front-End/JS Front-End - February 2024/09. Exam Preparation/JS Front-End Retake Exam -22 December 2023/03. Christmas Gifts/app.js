function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/gifts';
    const presentInput = document.getElementById('gift');
    const forPersonNameInput = document.getElementById('for');
    const priceInput = document.getElementById('price');
    const editPresentButton = document.getElementById('edit-present');
    const addPresentButton = document.getElementById('add-present');
    const presentsListUlElement = document.getElementById('gift-list');
    let currentPresentId;

    const loadPresentsButton = document.getElementById('load-presents');
    loadPresentsButton.addEventListener('click', () => {
        loadAllPresents();
    });

    function loadAllPresents() {
        fetch(baseUrl)
            .then(response => response.json())
            .then(presents => {
                presentsListUlElement.textContent = '';
                const presentsFragment = document.createDocumentFragment();
                for (const present in presents) {
                    const presentData = presents[present];
                    currentPresentId = presents[present]._id;
                    const presentDiv = createNewPresentDiv(currentPresentId, presentData);
                    presentsFragment.appendChild(presentDiv);
                }

                presentsListUlElement.appendChild(presentsFragment);
            });
    }

    function createNewPresentDiv(currentPresentId, present) {
        const presentDiv = document.createElement('div');
        presentDiv.classList.add('gift-sock');

        const presentContentDiv = document.createElement('div');
        presentDiv.classList.add('content');

        const gift = document.createElement('p');
        gift.textContent = present.gift;
        presentContentDiv.appendChild(gift);

        const forPersonName = document.createElement('p');
        forPersonName.textContent = present.for;
        presentContentDiv.appendChild(forPersonName);

        const price = document.createElement('p');
        price.textContent = present.price;
        presentContentDiv.appendChild(price);

        presentDiv.appendChild(presentContentDiv);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons-container');

        const changePresentButton = document.createElement('button');
        changePresentButton.classList.add('change-btn');
        changePresentButton.textContent = 'Change';
        buttonsDiv.appendChild(changePresentButton);

        changePresentButton.addEventListener('click', () => {
            presentInput.value = gift.textContent;
            forPersonNameInput.value = forPersonName.textContent;
            priceInput.value = price.textContent;

            editPresentButton.removeAttribute('disabled');
            addPresentButton.setAttribute('disabled', 'disabled');
            presentDiv.remove();
            editPresent(currentPresentId);
        });

        const deletePresentButton = document.createElement('button');
        deletePresentButton.classList.add('delete-btn');
        deletePresentButton.textContent = 'Delete';
        buttonsDiv.appendChild(deletePresentButton);

        deletePresentButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentPresentId}`, {
                method: 'DELETE',
            });
            presentDiv.remove();
        });

        presentDiv.appendChild(buttonsDiv);

        return presentDiv;
    }

    function editPresent(currentPresentId) {
        editPresentButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentPresentId}`, {
                method: 'PUT',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    gift: presentInput.value,
                    for: forPersonNameInput.value,
                    price: priceInput.value,
                    _id: currentPresentId,
                }),
            })
                .then(response => response.json())
                .then(() => {
                    loadAllPresents();

                    presentInput.value = '';
                    forPersonNameInput.value = '';
                    priceInput.value = '';
                    editPresentButton.setAttribute('disabled', 'disablled');
                    addPresentButton.removeAttribute('disabled');
                    currentPresentId = null;
                });
        });
    }

    addPresentButton.addEventListener('click', () => {
        if (!presentInput.value || !priceInput.value || !forPersonNameInput.value) {
            return;
        }

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                gift: presentInput.value,
                for: forPersonNameInput.value,
                price: priceInput.value,
            }),
        })
            .then(() => {
                loadAllPresents();
                presentInput.value = '';
                forPersonNameInput.value = '';
                priceInput.value = '';
            })
    })
}

solve();