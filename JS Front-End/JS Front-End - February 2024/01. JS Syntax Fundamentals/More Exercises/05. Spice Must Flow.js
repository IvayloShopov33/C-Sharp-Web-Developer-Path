function spiceCrops(startingYield) {
    let workingDays = 0;
    let totalSpices = 0;
    while (startingYield >= 100) {
        totalSpices += startingYield - 26;
        workingDays++;
        startingYield -= 10;
    }

    totalSpices -= 26;

    if (totalSpices < 0) {
        totalSpices = 0;
    }

    console.log(workingDays);
    console.log(totalSpices);
}