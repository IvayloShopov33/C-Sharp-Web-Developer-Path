function create(words) {
	const divElementsFragment = document.createDocumentFragment();
	for (const word of words) {
		const newParagraphElement = document.createElement('p');
		newParagraphElement.textContent = word;
		newParagraphElement.style.display = 'none';

		const newDivElement = document.createElement('div');
		newDivElement.appendChild(newParagraphElement);
		divElementsFragment.appendChild(newDivElement);
	}

	const contentDivElement = document.getElementById('content');
	contentDivElement.appendChild(divElementsFragment);

	//Event Delegation
	contentDivElement.addEventListener('click', (e) => {
		if (e.target.tagName === 'DIV') {
			const paragraphElement = e.target.querySelector('p');

			if (paragraphElement.style.display === 'none') {
				paragraphElement.style.display = 'block';
			} else {
				paragraphElement.style.display = 'none';
			}
		}
	});
}