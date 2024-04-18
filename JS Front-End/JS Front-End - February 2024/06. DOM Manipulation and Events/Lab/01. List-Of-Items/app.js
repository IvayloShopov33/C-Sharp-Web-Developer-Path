function addItem() {
    const itemsListElement = document.getElementById('items');
    const inputElement = document.getElementById('newItemText');

    const newLiElment = document.createElement('li');
    newLiElment.textContent = inputElement.value;

    itemsListElement.appendChild(newLiElment);

    inputElement.value = '';
}