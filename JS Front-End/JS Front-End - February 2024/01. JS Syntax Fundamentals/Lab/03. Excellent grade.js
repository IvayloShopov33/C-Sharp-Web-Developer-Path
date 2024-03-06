function printGrade(grade) {
    if (grade >= 5.50 && grade <= 6) {
        console.log("Excellent");
    } else if (grade >= 4.50 && grade <= 5.49) {
        console.log("Very good");
    } else if (grade >= 3.50 && grade <= 4.49) {
        console.log("Good");
    } else if (grade >= 2.50 && grade <= 3.49) {
        console.log("Satisfactory");
    } else if (grade >= 2 && grade <= 2.49) {
        console.log("Poor");
    }
}