function loadRepos() {
	const reposUlElement = document.getElementById('repos');
	const usernameInput = document.getElementById('username');

	fetch(`https://api.github.com/users/${usernameInput.value}/repos`)
		.then(response => response.json())
		.then(repos => {
			reposUlElement.textContent = '';
			const reposLiElementsFragment = document.createDocumentFragment();
			for (const repo of repos) {
				const repoLiElement = document.createElement('li');

				const repoLink = document.createElement('a');
				repoLink.href = repo.html_url;
				repoLink.target = '_blank';
				repoLink.textContent = repo.full_name;

				repoLiElement.appendChild(repoLink);
				reposLiElementsFragment.appendChild(repoLiElement);
			}

			reposUlElement.appendChild(reposLiElementsFragment);
			usernameInput.value = '';
		})
		.catch(() => reposUlElement.textContent = 'Invalid username!');
}