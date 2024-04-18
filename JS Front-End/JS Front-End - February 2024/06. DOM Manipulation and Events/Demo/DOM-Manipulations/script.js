//DOM Query
const seriesListElement = document.getElementById('series');
const firstSeriesElement = document.querySelector('.first-series');

//Create an Element
const secondSeriesElement = document.createElement('li');
secondSeriesElement.textContent = 'Undercover';

//Append a new element to DOM
seriesListElement.appendChild(secondSeriesElement);

//Append an existing element to Dom
setTimeout(() => {
    seriesListElement.appendChild(firstSeriesElement);
}, 1500);

//Clone an existing element and prepend
const firstSeriesCloneElement = firstSeriesElement.cloneNode(true);
firstSeriesCloneElement.textContent = 'Breaking Bad';
seriesListElement.prepend(firstSeriesCloneElement);
console.log(firstSeriesCloneElement);

//Append an element on specific place before another child element
const thirdSeriesElement = document.createElement('li');
thirdSeriesElement.textContent = 'Top Boy';

seriesListElement.insertBefore(thirdSeriesElement, secondSeriesElement);

//Use before or after
const fourthSeriesElement = document.createElement('li');
fourthSeriesElement.textContent = 'Sunny Beach';
thirdSeriesElement.after(fourthSeriesElement); //or before