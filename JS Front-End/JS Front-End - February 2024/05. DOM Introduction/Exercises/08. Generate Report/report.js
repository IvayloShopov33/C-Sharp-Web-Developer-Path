function generateReport() {
    const report = [];
    const inputElements = document.querySelectorAll('thead tr th input');
    let columnsIndex = 1;

    completeTheReportWithTheCheckedColumnsDetails(inputElements, report, columnsIndex);

    printReport(report);
}

function completeTheReportWithTheCheckedColumnsDetails(inputElements, report, columnsIndex) {
    for (const inputElement of inputElements) {
        if (inputElement.checked) {
            const tableRows = document.querySelectorAll('tbody tr');

            for (let i = 1; i <= tableRows.length; i++) {
                let rowObject = {};
                let isTheRowObjectInTheReport = false;

                if (report.length === tableRows.length) {
                    rowObject = report[i - 1];
                    isTheRowObjectInTheReport = true;
                }

                const selectedColumnText = document.querySelector(`tbody tr:nth-child(${i}) td:nth-child(${columnsIndex})`).textContent;
                rowObject[inputElement.name] = selectedColumnText;

                if (!isTheRowObjectInTheReport) {
                    report.push(rowObject);
                }
            }
        }

        columnsIndex++;
    }
}

function printReport(report) {
    const reportOutput = document.getElementById('output');
    reportOutput.textContent = JSON.stringify(report, null, 2);
}