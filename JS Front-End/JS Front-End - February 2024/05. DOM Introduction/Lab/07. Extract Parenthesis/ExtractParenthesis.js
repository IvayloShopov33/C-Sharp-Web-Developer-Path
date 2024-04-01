function extract(content) {
    const result = [];
    const text = document.getElementById(content).textContent;
    const matches = text.matchAll(/\(([A-Za-z ]+)\)/g);

    for (const match of Array.from(matches)) {
        result.push(match[1]);
    }

    return result.join('; ');
}