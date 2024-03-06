function bitcoinMining(minedGoldPerDays) {
    const bitcoinPrice = 11949.16;
    const goldPricePerOneGram = 67.51;

    let daysUntilFirstBoughtBitcoin = 0;
    let totalSumOfMoney = 0;
    let totalBitcoinBought = 0;

    for (let i = 0; i < minedGoldPerDays.length; i++) {
        if ((i + 1) % 3 === 0) {
            minedGoldPerDays[i] -= minedGoldPerDays[i] * 0.3;
        }

        totalSumOfMoney += minedGoldPerDays[i] * goldPricePerOneGram;
        if (totalSumOfMoney >= bitcoinPrice) {
            if (totalBitcoinBought === 0) {
                daysUntilFirstBoughtBitcoin++;
            }

            while (totalSumOfMoney >= bitcoinPrice) {
                totalSumOfMoney -= bitcoinPrice;
                totalBitcoinBought++;
            }
        }

        if (totalBitcoinBought === 0) {
            daysUntilFirstBoughtBitcoin++;
        }
    }

    console.log(`Bought bitcoins: ${totalBitcoinBought}`);
    if (totalBitcoinBought !== 0) {
        console.log(`Day of the first purchased bitcoin: ${daysUntilFirstBoughtBitcoin}`);
    }

    console.log(`Left money: ${totalSumOfMoney.toFixed(2)} lv.`);
}