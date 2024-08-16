namespace _5._Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> peopleWithTheirAge = new Dictionary<string, int>();
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= peopleCount; i++)
            {
                string[] personDetails = Console.ReadLine().Split(", ");
                string personName = personDetails[0];
                int personAge = int.Parse(personDetails[1]);
                peopleWithTheirAge.Add(personName, personAge);
            }

            string ageCondition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string outputFormat = Console.ReadLine();

            //function which filters the people in the dictionary by their age
            Func<KeyValuePair<string, int>, bool> ageFilter = people => true;
            if (ageCondition == "younger")
            {
                ageFilter = people => people.Value < ageThreshold;
            }
            else if (ageCondition == "older")
            {
                ageFilter = people => people.Value >= ageThreshold;
            }

            //remove the people which don't meet the requested age
            peopleWithTheirAge = peopleWithTheirAge.Where(ageFilter).ToDictionary(x => x.Key, x => x.Value);

            //print the people's details in an appropriate format
            Func<KeyValuePair<string, int>, string> printFunc = person => person.Key + " - " + person.Value;
            if (outputFormat == "name")
            {
                printFunc = person => person.Key;
            }
            else if (outputFormat == "age")
            {
                printFunc = person => person.Value.ToString();
            }

            var peopleAsString = peopleWithTheirAge.Select(printFunc);
            foreach (var person in peopleAsString)
            {
                Console.WriteLine(person);
            }
        }
    }
}