window.addEventListener("load", solve);

function solve() {
    const contactNameInput = document.getElementById('name');
    const contactNumberInput = document.getElementById('phone');
    const contactCategoryInput = document.getElementById('category');
    const contactListUlElement = document.getElementById('contact-list');

    const addContactButton = document.getElementById('add-btn');
    addContactButton.addEventListener('click', () => {
        if (!contactNameInput.value || !contactNumberInput.value || !contactCategoryInput.value) {
            return;
        }

        const newLiElement = document.createElement('li');
        const newArticleElement = document.createElement('article');

        const contactNameParagraph = document.createElement('p');
        contactNameParagraph.textContent = `name:${contactNameInput.value}`;
        newArticleElement.appendChild(contactNameParagraph);

        const contactNumberParagraph = document.createElement('p');
        contactNumberParagraph.textContent = `phone:${contactNumberInput.value}`;
        newArticleElement.appendChild(contactNumberParagraph);

        const contactCategoryParagraph = document.createElement('p');
        contactCategoryParagraph.textContent = `category:${contactCategoryInput.value}`;
        newArticleElement.appendChild(contactCategoryParagraph);

        newLiElement.appendChild(newArticleElement);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons');

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('edit-btn');

        editButtonElement.addEventListener('click', () => {
            contactNameInput.value = contactNameParagraph.textContent.split(':').pop();
            contactNumberInput.value = contactNumberParagraph.textContent.split(':').pop();
            contactCategoryInput.value = contactCategoryParagraph.textContent.split(':').pop();

            newLiElement.remove();
        });

        const saveButtonElement = document.createElement('button');
        saveButtonElement.classList.add('save-btn');
        saveButtonElement.addEventListener('click', () => {
            buttonsDiv.remove();
            const deleteButtonElement = document.createElement('button');
            deleteButtonElement.classList.add('del-btn');

            deleteButtonElement.addEventListener('click', () => {
                newLiElement.remove();
            });

            newLiElement.appendChild(deleteButtonElement);

            newLiElement.remove();
            contactListUlElement.appendChild(newLiElement);
        })

        buttonsDiv.appendChild(editButtonElement);
        buttonsDiv.appendChild(saveButtonElement);

        newLiElement.appendChild(buttonsDiv);

        const checkListUlElement = document.getElementById('check-list');
        checkListUlElement.appendChild(newLiElement);

        contactNameInput.value = '';
        contactNumberInput.value = '';
        contactCategoryInput.value = '';
    });
}