const seriesListElement = document.getElementById('series');

const liveElementsCollection = seriesListElement.children; //HTML Collection - always live collection
const liveNodeList = seriesListElement.childNodes; //Node List - live
const staticNodeList = seriesListElement.querySelectorAll('#series li');

//Before the change
console.log(liveElementsCollection);
console.log(liveNodeList);
console.log(staticNodeList);
console.log('---------');

setTimeout(() => {
    const seriesLiNewElement = document.createElement('li');
    seriesLiNewElement.textContent = 'Hawaii 5-0';
    seriesListElement.appendChild(seriesLiNewElement);

    //After the change
    console.log(liveElementsCollection);
    console.log(liveNodeList);
    console.log(staticNodeList);
}, 2500);