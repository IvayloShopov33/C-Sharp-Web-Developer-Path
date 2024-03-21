function solve(producsInput) {
    let productsCatalogue = {};
    let capitalLetters = '';
    for (const productInput of producsInput) {
        const [name, price] = productInput.split(' : ');
        productsCatalogue[name] = price;
        if (!capitalLetters.includes(name[0])) {
            capitalLetters += name[0];
        }
    }

    const sortedProductsCatalogue = Object.entries(productsCatalogue).sort((a, b) => a[0].localeCompare(b[0]));
    productsCatalogue = Object.fromEntries(sortedProductsCatalogue);

    for (const product in productsCatalogue) {
        if (capitalLetters.includes(product[0])) {
            console.log(product[0]);
            capitalLetters = capitalLetters.replace(product[0], ' ');
        }

        console.log(`  ${product}: ${productsCatalogue[product]}`);
    }
}

solve(['Appricot : 20.4', 'Fridge : 1500', 'TV : 1499', 'Deodorant : 10',
    'Boiler : 300', 'Apple : 1.25', 'Anti-Bug Spray : 15', 'T-Shirt : 10']);