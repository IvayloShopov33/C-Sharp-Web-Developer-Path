function solve() {
	let result = '';
	let textToModify = document.getElementById('text').value;
	const conventionType = document.getElementById('naming-convention').value;

	if (conventionType === 'Camel Case' || conventionType === 'Pascal Case') {
		textToModify = textToModify.toLowerCase().split(' ');
		let firstWord = textToModify.shift();

		if (conventionType === 'Pascal Case') {
			firstWord = firstWord[0].toUpperCase() + firstWord.substring(1);
		}

		result += firstWord;
		for (const word of textToModify) {
			const newWord = word[0].toUpperCase() + word.substring(1);
			result += newWord;
		}
	} else {
		result = 'Error!';
	}

	const output = document.getElementById('result');
	output.textContent = result;
}