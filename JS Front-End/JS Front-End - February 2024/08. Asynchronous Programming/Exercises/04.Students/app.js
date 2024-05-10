function attachEvents() {
    const baseURL = 'http://localhost:3030/jsonstore/collections/students';
    const tableBody = document.querySelector('#results tbody');

    fetch(baseURL)
        .then(response => response.json())
        .then(students => {
            const studentsFragment = document.createDocumentFragment();
            for (const student in students) {
                const newTableRow = createNewTableRow(students[student]);
                studentsFragment.appendChild(newTableRow);
            }

           tableBody.appendChild(studentsFragment);
        });

    const submitButton = document.getElementById('submit');
    submitButton.addEventListener('click', () => {
        const firstName = document.querySelector('input[name=firstName]');
        const lastName = document.querySelector('input[name=lastName]');
        const facultyNumber = document.querySelector('input[name=facultyNumber]');
        const grade = document.querySelector('input[name=grade]');

        if (!firstName.value || !lastName.value || !facultyNumber.value || !grade.value) {
            return;
        }

        fetch(baseURL, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({
                firstName: firstName.value,
                lastName: lastName.value,
                facultyNumber: facultyNumber.value,
                grade: grade.value,
            }),
        })
            .then(response => response.json())
            .then(student => {
                const newTableRow = createNewTableRow(student);
                tableBody.appendChild(newTableRow);

                firstName.value = '';
                lastName.value = '';
                facultyNumber.value = '';
                grade.value = '';
            })
    });

    function createNewTableRow(student) {
        const newTableRow = document.createElement('tr');

        const firstName = document.createElement('td');
        firstName.textContent = student.firstName;
        newTableRow.appendChild(firstName);

        const lastName = document.createElement('td');
        lastName.textContent = student.lastName;
        newTableRow.appendChild(lastName);

        const facultyNumber = document.createElement('td');
        facultyNumber.textContent = student.facultyNumber;
        newTableRow.appendChild(facultyNumber);

        const grade = document.createElement('td');
        grade.textContent = student.grade;
        newTableRow.appendChild(grade);

        return newTableRow;
    }
}

attachEvents();