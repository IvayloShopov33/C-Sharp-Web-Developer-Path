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
                for (let rows = 0; rows < inputValues.length; rows += 9) {
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
            let rowIndex = 0;
            let columnIndex = 0;

            for (let row = 0; row < tableRows.length; row++) {
                const uniqueValuesInSquare = [];
                columnIndex = 0;
                for (let col = 0; col < tableRows.length; col++) {
                    columnIndex = col % 3 === 0 && col > 0
                        ? columnIndex + 6
                        : columnIndex;

                    if (uniqueValuesInSquare.includes(inputValues[rowIndex + columnIndex])) {
                        isSudokuValid = false;
                        break;
                    }

                    uniqueValuesInSquare.push(inputValues[rowIndex + columnIndex]);
                    columnIndex++;
                }

                rowIndex = row === 2 || row === 5 || row === 8
                    ? rowIndex += 21
                    : rowIndex += 3;
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