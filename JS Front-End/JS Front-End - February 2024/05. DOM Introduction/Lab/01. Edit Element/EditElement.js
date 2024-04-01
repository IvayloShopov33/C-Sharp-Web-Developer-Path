function editElement(element, match, replacer) {
    while (element.textContent.includes(match)) {
        element.textContent = element.textContent.replace(match, replacer);
    }

    //Solve with Regular Expression
    //element.textContent = element.textContent.replace(new RegExp(match, 'g'), replacer);

    //Solve with ReplaceAll method
    //element.textContent = element.textContent.replaceAll(match, replacer);
}