namespace _5._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> citiesByCountryAndContinent =
                new Dictionary<string, Dictionary<string, List<string>>>();
            int inputLinesCount = int.Parse(Console.ReadLine());
            string[] continentsDetails;
            string continent = string.Empty;
            string country = string.Empty;
            string city = string.Empty;
            for (int i = 1; i <= inputLinesCount; i++)
            {
                continentsDetails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                continent = continentsDetails[0];
                country = continentsDetails[1];
                city = continentsDetails[2];

                //check if the continent is not in the dictionary
                if (!citiesByCountryAndContinent.ContainsKey(continent))
                {
                    //add the continent and the country to the dictionary
                    citiesByCountryAndContinent.Add(continent, new Dictionary<string, List<string>>());
                }

                //check if the country is not present in the dictionary
                if (!citiesByCountryAndContinent[continent].ContainsKey(country))
                {
                    //add the country to the dictionary
                    citiesByCountryAndContinent[continent].Add(country, new List<string>());
                }

                //add the city to the dictionary
                citiesByCountryAndContinent[continent][country].Add(city);
            }

            //print the continents with their countries and cities
            foreach (var item in citiesByCountryAndContinent)
            {
                Console.WriteLine(item.Key + ":");
                foreach (var countryWithCities in item.Value)
                {
                    Console.WriteLine(countryWithCities.Key + " -> " + string.Join(", ", countryWithCities.Value));
                }
            }
        }
    }
}