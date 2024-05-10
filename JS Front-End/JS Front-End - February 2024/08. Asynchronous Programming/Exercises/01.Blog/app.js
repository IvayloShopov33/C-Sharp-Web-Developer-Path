function attachEvents() {
    const loadPostsButton = document.getElementById('btnLoadPosts');
    const postsSelectElement = document.getElementById('posts');
    const baseURL = 'http://localhost:3030/jsonstore/blog';
    const allPosts = [];

    loadPostsButton.addEventListener('click', () => {
        fetch(`${baseURL}/posts`)
            .then(response => response.json())
            .then(posts => {
                const postsOptionsFragment = document.createDocumentFragment();
                for (const post in posts) {
                    const newPostOption = document.createElement('option');
                    newPostOption.value = posts[post]._id;
                    newPostOption.textContent = posts[post].title;

                    allPosts.push(posts[post]);
                    postsOptionsFragment.appendChild(newPostOption);
                }

                postsSelectElement.appendChild(postsOptionsFragment);
            });
    });

    const viewPostsWithCommentsButton = document.getElementById('btnViewPost');
    viewPostsWithCommentsButton.addEventListener('click', () => {
        const commentsUlElement = document.getElementById('post-comments');
        Array.from(commentsUlElement.querySelectorAll('li')).forEach(el => el.remove());

        const selectedPost = postsSelectElement.options[postsSelectElement.selectedIndex];
        const postToDisplay = allPosts.find(post => post.title === selectedPost.textContent);

        const postH1Title = document.getElementById('post-title');
        postH1Title.textContent = postToDisplay.title;

        const postBodyElement = document.getElementById('post-body');
        postBodyElement.textContent = postToDisplay.body;

        fetch(`${baseURL}/comments`)
            .then(response => response.json())
            .then(comments => {
                const commentsValues = Object.values(comments);
                const correctComments = commentsValues.filter(comment => comment.postId === postToDisplay.id);
                const commentsFragment = document.createDocumentFragment();

                for (const comment of correctComments) {
                    const newCommentLiElement = document.createElement('li');
                    newCommentLiElement.id = comment.id;
                    newCommentLiElement.textContent = comment.text;

                    commentsFragment.appendChild(newCommentLiElement);
                }

                commentsUlElement.appendChild(commentsFragment);
            });
    })
}

attachEvents();