function solve() {
    const buttonElements = document.querySelectorAll('button');
    const tableSudoku = document.querySelector('table');
    const result = document.querySelector('#check p');

    const quickCheckButtonElement = buttonElements[0];
    const clearButtonElement = buttonElements[1];

    quickCheckButtonElement.addEventListener('click', () => {
        let isSudokuValid = true;
        const tableRows = document.querySelectorAll('tbody tr');
        const inputValues = [];

        for (const tableRow of tableRows) {
            const inputRowValues = tableRow.querySelectorAll('input[type=number]');
            const uniqueRowValues = [];

            for (const inputValue of inputRowValues) {
                if (uniqueRowValues.includes(inputValue.value)) {
                    isSudokuValid = false;
                    break;
                }

                uniqueRowValues.push(inputValue.value);
                inputValues.push(inputValue.value);
            }

            if (!isSudokuValid) {
                break;
            }
        }

        if (isSudokuValid) {
            for (let cols = 0; cols < tableRows.length; cols++) {
                const uniqueColumnValues = [];
                for (let rows = 0; rows < inputValues.length; rows += 3) {
                    if (uniqueColumnValues.includes(inputValues[cols + rows])) {
                        isSudokuValid = false;
                        break;
                    }

                    uniqueColumnValues.push(inputValues[cols + rows]);
                }

                if (!isSudokuValid) {
                    break;
                }
            }
        }

        if (isSudokuValid) {
            tableSudoku.style.border = '2px solid green';
            result.textContent = 'You solve it! Congratulations!';
            result.style.color = 'green';
        } else {
            tableSudoku.style.border = '2px solid red';
            result.textContent = 'NOP! You are not done yet...';
            result.style.color = 'red';
        }
    });

    clearButtonElement.addEventListener('click', () => {
        tableSudoku.style.border = 'none';
        result.textContent = '';
        const allInputElements = document.querySelectorAll('tbody tr td input[type=number]');

        for (const inputElement of allInputElements) {
            inputElement.value = '';
        }
    });
}