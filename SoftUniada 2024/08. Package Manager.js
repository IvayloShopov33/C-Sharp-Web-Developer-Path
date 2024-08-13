function solve(input) {
    const packagesCount = input.shift();
    const bondsCount = input.shift();
    const packages = {};
    let startPackage = 0;

    for (let i = 0; i < bondsCount; i++) {
        const [x, y] = input.shift().split(' ');
        if (!packages[x]) {
            packages[x] = [];
        }

        packages[x].push(y);

        for (const package of packages[x]) {
            if (packages[package] && packages[package].includes(x)) {
                console.log('circular dependency');
                return;
            }
        }
    }
}

solve(['7',
'5',
'4 1',
'5 6',
'3 0',
'4 3',
'1 2']);

solve(['2',
'2',
'0 1',
'1 0']);