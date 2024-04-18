function solve() {
    const allQuestionSections = document.querySelectorAll('section');
    const rightAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let correctAnsweredQuestions = 0;

    for (let i = 0; i < allQuestionSections.length; i++) {
        const answerTexts = allQuestionSections[i].querySelectorAll('.answer-text');

        for (const answerText of answerTexts) {
            answerText.addEventListener('click', (e) => {
                if (rightAnswers.includes(e.currentTarget.textContent)) {
                    correctAnsweredQuestions++;
                }

                if (i < allQuestionSections.length - 1) {
                    allQuestionSections[i].style.display = 'none';
                    allQuestionSections[i + 1].style.display = 'block';
                } else {
                    const resultsDivElement = document.getElementById('results');
                    const outputMessage = document.querySelector('#results h1');

                    allQuestionSections[i].style.display = 'none';
                    resultsDivElement.style.display = 'block';

                    if (correctAnsweredQuestions === allQuestionSections.length) {
                        outputMessage.textContent = 'You are recognized as top JavaScript fan!';
                    } else {
                        outputMessage.textContent = `You have ${correctAnsweredQuestions} right answers`;
                    }
                }
            });
        }
    }
}