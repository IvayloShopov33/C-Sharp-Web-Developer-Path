namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stackToReverseText = new Stack<char>();
            string inputText = Console.ReadLine();
            
            foreach (char character in inputText)
            {
                stackToReverseText.Push(character);
            }
            
            while (stackToReverseText.Count > 0)
            {
                Console.Write(stackToReverseText.Pop());
            }
        }
    }
}
