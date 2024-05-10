const weddingPromise = new Promise((resolve, reject) => {
    if (Math.random() < 0.3) {
        return reject('It\'s me');
    }

    setTimeout(() => {
        resolve('Just married!');
    }, 4000);
});

weddingPromise
    .then(message => console.log(message))
    .catch(error => console.log(error))
    .finally(() => console.log('Love always wins!'));

//Always rejecting promise
const rejectingPromise = Promise.reject('Sorry next time');
console.log(rejectingPromise);
rejectingPromise.catch(message => console.log(message));

//Multiple parallel promises
const createTimeoutPromise = function (message, time) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve(message);
        }, time);
    });
}

const groupPromise = Promise.allSettled([
    Promise.resolve('First promise'),
    createTimeoutPromise('Second promise', 3000),
    createTimeoutPromise('Third promise', 1000),
    Promise.reject('Rejected Promise'),
]);

groupPromise.then(values => console.log(values));