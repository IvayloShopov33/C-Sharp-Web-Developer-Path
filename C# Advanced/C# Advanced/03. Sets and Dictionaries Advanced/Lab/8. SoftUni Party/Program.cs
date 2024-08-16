namespace _8._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guestNames = new HashSet<string>();
            string guestNameOrCommand;
            while (true)
            {
                guestNameOrCommand = Console.ReadLine();
                //check if the input is "PARTY"
                if (guestNameOrCommand == "PARTY")
                {
                    //stop the loop
                    break;
                }

                //add the guest's name to the hashset
                guestNames.Add(guestNameOrCommand);
            }

            while (true)
            {
                guestNameOrCommand = Console.ReadLine();

                //check if the input is "END"
                if (guestNameOrCommand == "END")
                {
                    //print the count of the guests who did not come to the party and check their count
                    Console.WriteLine(guestNames.Count);

                    if (guestNames.Count > 0)
                    {
                        foreach (var name in guestNames)
                        {
                            //check if the guest is VIP (his/her name starts with digit)
                            if (char.IsDigit(name[0]))
                            {
                                //print the guest's name and remove it from the hashset
                                Console.WriteLine(name);
                                guestNames.Remove(name);
                            }
                        }

                        //print the names of the remained guests which did not come to the party
                        Console.WriteLine(string.Join(Environment.NewLine, guestNames));
                    }

                    //stop the loop and the program
                    break;
                }

                //remove the guest's name from the hashset
                guestNames.Remove(guestNameOrCommand);
            }
        }
    }
}