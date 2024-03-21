function solve(input) {
    const shelvesWithBooks = {};
    ArrangeBooksInShelves(input, shelvesWithBooks);

    const sortedShelves = Object.entries(shelvesWithBooks).sort((a, b) => b[1].books.length - a[1].books.length);
    PrintShelvesAndBooksDetails(sortedShelves);
}

function ArrangeBooksInShelves(input, shelvesWithBooks) {
    for (const line of input) {
        if (line.includes('->')) {
            const [shelfId, genre] = line.split(' -> ');
            if (!shelvesWithBooks[shelfId]) {
                const shelf = {
                    genre,
                    books: [],
                };

                shelvesWithBooks[shelfId] = shelf;
            }
        } else if (line.includes(':')) {
            const [title, bookFurtherDetails] = line.split(': ');
            const [author, genre] = bookFurtherDetails.split(', ');
            const selectedShelf = Object.values(shelvesWithBooks)
                .find(shelf => shelf.genre === genre);

            if (selectedShelf) {
                const book = {
                    author,
                    title,
                };

                selectedShelf.books.push(book);
            }
        }
    }
}

function PrintShelvesAndBooksDetails(sortedShelves) {
    for (const shelf of sortedShelves) {
        console.log(`${shelf[0]} ${shelf[1].genre}: ${shelf[1].books.length}`);
        for (const book of shelf[1].books) {
            console.log(`--> ${book.title}: ${book.author}`);
        }
    }
}

solve(['1 -> history', '1 -> action', 'Deathin Time: Criss Bell, mystery', '2 -> mystery', '3 -> sci-fi',
    'Child of Silver: Bruce Rich, mystery', 'Hurting Secrets: Dustin Bolt, action',
    'Future of Dawn: Aiden Rose, sci-fi', 'Lions and Rats: Gabe Roads, history',
    '2 -> romance', 'Effect of the Void: Shay B, romance', 'Losing Dreams: Gail Starr, sci-fi',
    'Name of Earth: Jo Bell, sci-fi', 'Pilots of Stone: Brook Jay, history']);

solve(['1 -> mystery', '2 -> sci-fi', 'Child of Silver: Bruce Rich, mystery',
    'Lions and Rats: Gabe Roads, history', 'Effect of the Void: Shay B, romance',
    'Losing Dreams: Gail Starr, sci-fi', 'Name of Earth: Jo Bell, sci-fi']);