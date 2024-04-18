const orangeElement = document.querySelector('.orange');
const greenElement = document.querySelector('.green');
const yellowElement = document.querySelector('.yellow');

orangeElement.addEventListener('click', () => {
    console.log('Orange clicked');
}, { capture: true });

greenElement.addEventListener('click', (event) => {
    event.stopPropagation();
    console.log('Green clicked');
}, { capture: true });

yellowElement.addEventListener('click', () => {
    console.log('Yellow clicked');
}, { capture: true });