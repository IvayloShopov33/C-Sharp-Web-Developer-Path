namespace _8._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsWithPasswords = new Dictionary<string, string>();
            string[] contests = Console.ReadLine().Split(':');

            while (contests[0] != "end of contests")
            {
                string contest = contests[0];

                // check if the contest is not present in the dictionary
                if (!contestsWithPasswords.ContainsKey(contest))
                {
                    string password = contests[1];
                    // add the contest with his password to the dictionary
                    contestsWithPasswords.Add(contest, password);
                }
                
                contests = Console.ReadLine().Split(':');
            }

            SortedDictionary<string, Dictionary<string, int>> candidatesPoints =
                new SortedDictionary<string, Dictionary<string, int>>();
            string[] contestsWithUsernamesAndPoints = Console.ReadLine().Split("=>");

            while (contestsWithUsernamesAndPoints[0] != "end of submissions")
            {
                string contest = contestsWithUsernamesAndPoints[0];
                string password = contestsWithUsernamesAndPoints[1];
                
                // check if the contest and the password are valid
                if (contestsWithPasswords.ContainsKey(contest) && contestsWithPasswords[contest] == password)
                {
                    string username = contestsWithUsernamesAndPoints[2];
                    int points = int.Parse(contestsWithUsernamesAndPoints[3]);
                    
                    // check if the username is not present in the dictionary || check if the username is present, but the contest is not || check if the new points are more than the older ones
                    if (!candidatesPoints.ContainsKey(username))
                    {
                        // add the username with his points to the dictionary
                        candidatesPoints.Add(username, new Dictionary<string, int>());
                        candidatesPoints[username].Add(contest, points);
                    }
                    else if (candidatesPoints.ContainsKey(username) && !candidatesPoints[username].ContainsKey(contest))
                    {
                        // add the contest with the points to the dictionary
                        candidatesPoints[username].Add(contest, points);
                    }
                    else if (candidatesPoints[username][contest] < points)
                    {
                        candidatesPoints[username][contest] = points;
                    }
                }
                
                contestsWithUsernamesAndPoints = Console.ReadLine().Split("=>");
            }

            int maxPoints = 0;
            string topStudent = string.Empty;

            foreach (var student in candidatesPoints)
            {
                // check if the current sum is the bigger than the current maximum sum
                if (student.Value.Values.Sum() > maxPoints)
                {
                    maxPoints = student.Value.Values.Sum();
                    topStudent = student.Key;
                }
            }

            // print the top student with his total points and the ranking of all students with their contest and points
            Console.WriteLine($"Best candidate is {topStudent} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in candidatesPoints)
            {
                Console.WriteLine(student.Key);
                foreach (var contestAndPoints in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestAndPoints.Key} -> {contestAndPoints.Value}");
                }
            }
        }
    }
}