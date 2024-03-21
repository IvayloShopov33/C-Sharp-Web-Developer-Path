function solve(townsDetails) {
    for (const townDetails of townsDetails) {
        const [town, latitude, longitude] = townDetails.split(' | ');
        const townCoordinates = {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        };

        console.log(townCoordinates);
    }
}

function solveFancy(townDetails) {
    townDetails
        .map(row => row.split(' | '))
        .map(([town, latitude, longitude]) => ({
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        }))
        .forEach(town => console.log(town));
}

solve(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
solve(['Plovdiv | 136.45 | 812.575']);

solveFancy(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
solveFancy(['Plovdiv | 136.45 | 812.575']);