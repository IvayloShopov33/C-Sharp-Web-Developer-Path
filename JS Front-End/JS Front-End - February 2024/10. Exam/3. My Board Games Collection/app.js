function solve() {
    const baseURL = 'http://localhost:3030/jsonstore/games';
    const gamesUlElement = document.getElementById('games-list');
    const loadGamesButton = document.getElementById('load-games');
    const editGameButton = document.getElementById('edit-game');

    loadGamesButton.addEventListener('click', () => {
        loadAllGames();
    });

    const gameNameInput = document.getElementById('g-name');
    const gameTypeInput = document.getElementById('type');
    const gameMaxPlayersInput = document.getElementById('players');
    const addGameButton = document.getElementById('add-game');

    addGameButton.addEventListener('click', () => {
        fetch(baseURL, {
            method: 'POST',
            body: JSON.stringify({
                name: gameNameInput.value,
                type: gameTypeInput.value,
                players: gameMaxPlayersInput.value,
            }),
        })
            .then(() => {
                loadAllGames();
            });

        gameNameInput.value = '';
        gameTypeInput.value = '';
        gameMaxPlayersInput.value = '';
    });

    function loadAllGames() {
        fetch(baseURL)
            .then(response => response.json())
            .then(games => {
                gamesUlElement.textContent = '';
                editGameButton.setAttribute('disabled', 'disabled');
                const gamesFragment = document.createDocumentFragment();
                for (const game in games) {
                    const gameDiv = createNewGameDiv(games, game);
                    gamesFragment.appendChild(gameDiv);
                }

                gamesUlElement.appendChild(gamesFragment);
            });
    }

    function createNewGameDiv(games, game) {
        const gameDiv = document.createElement('div');
        gameDiv.classList.add('board-game');

        const contentDiv = document.createElement('div');
        contentDiv.classList.add('content');

        const gameNameParagraph = document.createElement('p');
        gameNameParagraph.textContent = games[game].name;
        contentDiv.appendChild(gameNameParagraph);

        const gameTypeParagraph = document.createElement('p');
        gameTypeParagraph.textContent = games[game].type;
        contentDiv.appendChild(gameTypeParagraph);

        const gameMaxPlayersParagraph = document.createElement('p');
        gameMaxPlayersParagraph.textContent = games[game].players;
        contentDiv.appendChild(gameMaxPlayersParagraph);

        const buttonsContainer = document.createElement('div');
        buttonsContainer.classList.add('buttons-container');

        const changeButton = document.createElement('button');
        changeButton.classList.add('change-btn');
        changeButton.textContent = 'Change';

        changeButton.addEventListener('click', () => {
            gameNameInput.value = gameNameParagraph.textContent;
            gameTypeInput.value = gameTypeParagraph.textContent;
            gameMaxPlayersInput.value = gameMaxPlayersParagraph.textContent;

            editGameButton.removeAttribute('disabled');
            addGameButton.setAttribute('disabled', 'disabled');

            editGameButton.addEventListener('click', () => {
                fetch(`${baseURL}/${games[game]._id}`, {
                    method: 'PUT',
                    headers: {
                        'content-type': 'application/json',
                    },
                    body: JSON.stringify({
                        name: gameNameInput.value,
                        type: gameTypeInput.value,
                        players: gameMaxPlayersInput.value,
                        _id: game,
                    }),
                })
                    .then(() => {
                        loadAllGames();
                    });

                editGameButton.setAttribute('disabled', 'disabled');
                addGameButton.removeAttribute('disabled');
                gameNameInput.value = '';
                gameTypeInput.value = '';
                gameMaxPlayersInput.value = '';
            })
        })

        const deleteButton = document.createElement('button');
        deleteButton.classList.add('delete-btn');
        deleteButton.textContent = 'Delete';

        deleteButton.addEventListener('click', () => {
            fetch(`${baseURL}/${games[game]._id}`, {
                method: 'DELETE',
            })
                .then(() => loadAllGames());
        })

        buttonsContainer.appendChild(changeButton);
        buttonsContainer.appendChild(deleteButton);

        gameDiv.appendChild(contentDiv);
        gameDiv.appendChild(buttonsContainer);

        return gameDiv;
    }
}

solve();