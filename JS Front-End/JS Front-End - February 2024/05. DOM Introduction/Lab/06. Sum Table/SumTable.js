function sumTable() {
    let sum = 0;
    const allCosts = document.querySelectorAll('tr td:nth-child(even):not(#sum)');

    for (const cost of allCosts) {
        sum += Number(cost.textContent);
    }

    const totalCost = document.getElementById('sum');
    totalCost.textContent = sum;
}