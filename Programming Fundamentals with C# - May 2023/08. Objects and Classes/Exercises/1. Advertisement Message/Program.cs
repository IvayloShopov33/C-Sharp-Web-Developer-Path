using System;

namespace _1._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {          
            string[] phrases = { "Excellent product.", "Such a great product.",
                "I always use that product.", "Best product of its category.", 
                "Exceptional product.", "I can't live without this product." };

            string[] events = { "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int randomSentencesCount = int.Parse(Console.ReadLine());
            Random randomElement = new Random();
            
            for (int i = 0; i < randomSentencesCount; i++)
            {
                int phraseIndex = randomElement.Next(phrases.Length);
                string phrase = phrases[phraseIndex];
                int eventIndex = randomElement.Next(events.Length);
                string newEvent = events[eventIndex];
                
                int authorIndex = randomElement.Next(authors.Length);
                string author = authors[authorIndex];
                int cityIndex = randomElement.Next(cities.Length);
                string city = cities[cityIndex];
                
                Console.WriteLine($"{phrase} {newEvent} {author} – {city}.");
            }
        }
    }
}
