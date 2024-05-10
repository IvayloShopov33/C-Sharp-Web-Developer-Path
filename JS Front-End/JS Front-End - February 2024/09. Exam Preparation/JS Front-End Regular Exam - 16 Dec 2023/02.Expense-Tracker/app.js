window.addEventListener("load", solve);

function solve() {
    const expenseType = document.getElementById('expense');
    const expenseAmount = document.getElementById('amount');

    const dateElement = document.getElementById('date');

    const addButton = document.getElementById('add-btn');
    addButton.addEventListener('click', () => {
        if (!expenseType.value || !expenseAmount.value || !dateElement.value) {
            return;
        }

        addButton.setAttribute('disabled', 'disabled');
        const previewListUlElement = document.getElementById('preview-list');
        const newLiElement = document.createElement('li');
        newLiElement.classList.add('expense-item');

        const articleElement = document.createElement('article');
        const type = document.createElement('p');
        type.textContent = `Type: ${expenseType.value}`;
        articleElement.appendChild(type);

        const amount = document.createElement('p');
        amount.textContent = `Amount: ${expenseAmount.value}$`;
        articleElement.appendChild(amount);

        const expenseDate = document.createElement('p');
        expenseDate.textContent = `Date: ${dateElement.value}`;
        articleElement.appendChild(expenseDate);

        newLiElement.appendChild(articleElement);

        const buttons = document.createElement('div');
        buttons.classList.add('buttons');

        const editButton = document.createElement('button');
        editButton.classList.add(...['btn', 'edit']);
        editButton.textContent = 'edit';
        buttons.appendChild(editButton);

        editButton.addEventListener('click', () => {
            expenseType.value = type.textContent.split(': ').pop();
            expenseAmount.value = amount.textContent.split(': ').pop().replace('$', '');
            dateElement.value = expenseDate.textContent.split(': ').pop();

            addButton.removeAttribute('disabled');
            newLiElement.remove();
        });

        const okButton = document.createElement('button');
        okButton.classList.add(...['btn', 'ok']);
        okButton.textContent = 'ok';
        buttons.appendChild(okButton);

        okButton.addEventListener('click', () => {
            buttons.remove();
            const recordToMove = newLiElement;
            newLiElement.remove();

            const expensesUlElement = document.getElementById('expenses-list');
            expensesUlElement.appendChild(recordToMove);
            addButton.removeAttribute('disabled');
        })

        newLiElement.appendChild(buttons);
        previewListUlElement.appendChild(newLiElement);

        expenseType.value = '';
        expenseAmount.value = '';
        dateElement.value = '';
    });

    const deleteButton = document.querySelector('.delete');
    deleteButton.addEventListener('click', () => {
        location.reload();
    });
}