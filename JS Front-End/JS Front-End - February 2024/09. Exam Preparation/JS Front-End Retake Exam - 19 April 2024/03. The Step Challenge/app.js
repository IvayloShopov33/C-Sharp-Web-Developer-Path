function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/records';
    const personNameInput = document.getElementById('p-name');
    const personStepsInput = document.getElementById('steps');
    const personCaloriesInput = document.getElementById('calories');
    const editRecordButton = document.getElementById('edit-record');
    const addRecordButton = document.getElementById('add-record');
    const recordsListUlElement = document.getElementById('list');
    let currentRecordId;

    const loadRecordsButton = document.getElementById('load-records');
    loadRecordsButton.addEventListener('click', () => {
        loadAllRecords();
    });

    function loadAllRecords() {
        fetch(baseUrl)
            .then(response => response.json())
            .then(records => {
                recordsListUlElement.textContent = '';
                const recordsFragment = document.createDocumentFragment();

                for (const record in records) {
                    const recordData = records[record];
                    currentRecordId = records[record]._id;
                    const recordDiv = createNewRecordDiv(currentRecordId, recordData);
                    recordsFragment.appendChild(recordDiv);
                }

                recordsListUlElement.appendChild(recordsFragment);
            });
    }

    function createNewRecordDiv(currentRecordId, record) {
        const recordDiv = document.createElement('div');
        recordDiv.classList.add('record');

        const recordContentDiv = document.createElement('div');
        recordDiv.classList.add('info');

        const personName = document.createElement('p');
        personName.textContent = record.name;
        recordContentDiv.appendChild(personName);

        const personSteps = document.createElement('p');
        personSteps.textContent = record.steps;
        recordContentDiv.appendChild(personSteps);

        const personCalories = document.createElement('p');
        personCalories.textContent = record.calories;
        recordContentDiv.appendChild(personCalories);

        recordDiv.appendChild(recordContentDiv);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('buttons-wraper');

        const changeRecordButton = document.createElement('button');
        changeRecordButton.classList.add('change-btn');
        changeRecordButton.textContent = 'Change';
        buttonsDiv.appendChild(changeRecordButton);

        changeRecordButton.addEventListener('click', () => {
            personNameInput.value = personName.textContent;
            personStepsInput.value = personSteps.textContent;
            personCaloriesInput.value = personCalories.textContent;

            editRecordButton.removeAttribute('disabled');
            addRecordButton.setAttribute('disabled', 'disabled');

            recordDiv.remove();
            editRecord(currentRecordId);
        });

        const deleteRecordButton = document.createElement('button');
        deleteRecordButton.classList.add('delete-btn');
        deleteRecordButton.textContent = 'Delete';
        buttonsDiv.appendChild(deleteRecordButton);

        deleteRecordButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentRecordId}`, {
                method: 'DELETE',
            });

            recordDiv.remove();
        });

        recordDiv.appendChild(buttonsDiv);

        return recordDiv;
    }

    function editRecord(currentRecordId) {
        editRecordButton.addEventListener('click', () => {
            fetch(`${baseUrl}/${currentRecordId}`, {
                method: 'PUT',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    name: personNameInput.value,
                    steps: personStepsInput.value,
                    calories: personCaloriesInput.value,
                    _id: currentRecordId,
                }),
            })
                .then(response => response.json())
                .then(() => {
                    loadAllRecords();

                    personNameInput.value = '';
                    personStepsInput.value = '';
                    personCaloriesInput.value = '';

                    editRecordButton.setAttribute('disabled', 'disablled');
                    addRecordButton.removeAttribute('disabled');
                    currentRecordId = null;
                });
        });
    }

    addRecordButton.addEventListener('click', () => {
        if (!personNameInput.value || !personCaloriesInput.value || !personStepsInput.value) {
            return;
        }

        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                name: personNameInput.value,
                steps: personStepsInput.value,
                calories: personCaloriesInput.value,
            }),
        })
            .then(() => {
                loadAllRecords();

                personNameInput.value = '';
                personStepsInput.value = '';
                personCaloriesInput.value = '';
            });
    });
}

solve();