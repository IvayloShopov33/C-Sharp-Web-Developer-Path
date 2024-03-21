function solve(input) {
    const coursesWithStudents = {};
    ArrangeStudentsInCourses(input, coursesWithStudents);

    const sortedCourses = Object.entries(coursesWithStudents).sort((a, b) => b[1].students.length - a[1].students.length);
    PrintCoursesWithTheirStudents(sortedCourses);
}

function ArrangeStudentsInCourses(input, coursesWithStudents) {
    for (const line of input) {
        if (line.includes(':')) {
            const [courseName, capacity] = line.split(': ');
            if (!coursesWithStudents[courseName]) {
                coursesWithStudents[courseName] = {
                    capacity: Number(capacity),
                    students: [],
                };
            } else {
                coursesWithStudents[courseName].capacity += Number(capacity);
            }
        } else {
            const [userDetails, userEmailAndDesiredCourse] = line.split('] with email ');
            const [username, credits] = userDetails.split('[');
            const [email, courseName] = userEmailAndDesiredCourse.split(' joins ');

            if (coursesWithStudents[courseName] && coursesWithStudents[courseName].capacity > 0) {
                const student = {
                    username,
                    credits: Number(credits),
                    email,
                };

                coursesWithStudents[courseName].students.push(student);
                coursesWithStudents[courseName].capacity--;
            }
        }
    }
}

function PrintCoursesWithTheirStudents(sortedCourses) {
    for (const course of sortedCourses) {
        console.log(`${course[0]}: ${course[1].capacity} places left`);
        for (const student of course[1].students.sort((a, b) => b.credits - a.credits)) {
            console.log(`--- ${student.credits}: ${student.username}, ${student.email}`);
        }
    }
}

solve(['JavaBasics: 2', 'user1[25] with email user1@user.com joins C#Basics', 'C#Advanced: 3',
    'JSCore: 4', 'user2[30] with email user2@user.com joins C#Basics',
    'user13[50] with email user13@user.com joins JSCore',
    'user1[25] with email user1@user.com joins JSCore',
    'user8[18] with email user8@user.com joins C#Advanced',
    'user6[85] with email user6@user.com joins JSCore', 'JSCore: 2',
    'user11[3] with email user11@user.com joins JavaBasics',
    'user45[105] with email user45@user.com joins JSCore',
    'user007[20] with email user007@user.com joins JSCore',
    'user700[29] with email user700@user.com joins JSCore',
    'user900[88] with email user900@user.com joins JSCore']);

solve(['JavaBasics: 15', 'user1[26] with email user1@user.com joins JavaBasics',
    'user2[36] with email user11@user.com joins JavaBasics',
    'JavaBasics: 5', 'C#Advanced: 5',
    'user1[26] with email user1@user.com joins C#Advanced',
    'user2[36] with email user11@user.com joins C#Advanced',
    'user3[6] with email user3@user.com joins C#Advanced',
    'C#Advanced: 1', 'JSCore: 8',
    'user23[62] with email user23@user.com joins JSCore']);