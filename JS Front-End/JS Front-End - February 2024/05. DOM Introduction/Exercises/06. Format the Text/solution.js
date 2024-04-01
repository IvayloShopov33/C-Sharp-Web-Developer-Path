function solve() {
	let textAreaInput = document.getElementById('input').value;
	textAreaInput = textAreaInput.split('.').filter(sentence => sentence.length >= 1);

	const outputField = document.getElementById('output');
	outputField.textContent = '';

	let sentencesCount = 0;
	let paragraph = '';

	addSentencesToParagraphs();

	function addSentencesToParagraphs() {
		for (const sentence of textAreaInput) {
			if (sentencesCount % 3 === 0) {
				if (sentencesCount > 0) {
					outputField.appendChild(paragraph);
				}

				paragraph = document.createElement('p');
			}

			paragraph.textContent += `${sentence}.`;
			sentencesCount++;
		}

		outputField.appendChild(paragraph);
	}
}