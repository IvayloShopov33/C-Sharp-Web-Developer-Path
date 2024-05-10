function solution() {
    const mainSection = document.getElementById('main');

    fetch('http://localhost:3030/jsonstore/advanced/articles/list')
        .then(response => response.json())
        .then(articles => {
            const articlesFragment = document.createDocumentFragment();
            for (const article of articles) {
                const articleDivElement = document.createElement('div');
                articleDivElement.classList.add('accordion');

                const articleHead = document.createElement('div');
                articleHead.classList.add('head');

                const spanTitle = document.createElement('span');
                spanTitle.textContent = article.title;

                const extraDetailsDiv = document.createElement('div');
                extraDetailsDiv.classList.add('extra');
                const extraDetailsParagraph = document.createElement('p');

                const buttonMore = document.createElement('button');
                buttonMore.classList.add('button');
                buttonMore.id = article._id;
                buttonMore.textContent = 'More';
                buttonMore.addEventListener('click', () => {
                    if (buttonMore.textContent === 'More') {
                        extraDetailsDiv.style.display = 'block';
                        buttonMore.textContent = 'Less';
                    } else {
                        extraDetailsDiv.style.display = 'none';
                        buttonMore.textContent = 'More';
                    }
                });

                articleHead.appendChild(spanTitle);
                articleHead.appendChild(buttonMore);
                articleDivElement.appendChild(articleHead);

                extraDetailsDiv.appendChild(extraDetailsParagraph);
                articleDivElement.appendChild(extraDetailsDiv);

                articlesFragment.appendChild(articleDivElement);
            }

            mainSection.appendChild(articlesFragment);
        });

    mainSection.addEventListener('click', (e) => {
        if (e.target.tagName === 'BUTTON') {
            const extraDetailsId = e.target.id;
            fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${extraDetailsId}`)
                .then(response => response.json())
                .then(data => {
                    const articleDivElement = document.getElementById(`${extraDetailsId}`).parentElement.parentElement;
                    const extraDetailsParagraph = articleDivElement.querySelector('.extra p');
                    extraDetailsParagraph.textContent = data.content;
                });
        }
    })
}

solution();