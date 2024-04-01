function search() {
	const towns = document.querySelectorAll('#towns li');
	const townInput = document.getElementById('searchText').value;
	let totalMatchedTowns = 0;

	for (const town of Array.from(towns)) {
		if (town.textContent.includes(townInput)) {
			town.style.fontWeight = 'bold';
			town.style.textDecoration = 'underline';
			totalMatchedTowns++;
		} else {
			town.style.fontWeight = 'normal';
			town.style.textDecoration = 'none';
		}
	}

	const result = document.getElementById('result');
	result.textContent = `${totalMatchedTowns} matches found`;
	townInput.textContent = '';
}