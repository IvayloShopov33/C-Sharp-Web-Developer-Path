function solve(employeesNames) {
    const employees = {};
    for (const employeeName of employeesNames) {
        const personalNumber = employeeName.length;
        employees[employeeName] = personalNumber;
    }

    for (const employee in employees) {
        console.log(`Name: ${employee} -- Personal Number: ${employees[employee]}`);
    }
}

function solveFancy(employeesNames) {
    employeesNames
        .map(name => ({ name, personalNumber: name.length, }))
        .forEach(employee => console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`));
}

solve(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
solve(['Samuel Jackson', 'Will Smith', 'Bruce Willis', 'Tom Holland']);

solveFancy(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
solveFancy(['Samuel Jackson', 'Will Smith', 'Bruce Willis', 'Tom Holland']);