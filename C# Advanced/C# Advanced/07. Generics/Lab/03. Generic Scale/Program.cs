namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>()
            {
                "Ivaylo",
                "Shopov"
            };

            List<string> list2 = new List<string>()
            {
                "Ivaylo",
                "Shopov"
            };

            EqualityScale<List<string>> equalityScale = new EqualityScale<List<string>>(list, list2);
            Console.WriteLine(equalityScale.AreEqual()); //False

            List<string> list3 = list2;
            var equalityScale1 = new EqualityScale<List<string>>(list3, list2);
            Console.WriteLine(equalityScale1.AreEqual()); //True

            string text = "Some random text";
            string text1 = "Some random text";
            var equalityScale2 = new EqualityScale<string>(text, text1);
            Console.WriteLine(equalityScale2.AreEqual()); //True

            int a = 5;
            int b = 3;
            var equalityScale3 = new EqualityScale<int>(a, b);
            Console.WriteLine(equalityScale3.AreEqual()); //False
        }
    }
}