function setSolve(moviesInfo) {
    const movies = [];
    for (const movieInfo of moviesInfo) {
        if (movieInfo.startsWith('add')) {
            const movieName = movieInfo.split('addMovie ').pop();
            const movie = {
                name: movieName,
            }

            movies.push(movie);
        } else {
            if (movieInfo.includes('directedBy')) {
                const [movieName, directorName] = movieInfo.split(' directedBy ');
                let movie = movies.find(currentMovie => currentMovie.name === movieName);
                if (movie) {
                    movie.director = directorName;
                }
            } else if (movieInfo.includes('onDate')) {
                const [movieName, movieDate] = movieInfo.split(' onDate ');
                const movie = movies.find(currentMovie => currentMovie.name === movieName);
                if (movie) {
                    movie.date = movieDate;
                }
            }
        }
    }

    for (const movie of movies) {
        if (movie.director && movie.date) {
            const movieToJSON = JSON.stringify(movie);
            console.log(movieToJSON);
        }
    }
}

setSolve(['addMovie Fast and Furious', 'addMovie Godfather', 'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018', 'Fast and Furious onDate 30.07.2018', 'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen']);