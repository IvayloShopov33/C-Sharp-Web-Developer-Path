window.addEventListener("load", solve);

function solve() {
    const taskPlaceInput = document.getElementById('place');
    const taskActionInput = document.getElementById('action');
    const taskPersonInput = document.getElementById('person');
    const taskListUlElement = document.getElementById('task-list');
    const doneTasksListUlElement = document.getElementById('done-list');

    const addTaskButton = document.getElementById('add-btn');
    addTaskButton.addEventListener('click', () => {
        if (!taskPlaceInput.value || !taskActionInput.value || !taskPersonInput.value) {
            return;
        }

        const newLiElement = document.createElement('li');
        newLiElement.classList.add('clean-task');
        const newArticleElement = document.createElement('article');

        const taskPlaceParagraph = document.createElement('p');
        taskPlaceParagraph.textContent = `Place:${taskPlaceInput.value}`;
        newArticleElement.appendChild(taskPlaceParagraph);

        const taskActionParagraph = document.createElement('p');
        taskActionParagraph.textContent = `Action:${taskActionInput.value}`;
        newArticleElement.appendChild(taskActionParagraph);

        const taskPersonParagraph = document.createElement('p');
        taskPersonParagraph.textContent = `Person:${taskPersonInput.value}`;
        newArticleElement.appendChild(taskPersonParagraph);

        newLiElement.appendChild(newArticleElement);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons');

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('edit');
        editButtonElement.textContent = 'Edit';

        editButtonElement.addEventListener('click', () => {
            taskPlaceInput.value = taskPlaceParagraph.textContent.split(':').pop();
            taskActionInput.value = taskActionParagraph.textContent.split(':').pop();
            taskPersonInput.value = taskPersonParagraph.textContent.split(':').pop();

            newLiElement.remove();
        });

        const doneButtonElement = document.createElement('button');
        doneButtonElement.classList.add('done');
        doneButtonElement.textContent = 'Done';

        doneButtonElement.addEventListener('click', () => {
            newLiElement.classList.remove('clean-task');
            buttonsDiv.remove();

            const deleteButtonElement = document.createElement('button');
            deleteButtonElement.classList.add('delete');
            deleteButtonElement.textContent = 'Delete';

            deleteButtonElement.addEventListener('click', () => {
                newLiElement.remove();
            });

            newLiElement.appendChild(deleteButtonElement);
            doneTasksListUlElement.appendChild(newLiElement);
        })

        buttonsDiv.appendChild(editButtonElement);
        buttonsDiv.appendChild(doneButtonElement);

        newLiElement.appendChild(buttonsDiv);

        taskListUlElement.appendChild(newLiElement);

        taskPlaceInput.value = '';
        taskActionInput.value = '';
        taskPersonInput.value = '';
    });
}