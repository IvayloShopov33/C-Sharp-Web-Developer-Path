const url = 'https://swapi.dev/api';

//Promise chaining
fetch(`${url}/people/4`)
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(error => console.log('Something went wrong'));

//Using server to get books
const booksURL = 'http://localhost:3030/jsonstore/books';

fetch(booksURL)
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(error => console.log('Something went wrong'));

//Create book
// fetch(booksURL, {
//     method: 'POST',
//     body: JSON.stringify({
//         title: 'Tobacco',
//         author: 'Dimitar Dimov',
//     })
// })
//     .then(response => response.json())
//     .then(data => console.log(data))
//     .catch(error => console.log('Something went wrong'));

//Delete book
// fetch(`${booksURL}/2d95f3a8-7964-4c9c-936d-ca2ad5f03125`, {
//     method: 'DELETE'
// })
//     .then(response => console.log(response))
//     .catch(error => console.log('Something went wrong'));

// fetch(`${booksURL}/e9dd398f-6619-401d-b3eb-a803d512ae75`, {
//     method: 'DELETE'
// })
//     .then(response => console.log(response))
//     .catch(error => console.log('Something went wrong'));