function solve(studentsInfo) {
    class Grade {
        constructor() {
            this.students = [];
            this.sumOfAllScores = 0;
        }

        get averageScore() {
            return (this.sumOfAllScores / this.students.length).toFixed(2);
        }

        addStudent(student) {
            this.students.push(student.name);
            this.sumOfAllScores += student.averageScore;
        }

        printALLStudents() {
            return this.students.join(', ');
        }
    }

    let gradesWithStudents = {};
    ArrangeStudentsInNewGrades(studentsInfo, gradesWithStudents, Grade);

    PrintGradesWithItsStudents(gradesWithStudents);
}



function ArrangeStudentsInNewGrades(studentsInfo, gradesWithStudents, Grade) {
    for (const studentInfo of studentsInfo) {
        const name = studentInfo.slice(14, studentInfo.indexOf(','));
        let grade = studentInfo.match(/[0-9]+/);
        grade = Number(grade.shift());

        const studentInformation = studentInfo.split(': ');
        const averageScore = Number(studentInformation.pop());
        const student = {
            name,
            grade,
            averageScore,
        };

        if (student.averageScore >= 3) {
            grade++;
            if (!gradesWithStudents[grade]) {
                gradesWithStudents[grade] = new Grade();
            }

            gradesWithStudents[grade].addStudent(student);
        }
    }
}

function PrintGradesWithItsStudents(gradesWithStudents) {
    const sortedGrades = Object.entries(gradesWithStudents).sort((a, b) => a[0] - b[0]);
    gradesWithStudents = Object.fromEntries(sortedGrades);
    for (const grade in gradesWithStudents) {
        console.log(`${grade} Grade`);
        console.log(`List of students: ${gradesWithStudents[grade].printALLStudents()}`);
        console.log(`Average annual score from last year: ${gradesWithStudents[grade].averageScore}`);
        console.log();
    }
}

solve(["Student name: Mark, Grade: 8, Graduated with an average score: 4.75", "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
    "Student name: George, Grade: 8, Graduated with an average score: 2.83", "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
    "Student name: Joey, Grade: 9, Graduated with an average score: 4.90", "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
    "Student name: Bob, Grade: 11, Graduated with an average score: 5.15", "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
    "Student name: Bill, Grade: 9, Graduated with an average score: 6.00", "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
    "Student name: Peter, Grade: 11, Graduated with an average score: 4.88", "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"]);