window.addEventListener("load", solve);

function solve() {
    const playerNameInput = document.getElementById('player');
    const playerScoreInput = document.getElementById('score');
    const playerRoundInput = document.getElementById('round');
    const playerListUlElement = document.getElementById('sure-list');
    const scoreboardListUlElement = document.getElementById('scoreboard-list');

    const addPlayerButton = document.getElementById('add-btn');
    addPlayerButton.addEventListener('click', () => {
        if (!playerNameInput.value || !playerScoreInput.value || !playerRoundInput.value) {
            return;
        }

        const newLiElement = document.createElement('li');
        newLiElement.classList.add('dart-item');
        const newArticleElement = document.createElement('article');

        const playerNameParagraph = document.createElement('p');
        playerNameParagraph.textContent = playerNameInput.value;
        newArticleElement.appendChild(playerNameParagraph);

        const playerScoreParagraph = document.createElement('p');
        playerScoreParagraph.textContent = `Score: ${playerScoreInput.value}`;
        newArticleElement.appendChild(playerScoreParagraph);

        const playerRoundParagraph = document.createElement('p');
        playerRoundParagraph.textContent = `Round: ${playerRoundInput.value}`;
        newArticleElement.appendChild(playerRoundParagraph);

        newLiElement.appendChild(newArticleElement);

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add(...['btn', 'edit']);
        editButtonElement.textContent = 'edit';

        editButtonElement.addEventListener('click', () => {
            playerNameInput.value = playerNameParagraph.textContent;
            playerScoreInput.value = playerScoreParagraph.textContent.split(': ').pop();
            playerRoundInput.value = playerRoundParagraph.textContent.split(': ').pop();

            newLiElement.remove();
            addPlayerButton.removeAttribute('disabled');
        });

        const okButtonElement = document.createElement('button');
        okButtonElement.classList.add(...['btn', 'ok']);
        okButtonElement.textContent = 'ok';

        okButtonElement.addEventListener('click', () => {
            editButtonElement.remove();
            okButtonElement.remove();

            const clearButtonElement = document.querySelector('.clear');

            clearButtonElement.addEventListener('click', () => {
                location.reload();
            });

            newLiElement.remove();
            scoreboardListUlElement.appendChild(newLiElement);
            addPlayerButton.removeAttribute('disabled');
        });

        newLiElement.appendChild(editButtonElement);
        newLiElement.appendChild(okButtonElement);

        playerListUlElement.appendChild(newLiElement);

        playerNameInput.value = '';
        playerScoreInput.value = '';
        playerRoundInput.value = '';
        addPlayerButton.setAttribute('disabled', 'disabled');
    });
}