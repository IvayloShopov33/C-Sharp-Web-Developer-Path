function ages(age) {
    if (age > 65) {
        console.log('elder');
    } else if (age > 19) {
        console.log('adult');
    } else if (age > 13) {
        console.log('teenager');
    } else if (age > 2) {
        console.log('child');
    } else if (age >= 0) {
        console.log('baby');
    } else {
        console.log('out of bounds');
    }
}