function solve(currentStocks, orderedStocks) {
    const stocks = {};
    for (let i = 0; i < currentStocks.length; i += 2) {
        const stock = currentStocks[i];
        const stockQuantity = Number(currentStocks[i + 1]);
        stocks[stock] = stockQuantity;
    }

    for (let i = 0; i < orderedStocks.length; i += 2) {
        const stock = orderedStocks[i];
        const stockQuantity = Number(orderedStocks[i + 1]);

        if (stocks[stock]) {
            stocks[stock] += stockQuantity;
        } else {
            stocks[stock] = stockQuantity;
        }
    }

    for (const stock in stocks) {
        console.log(`${stock} -> ${stocks[stock]}`);
    }
}

function solveFancy(currentStocks, orderedStocks) {
    const getStocks = (list) => {
        const stocks = {};

        for (let i = 0; i < list.length; i += 2) {
            const stock = list[i];
            const stockQuantity = Number(list[i + 1]);

            if (!stocks[stock]) {
                stocks[stock] = 0;
            }

            stocks[stock] += stockQuantity;
        }

        return stocks;
    }

    //const storeStocks = getStocks(currentStocks.concat(orderedStocks));
    const storeStocks = getStocks([...currentStocks, ...orderedStocks]);

    Object
        .keys(storeStocks)
        .forEach(stock => console.log(`${stock} -> ${storeStocks[stock]}`));
}

solve(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);

solveFancy(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);