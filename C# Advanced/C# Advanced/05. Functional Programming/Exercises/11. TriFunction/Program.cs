namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputSumToBePassed = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isCurrentSumLargerOrEqualThanInputSum = (name, inputSumToBePassed) => name.Sum(x => x) >= inputSumToBePassed;
            Func<string[], int, Func<string, int, bool>, string> desiredName = (allNames, number, func) => allNames.FirstOrDefault(x => func(x, number));

            string outputName = desiredName(names, inputSumToBePassed, isCurrentSumLargerOrEqualThanInputSum);
            Console.WriteLine(outputName);
        }
    }
}