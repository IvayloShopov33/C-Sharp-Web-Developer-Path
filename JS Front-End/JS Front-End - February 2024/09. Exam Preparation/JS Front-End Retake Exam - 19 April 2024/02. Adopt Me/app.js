window.addEventListener("load", solve);

function solve() {
    const typeOfAnimalInput = document.getElementById('type');
    const animalAgeInput = document.getElementById('age');
    const animalGenderInput = document.getElementById('gender');
    const animalForAdoptionUlList = document.getElementById('adoption-info');
    const adoptedAnimalUlList = document.getElementById('adopted-list');

    const adoptAnimalButton = document.getElementById('adopt-btn');
    adoptAnimalButton.addEventListener('click', () => {
        if (!typeOfAnimalInput.value || !animalAgeInput.value || !animalGenderInput.value) {
            return;
        }

        const newLiElement = document.createElement('li');
        const newArticleElement = document.createElement('article');

        const typeOfAnimalParagraph = document.createElement('p');
        typeOfAnimalParagraph.textContent = `Pet:${typeOfAnimalInput.value}`;
        newArticleElement.appendChild(typeOfAnimalParagraph);

        const animalGenderParagraph = document.createElement('p');
        animalGenderParagraph.textContent = `Gender:${animalGenderInput.value}`;
        newArticleElement.appendChild(animalGenderParagraph);

        const animalAgeParagraph = document.createElement('p');
        animalAgeParagraph.textContent = `Age:${animalAgeInput.value}`;
        newArticleElement.appendChild(animalAgeParagraph);

        newLiElement.appendChild(newArticleElement);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons');

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('edit-btn');
        editButtonElement.textContent = 'Edit';

        editButtonElement.addEventListener('click', () => {
            typeOfAnimalInput.value = typeOfAnimalParagraph.textContent.split(':').pop();
            animalAgeInput.value = animalAgeParagraph.textContent.split(':').pop();
            animalGenderInput.value = animalGenderParagraph.textContent.split(':').pop();

            newLiElement.remove();
        });

        const doneButtonElement = document.createElement('button');
        doneButtonElement.classList.add('done-btn');
        doneButtonElement.textContent = 'Done';

        doneButtonElement.addEventListener('click', () => {
            buttonsDiv.remove();

            const clearButtonElement = document.createElement('button');
            clearButtonElement.classList.add('clear-btn');
            clearButtonElement.textContent = 'Clear';

            clearButtonElement.addEventListener('click', () => {
                newLiElement.remove();
            });

            newLiElement.appendChild(clearButtonElement);
            adoptedAnimalUlList.appendChild(newLiElement);
        });

        buttonsDiv.appendChild(editButtonElement);
        buttonsDiv.appendChild(doneButtonElement);

        newLiElement.appendChild(buttonsDiv);

        animalForAdoptionUlList.appendChild(newLiElement);

        typeOfAnimalInput.value = '';
        animalAgeInput.value = '';
        animalGenderInput.value = '';
    });
}