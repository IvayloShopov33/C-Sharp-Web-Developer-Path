function solve(input) {
    let articlesWithComments = {};
    const usernames = [];
    ArrangeArticlesWithTheirComments(input, articlesWithComments, usernames);

    const sortedArticles = Object.entries(articlesWithComments).sort((a, b) => b[1].comments.length - a[1].comments.length);
    articlesWithComments = Object.fromEntries(sortedArticles);
    PrintArticlesWithTheirComments(articlesWithComments);
}

function ArrangeArticlesWithTheirComments(input, articlesWithComments, usernames) {
    for (const line of input) {
        if (line.startsWith('article ')) {
            const article = line.slice(line.indexOf(' ') + 1);
            articlesWithComments[article] = {
                comments: [],
            };
        } else if (line.startsWith('user ')) {
            const username = line.slice(line.indexOf(' ') + 1);
            usernames.push(username);
        } else {
            const [username, commentInfo] = line.split(' posts on ');
            const [articleName, commentDetails] = commentInfo.split(': ');

            if (usernames.includes(username) && articlesWithComments[articleName]) {
                const [title, content] = commentDetails.split(', ');
                const comment = {
                    username,
                    title,
                    content,
                };

                articlesWithComments[articleName].comments.push(comment);
            }
        }
    }
}

function PrintArticlesWithTheirComments(articlesWithComments) {
    for (const article in articlesWithComments) {
        console.log(`Comments on ${article}`);
        for (const comment of articlesWithComments[article].comments.sort((a, b) => a.username.localeCompare(b.username))) {
            console.log(`--- From user ${comment.username}: ${comment.title} - ${comment.content}`);
        }
    }
}

solve(['user aUser123', 'someUser posts on someArticle: NoTitle, stupidComment',
    'article Books', 'article Movies', 'article Shopping', 'user someUser', 'user uSeR4',
    'user lastUser', 'uSeR4 posts on Books: I like books, I do really like them',
    'uSeR4 posts on Movies: I also like movies, I really do',
    'someUser posts on Shopping: title, I go shopping every day',
    'someUser posts on Movies: Like, I also like movies very much']);


solve(['user Mark', 'Mark posts on someArticle: NoTitle, stupidComment',
    'article Bobby', 'article Steven', 'user Liam',
    'user Henry', 'Mark posts on Bobby: Is, I do really like them',
    'Mark posts on Steven: title, Run', 'someUser posts on Movies: Like']);