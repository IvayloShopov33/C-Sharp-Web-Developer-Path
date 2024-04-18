function deleteByEmail() {
    const tableRows = document.querySelectorAll('#customers tbody tr');
    const inputEmailToDelete = document.querySelector('label input[type=text]');
    const output = document.getElementById('result');
    let isEmailFound = false;

    for (const tableRow of tableRows) {
        const email = tableRow.querySelector('td:last-child').textContent;

        if (email === inputEmailToDelete.value) {
            output.textContent = 'Deleted.';
            tableRow.remove();
            isEmailFound = true;
        }
    }

    if (!isEmailFound) {
        output.textContent = 'Not found.';
    }

    inputEmailToDelete.value = '';
}