function loadRepos() {
    fetch('https://api.github.com/users/testnakov/repos')
        .then(response => response.text())
        .then(data => {
            const divResult = document.getElementById('res');
            divResult.textContent = data;
        })
}