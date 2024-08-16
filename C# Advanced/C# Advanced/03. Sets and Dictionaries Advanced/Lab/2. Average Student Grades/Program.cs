namespace _2._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsWithTheirGrades = new Dictionary<string, List<decimal>>();
            int studentsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= studentsCount; i++)
            {
                string[] studentDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string studentName = studentDetails[0];
                decimal studentGrade = decimal.Parse(studentDetails[1]);
                //check if the student is not in the dictionary
                if (!studentsWithTheirGrades.ContainsKey(studentName))
                {
                    //add the student to the dictionary
                    studentsWithTheirGrades.Add(studentName, new List<decimal>());
                }
                //add the grade to the student's list
                studentsWithTheirGrades[studentName].Add(studentGrade);
            }

            //print the student with his/her grades and his/her average grade
            foreach (var student in studentsWithTheirGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }
        }
    }
}