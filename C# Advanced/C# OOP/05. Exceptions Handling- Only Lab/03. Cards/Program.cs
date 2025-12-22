using System.Text;

namespace Cards
{
    public class Card
    {
        private string cardFace;
        private char cardSuit;

        public Card(string cardFace, char cardSuit)
        {
            this.cardFace = cardFace;
            this.cardSuit = cardSuit;
        }

        public static Card CreateCard(List<string> cardFaces, List<char> cardSuits, string cardFace, char cardSuit)
        {
            if (!cardFaces.Contains(cardFace))
            {
                throw new ArgumentException("Invalid card!");
            }

            if (!cardSuits.Contains(cardSuit))
            {
                throw new ArgumentException("Invalid card!");
            }

            Dictionary<char, char> cardSuitsUTFCodes = new() { { 'S', '\u2660' }, { 'H', '\u2665' }, { 'D', '\u2666' }, { 'C', '\u2663' } };
            char cardSuitToSymbol = cardSuitsUTFCodes.First(x => x.Key == cardSuit).Value;
            
            return new Card(cardFace, cardSuitToSymbol);
        }

        public override string ToString()
        {
            return $"[{this.cardFace}{this.cardSuit}]";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cardFaces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<char> cardSuits = new List<char>() { 'S', 'H', 'D', 'C' };
            StringBuilder output = new StringBuilder();

            string[] cardInputDetails = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cardInputDetails.Length; i++)
            {
                try
                {
                    string[] cardDetails = cardInputDetails[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    IsTheCardDetailsValid(cardDetails);
                    
                    string cardFace = cardDetails[0];
                    char cardSuit = char.Parse(cardDetails[1]);
                    Card card = Card.CreateCard(cardFaces, cardSuits, cardFace, cardSuit);
                    
                    output.Append(card.ToString() + " ");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }

        public static void IsTheCardDetailsValid(string[] cardDetails)
        {
            if (cardDetails.Length > 2)
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }
}
