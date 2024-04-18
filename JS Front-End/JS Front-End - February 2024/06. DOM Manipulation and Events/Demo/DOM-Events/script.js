const counterElement = document.getElementById('counter');

//Using HTML Attributes
function onIncrement() {
    counterElement.textContent = Number(counterElement.textContent) + 1;
}

//Using DOM element properties
const decrementButtonElement = document.getElementById('decrement-button');
decrementButtonElement.onclick = function () {
    counterElement.textContent = Number(counterElement.textContent) - 1;
}

//Using DOM event handler - preferred method
const resetButtonElement = document.getElementById('reset-button');
const resetButtonEventListener = () => {
    counterElement.textContent = '0';
};

resetButtonElement.addEventListener('click', resetButtonEventListener);

//Remove an event listener for reset button after 8 seconds
setTimeout(() => {
    resetButtonElement.removeEventListener('click', resetButtonEventListener);
}, 8000);

const inputNumberElement = document.getElementById('number');
inputNumberElement.addEventListener('input', (event) => {
    counterElement.textContent = event.target.value;
});

//Multiple Listeners
resetButtonElement.addEventListener('click', (event) => {
    inputNumberElement.value = '';
})