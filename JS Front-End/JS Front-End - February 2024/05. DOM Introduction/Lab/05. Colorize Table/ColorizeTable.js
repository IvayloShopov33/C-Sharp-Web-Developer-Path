function colorize() {
    const evenRowsElements = document.querySelectorAll('table tr:nth-child(even)');
    for (const row of evenRowsElements) {
        row.style.backgroundColor = 'teal';
    }
}