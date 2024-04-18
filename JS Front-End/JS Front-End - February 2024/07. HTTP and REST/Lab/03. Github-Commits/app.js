function loadCommits() {
    const usernameInput = document.getElementById('username');
    const repositoryInput = document.getElementById('repo');
    const commitsUlElement = document.getElementById('commits');

    fetch(`https://api.github.com/repos/${usernameInput.value}/${repositoryInput.value}/commits`)
        .then(response => response.json())
        .then(commits => {
            commitsUlElement.textContent = '';
            const commitsFragment = document.createDocumentFragment();

            for (const commit of commits) {
                const commitAuthor = commit.commit.author.name;
                const commitMessage = commit.commit.message;

                const commitLiElement = document.createElement('li');
                commitLiElement.textContent = `${commitAuthor}: ${commitMessage}`;

                commitsFragment.appendChild(commitLiElement);
            }

            commitsUlElement.appendChild(commitsFragment);
            usernameInput.value = '';
            repositoryInput.value = '';
        })
        .catch(() => {
            commitsUlElement.textContent = '';

            const errorLiElement = document.createElement('li');
            errorLiElement.textContent = `Error: 404 (Not Found)`;

            commitsUlElement.appendChild(errorLiElement);
            usernameInput.value = '';
            repositoryInput.value = '';
        });
}