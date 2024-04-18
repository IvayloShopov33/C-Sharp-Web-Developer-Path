function addItem() {
    const inputItemElement = document.getElementById('newItemText');
    const itemsListElement = document.getElementById('items');

    const newInputItemElement = document.createElement('li');
    newInputItemElement.textContent = inputItemElement.value;
    inputItemElement.value = '';

    const newDeleteLinkElement = document.createElement('a');
    newDeleteLinkElement.textContent = '[Delete]';
    newDeleteLinkElement.href = '#';

    newDeleteLinkElement.addEventListener('click', () => {
        newInputItemElement.remove();
    })

    newInputItemElement.appendChild(newDeleteLinkElement);
    itemsListElement.appendChild(newInputItemElement);
}