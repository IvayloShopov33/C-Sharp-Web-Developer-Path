namespace _05._Date_Modifier
{
    public class DateModifier
    {
        public static int CalculateDateDifferenceInDays(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);
            int daysDifference = Math.Abs((dateOne - dateTwo).Days);

            return daysDifference;
        }
    }
}
