using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ICallable callablePhone = default;

            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                {
                    callablePhone = new StationaryPhone();
                }
                else
                {
                    callablePhone = new Smartphone();
                }

                try
                {
                    Console.WriteLine(callablePhone.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsable browsablePhone = new Smartphone();
            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine(browsablePhone.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}