namespace _05._Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            int daysDifference = DateModifier.CalculateDateDifferenceInDays(firstDate, secondDate);
            Console.WriteLine(daysDifference);
        }
    }
}