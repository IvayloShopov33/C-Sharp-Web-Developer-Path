function circleArea(radius) {
    if (typeof radius != 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeof radius}.`);
    } else {
        const area = radius * radius * Math.PI;
        console.log(area.toFixed(2));
    }
}