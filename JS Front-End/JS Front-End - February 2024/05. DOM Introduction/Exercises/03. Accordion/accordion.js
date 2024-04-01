function toggle() {
	const buttonToChange = document.getElementsByClassName('button')[0];
	const textContent = document.querySelector('#extra');

	if (buttonToChange.textContent === 'More') {
		buttonToChange.textContent = 'Less';
		textContent.style.display = 'block';
	} else {
		buttonToChange.textContent = 'More';
		textContent.style.display = 'none';
	}
}