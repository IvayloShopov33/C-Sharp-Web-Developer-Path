namespace _9._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languagesWithSubmissions = new Dictionary<string, int>();
            Dictionary<string, int> studentsWithPoints = new Dictionary<string, int>();
            string[] commands;
            while (true)
            {
                commands = Console.ReadLine().Split('-');
                
                //check if the command is "exam finished" which means that the program should stop working
                if (commands[0] == "exam finished")
                {
                    //print the students results and language submissions, both sorted by descending value and then by ascending name (key)
                    Console.WriteLine("Results:");
                    foreach (var student in studentsWithPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine($"{student.Key} | {student.Value}");
                    }

                    Console.WriteLine("Submissions:");
                    foreach (var language in languagesWithSubmissions.OrderByDescending(y => y.Value).ThenBy(y => y.Key))
                    {
                        Console.WriteLine($"{language.Key} - {language.Value}");
                    }
                    
                    break;
                }

                //check if the command is to add a student's result
                if (commands.Length == 3)
                {
                    string student = commands[0];
                    string language = commands[1];
                    int points = int.Parse(commands[2]);
                    
                    //check if the student is not present in the dictionary
                    if (!studentsWithPoints.ContainsKey(student))
                    {
                        //add the student with his/her points to the dictionary
                        studentsWithPoints.Add(student, points);
                    }
                    else
                    {
                        //check if the student's current result is more than the previous result
                        if (studentsWithPoints[student] < points)
                        {
                            studentsWithPoints[student] = points;
                        }
                    }

                    //check if the language is not present in the dictionary
                    if (!languagesWithSubmissions.ContainsKey(language))
                    {
                        //add the language to the dictionary
                        languagesWithSubmissions.Add(language, 0);
                    }

                    //increase ist value
                    languagesWithSubmissions[language]++;
                }
                else if (commands[1] == "banned")
                {
                    //remove the student who cheated on the exam
                    string studentCheater = commands[0];
                    studentsWithPoints.Remove(studentCheater);
                }
            }
        }
    }
}
