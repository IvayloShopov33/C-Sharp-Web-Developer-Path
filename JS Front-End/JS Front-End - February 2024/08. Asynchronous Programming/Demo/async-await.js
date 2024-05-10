//Create a function that returns a promise
function calculateMeaningsOfLife() {
    const result = new Promise((resolve, reject)=> {
        setTimeout(()=> {
            resolve(42);
        }, 4000);
    });

    return result;
}

//Async function
async function solve() {
    const meaningsOfLife = await calculateMeaningsOfLife();

    console.log(meaningsOfLife);
}

solve();