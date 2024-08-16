namespace _07._Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();
            string thirdLine = Console.ReadLine();

            string[] firstLineDetails = firstLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondLineDetails = secondLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] thirdLineDetails = thirdLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstAndLastName = firstLineDetails[0] + " " + firstLineDetails[1];
            string address = firstLineDetails[2];
            MyTuple<string, string> nameWithAddress = new MyTuple<string, string>(firstAndLastName, address);

            string secondLineName = secondLineDetails[0];
            int litersOfBeer = int.Parse(secondLineDetails[1]);
            MyTuple<string, int> nameWithLitersOfBeer = new MyTuple<string, int>(secondLineName, litersOfBeer);

            int firstNumber = int.Parse(thirdLineDetails[0]);
            double secondNumber = double.Parse(thirdLineDetails[1]);
            MyTuple<int, double> numbers = new MyTuple<int, double>(firstNumber, secondNumber);

            nameWithAddress.PrintOutput();
            nameWithLitersOfBeer.PrintOutput();
            numbers.PrintOutput();
        }
    }
}