function extractText() {
    const items = document.getElementById('items');
    const textAreaResult = document.getElementById('result');
    
    textAreaResult.value = items.textContent;
}