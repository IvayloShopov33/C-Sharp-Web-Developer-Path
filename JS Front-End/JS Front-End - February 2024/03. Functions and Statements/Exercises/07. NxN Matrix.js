function printMatrix(rowsAndCols) {
    const printRow = (rowsAndCols) => console.log(`${rowsAndCols} `.repeat(rowsAndCols).trim());

    for (let i = 0; i < rowsAndCols; i++) {
        printRow(rowsAndCols);
    }
}