using System.Text;

namespace _08._Threeuple
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

            string fullName = firstLineDetails[0] + " " + firstLineDetails[1];
            string address = firstLineDetails[2];
            StringBuilder town = new StringBuilder();
            for (int i = 3; i < firstLineDetails.Length; i++)
            {
                town.Append(firstLineDetails[i] + " ");
            }

            MyThreeuple<string, string, string> fullNameWithAddress =
                new MyThreeuple<string, string, string>(fullName, address, town.ToString());

            string name = secondLineDetails[0];
            int litersOfBeer = int.Parse(secondLineDetails[1]);
            bool isDrunk = secondLineDetails[2] == "drunk";
            MyThreeuple<string, int, bool> nameWithLitersOfBeerAndDrunkCondition =
                new MyThreeuple<string, int, bool>(name, litersOfBeer, isDrunk);

            string customerName = thirdLineDetails[0];
            double accountBalance = double.Parse(thirdLineDetails[1]);
            StringBuilder bankName = new StringBuilder();
            for (int i = 2; i < thirdLineDetails.Length; i++)
            {
                bankName.Append(thirdLineDetails[i] + " ");
            }

            MyThreeuple<string, double, string> nameWithMoneyAndNameOfTheBank =
                new MyThreeuple<string, double, string>(customerName, accountBalance, bankName.ToString());

            Console.WriteLine(fullNameWithAddress.GetItems());
            Console.WriteLine(nameWithLitersOfBeerAndDrunkCondition.GetItems());
            Console.WriteLine(nameWithMoneyAndNameOfTheBank.GetItems());
        }
    }
}