console.log('Hello from external JS!');
const textInputElement = document.getElementById('username');
console.log(textInputElement);

setTimeout(() => {
    textInputElement.value = 'Shopov';
}, 1500);

const fancyInputElements = document.getElementsByClassName('fancy-input');
console.log(fancyInputElements);

//Get first input type text
const firstInputTextElement = document.querySelector('input[type=text]');
console.log(firstInputTextElement);

//Get all input type text elements
const textInputElements = document.querySelectorAll('input');
console.log(textInputElements);

//NodeList vs HTMLCollecttion
const contentStaticNodeList = document.querySelectorAll('#content > *');
console.log(contentStaticNodeList);

const contentElement = document.querySelector('#content');
const contentLiveNodeList = contentElement.childNodes;
console.log(contentLiveNodeList); // print node list with more than 2 elements (takes all nodes - html elements, text without tags, comments, etc.)

const contentLiveHTMLCollection = contentElement.children;
console.log(contentLiveHTMLCollection); //print HTML collection with only 2 elements

//Iterate collections
for (const htmlElement of contentLiveHTMLCollection) {
    console.log(htmlElement);
}

for (const nodeElement of contentLiveNodeList) {
    console.log(nodeElement);
}

//Use forEach for NodeList
contentLiveNodeList.forEach(nodeElement => console.log(nodeElement));

//Convert HTMLCollection to an array
const htmlElementsArray = Array.from(contentLiveHTMLCollection);
//const htmlElementsArray = [...contentLiveHTMLCollection];
console.log(htmlElementsArray);

//Convert NodeList to an array
const htmlNodesArray = Array.from(contentLiveNodeList);
//const htmlNodesArray = [...contentLiveNodeList];
console.log(htmlNodesArray);