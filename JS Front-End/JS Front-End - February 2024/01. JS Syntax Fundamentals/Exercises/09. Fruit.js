function fruitPriceAndWeight(fruit, weightInGrams, pricePerKg) {
    const weightInKg = weightInGrams / 1000;
    const totalPrice = pricePerKg * weightInKg;
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}