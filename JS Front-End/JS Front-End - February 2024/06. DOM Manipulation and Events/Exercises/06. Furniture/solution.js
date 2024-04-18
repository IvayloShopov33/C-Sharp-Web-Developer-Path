function solve() {
    const textareaElements = document.querySelectorAll('#exercise textarea');
    const buttonElements = document.querySelectorAll('#exercise button');
    const tableBody = document.querySelector('.table tbody');
    const newTableRowsFragment = document.createDocumentFragment();

    const generateButton = buttonElements[0];
    const buyButton = buttonElements[1];

    generateButton.addEventListener('click', () => {
        const furnitureObjects = JSON.parse(textareaElements[0].value);
        for (const furniture of furnitureObjects) {
            const newTableRow = document.createElement('tr');

            const imageData = document.createElement('td');
            const image = document.createElement('img');
            image.src = furniture.img;
            imageData.appendChild(image);
            newTableRow.appendChild(imageData);

            const nameData = document.createElement('td');
            nameData.textContent = furniture.name;
            nameData.classList.add('name');
            newTableRow.appendChild(nameData);

            const priceData = document.createElement('td');
            priceData.textContent = furniture.price;
            priceData.classList.add('price');
            newTableRow.appendChild(priceData);

            const decFactorData = document.createElement('td');
            decFactorData.textContent = furniture.decFactor;
            decFactorData.classList.add('decFactor');
            newTableRow.appendChild(decFactorData);

            const checkBoxData = document.createElement('td');
            const inputCheckBox = document.createElement('input');
            inputCheckBox.setAttribute('type', 'checkbox');
            checkBoxData.appendChild(inputCheckBox);
            newTableRow.appendChild(checkBoxData);

            newTableRowsFragment.appendChild(newTableRow);
        }

        tableBody.appendChild(newTableRowsFragment);
        textareaElements[0].value = '';
    });

    buyButton.addEventListener('click', () => {
        const furnitureNames = [];
        let totalPrice = 0;
        let averageDecorationFactor = 0;
        const furnitureToBuy = tableBody.querySelectorAll('input[type=checkbox]');

        for (const furniture of furnitureToBuy) {
            if (furniture.checked) {
                const furnitureData = furniture.closest('tr');
                const furnitureName = furnitureData.querySelector('.name').textContent;
                const furniturePrice = Number(furnitureData.querySelector('.price').textContent);
                const furnitureDecorationFactor = Number(furnitureData.querySelector('.decFactor').textContent);

                furnitureNames.push(furnitureName);
                totalPrice += furniturePrice;
                averageDecorationFactor += furnitureDecorationFactor;
            }
        }

        averageDecorationFactor /= furnitureNames.length;
        const outputTextareaElement = textareaElements[1];

        outputTextareaElement.value = `Bought furniture: ${furnitureNames.join(', ')}\n`;
        outputTextareaElement.value += `Total price: ${totalPrice.toFixed(2)}\n`;
        outputTextareaElement.value += `Average decoration factor: ${averageDecorationFactor.toFixed(2)}`;
    });
}