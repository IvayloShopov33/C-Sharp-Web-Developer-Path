//Asynchronous programming with callback
console.log('start');
delayStart3(() => console.log('delayed start3'));
delayStart2(() => console.log('delayed start2'));
delayStart1(() => console.log('delayed start1'));
console.log('finish');

function delayStart3(callback) {
    setTimeout(() => {
        callback();
    }, 2200);
}

function delayStart2(callback) {
    setTimeout(() => {
        callback();
    }, 1000);
}

function delayStart1(callback) {
    setTimeout(() => {
        callback();
    }, 0);
}