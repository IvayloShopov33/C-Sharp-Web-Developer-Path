function solve() {
	document.querySelector('#searchBtn').addEventListener('click', onClick);

	function onClick() {
		const input = document.getElementById('searchField');
		let tableRows = document.querySelectorAll('table tbody tr');
		tableRows = [...tableRows];

		for (const row of tableRows) {
			if (row.classList.contains('select')) {
				row.classList.remove('select');
			}

			if (row.textContent.includes(input.value) && input.value) {
				row.classList.add('select');
			}
		}

		input.value = '';
	}
}