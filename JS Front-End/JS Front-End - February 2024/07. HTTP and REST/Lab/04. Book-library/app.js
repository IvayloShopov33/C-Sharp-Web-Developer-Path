function attachEvents() {
    const inputBookDetails = document.querySelectorAll('#form input[type=text]');
    const booksTableBody = document.querySelector('table tbody');
    const submitButtonElement = document.querySelector('#form button');
    const baseURL = 'http://localhost:3030/jsonstore/collections/books';

    const title = inputBookDetails[0];
    const author = inputBookDetails[1];

    submitButtonElement.addEventListener('click', () => {
        fetch(baseURL, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                author: author.value,
                title: title.value,
            }),
        })
            .then(response => response.json())
            .then(book => {
                const newBookElement = createBookElement(book.title, book.author, book._id);
                booksTableBody.appendChild(newBookElement);

                title.value = '';
                author.value = '';
            });
    });

    const loadBooksButton = document.getElementById('loadBooks');
    loadBooksButton.addEventListener('click', () => {
        fetch(baseURL)
            .then(response => response.json())
            .then(books => {
                booksTableBody.textContent = '';
                const booksFragment = document.createDocumentFragment();
                for (const book in books) {
                    const newBookElement = createBookElement(books[book].title, books[book].author, book);
                    booksFragment.appendChild(newBookElement);
                }

                booksTableBody.appendChild(booksFragment);
            });
    });

    function createBookElement(bookTitle, bookAuthor, bookId) {
        const newBookElement = document.createElement('tr');

        const bookTitleData = document.createElement('td');
        bookTitleData.textContent = bookTitle;
        newBookElement.appendChild(bookTitleData);

        const bookAuthorData = document.createElement('td');
        bookAuthorData.textContent = bookAuthor;
        newBookElement.appendChild(bookAuthorData);

        const actionButtonsData = document.createElement('td');
        const editButtonElement = document.createElement('button');
        editButtonElement.textContent = 'Edit';
        editButtonElement.addEventListener('click', () => {
            title.value = bookTitle;
            author.value = bookAuthor;
            submitButtonElement.textContent = 'Save';

            submitButtonElement.addEventListener('click', () => {
                fetch(`${baseURL}/${bookId}`, {
                    method: 'PUT',
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify({
                        author: author.value,
                        title: title.value,
                        _id: bookId,
                    }),
                })
                    .then(response => response.json())
                    .then(() => {
                        newBookElement.remove();

                        title.value = '';
                        author.value = '';
                        submitButtonElement.textContent = 'Submit';

                    });
            });
        });

        const deleteButtonElement = document.createElement('button');
        deleteButtonElement.textContent = 'Delete';
        deleteButtonElement.addEventListener('click', () => {
            fetch(`${baseURL}/${bookId}`, {
                method: 'DELETE',
            })
                .then(() => newBookElement.remove());
        });

        actionButtonsData.appendChild(editButtonElement);
        actionButtonsData.appendChild(deleteButtonElement);

        newBookElement.appendChild(actionButtonsData);

        return newBookElement;
    }
}

attachEvents();