function vacation(peopleCount, groupType, weekday) {
    let price = 0;
    if (groupType === 'Students') {
        switch (weekday) {
            case 'Friday':
                price = 8.45;
                break;
            case 'Saturday':
                price = 9.8;
                break;
            case 'Sunday':
                price = 10.46;
                break;
        }

        price *= peopleCount;

        if (peopleCount >= 30) {
            price -= price * 0.15;
        }

    } else if (groupType === "Business") {
        switch (weekday) {
            case 'Friday':
                price = 10.9;
                break;
            case 'Saturday':
                price = 15.6;
                break;
            case 'Sunday':
                price = 16;
                break;
        }

        if (peopleCount >= 100) {
            peopleCount -= 10;
        }

        price *= peopleCount;

    } else if (groupType === 'Regular') {
        switch (weekday) {
            case 'Friday':
                price = 15;
                break;
            case 'Saturday':
                price = 20;
                break;
            case 'Sunday':
                price = 22.5;
                break;
        }

        price *= peopleCount;

        if (peopleCount >= 10 && peopleCount <= 20) {
            price -= price * 0.05;
        }
    }

    console.log(`Total price: ${price.toFixed(2)}`);
}