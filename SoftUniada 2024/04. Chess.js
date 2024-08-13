function solve(input) {
    const tableSize = Number(input.shift());
    let knightRow = Number(input.shift());
    let knightCol = Number(input.shift());
    const desiredRow = Number(input.shift());
    const desiredCol = Number(input.shift());

    const queueKnights = [{ row: knightRow, col: knightCol, moves: 0 }];
    const visitedFields = new Array(tableSize).fill(null).map(() => new Array(tableSize).fill(false));

    const directions = [
        { row: -2, col: -1 },
        { row: -2, col: 1 },
        { row: -1, col: -2 },
        { row: -1, col: 2 },
        { row: 1, col: -2 },
        { row: 1, col: 2 },
        { row: 2, col: -1 },
        { row: 2, col: 1 }
    ];

    while (queueKnights.length > 0) {
        const { row, col, moves } = queueKnights.shift();

        if (row === desiredRow && col === desiredCol) {
            console.log(moves);
            return;
        }

        for (const direction of directions) {
            const newRow = row + direction.row;
            const newCol = col + direction.col;

            if (isValidMove(newRow, newCol, tableSize) && !visitedFields[newRow][newCol]) {
                visitedFields[newRow][newCol] = true;
                queueKnights.push({ row: newRow, col: newCol, moves: moves + 1 });
            }
        }
    }

    function isValidMove(row, col, tableSize) {
        return row >= 0 && row < tableSize && col >= 0 && col < tableSize;
    }
}

solve(['6', '1', '3', '5', '0']);